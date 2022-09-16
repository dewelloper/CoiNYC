using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using CoiNYC.Domain.Repositories;
using CoiNYC.Domain.Resources;
using System;
using System.Linq;

namespace CoiNYC.Domain.Currencies
{
    class CurrencyCommandHandler :
            IRequestHandler<CurrencyAdd, int>,
            IRequestHandler<CurrencyEdit, int>,
            IRequestHandler<CurrencyDelete, bool>
    {
        public IDomainRepository DomainRepository { get; set; }
        int IRequestHandler<CurrencyAdd, int>.Handle(CurrencyAdd request)
        {
            var alreadyExists = DomainRepository.GetQuery<Currency>(x => x.Code == request.Code).Any();
            if (alreadyExists)
                throw new BusinessException(R.MSG_DuplicateRecord);

            Currency entity = new Currency { Name = request.Name, Code = request.Code, Symbol = request.Symbol, Enabled = true };
            entity = DomainRepository.Save(entity);

            return entity.Id;
        }

        int IRequestHandler<CurrencyEdit, int>.Handle(CurrencyEdit request)
        {
            Currency entity = DomainRepository.GetQuery<Currency>(x => x.Id == request.Id).FirstOrDefault();

            if (entity == null)
                throw new BusinessException(R.MSG_NotExistingRecord); //"Record does not exists"


            var alreadyExists = DomainRepository.GetQuery<Currency>(x => x.Code == request.Code && x.Id != request.Id).Any();
            if (alreadyExists)
                throw new BusinessException(R.MSG_DuplicateRecord);

            if (request.IsDefault)
            {
                var defaultCurrency = DomainRepository.GetQuery<Currency>(x => x.IsDefault).FirstOrDefault();
                defaultCurrency.IsDefault = false;
                DomainRepository.Update(defaultCurrency);
            }

            entity.Code = request.Code;
            entity.Name = request.Name;
            entity.Symbol = request.Symbol;
            entity.IsDefault = request.IsDefault;
            entity.Rate = request.IsDefault ? 1 : request.Rate;
            entity.Enabled = request.Enabled;

            DomainRepository.Update(entity);
            DomainRepository.UnitOfWork.SaveChanges();

            return entity.Id;

        }

        bool IRequestHandler<CurrencyDelete, bool>.Handle(CurrencyDelete request)
        {
            DomainRepository.Delete<Currency>(x => x.Id == request.Id);
            DomainRepository.UnitOfWork.SaveChanges();

            return true;
        }
    }
}
