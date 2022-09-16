using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using CoiNYC.Domain.Repositories;
using System;
using System.Linq;

namespace CoiNYC.Domain.Showcases
{
    class ShowcaseCommandHandler :
            IRequestHandler<ShowcaseAdd, int>,
            IRequestHandler<ShowcaseEdit, int>,
            IRequestHandler<ShowcaseDelete, bool>
    {
        public IDomainRepository DomainRepository { get; set; }
        int IRequestHandler<ShowcaseAdd, int>.Handle(ShowcaseAdd request)
        {
            var alreadyExists = DomainRepository.GetQuery<Showcase>(x => x.Name == request.Name).Any();
            if (alreadyExists)
                throw new BusinessException("Duplicate");

            Showcase entity = new Showcase
            {
                Name = request.Name,
                DisplayOrder = request.DisplayOrder,
                Enabled = request.Enabled,
                ShowcasePositionId = request.ShowcasePositionId,
                Type = request.Type,
                GroupByCategory = request.GroupByCategory,
            };
            entity = DomainRepository.Save(entity);

            return entity.Id;
        }

        int IRequestHandler<ShowcaseEdit, int>.Handle(ShowcaseEdit request)
        {
            Showcase entity = DomainRepository.GetQuery<Showcase>(x => x.Id == request.Id).FirstOrDefault();

            if (entity == null)
                throw new BusinessException("Does Not Exists"); //"Record does not exists"


            var alreadyExists = DomainRepository.GetQuery<Showcase>(x => x.Name == request.Name && x.Id != request.Id).Any();
            if (alreadyExists)
                throw new BusinessException("Duplicate");

            entity.Name = request.Name;
            entity.DisplayOrder = request.DisplayOrder;
            entity.Enabled = request.Enabled;
            entity.ShowcasePositionId = request.ShowcasePositionId;
            entity.GroupByCategory = request.GroupByCategory;


            DomainRepository.Update(entity);
            DomainRepository.UnitOfWork.SaveChanges();

            return entity.Id;

        }

        bool IRequestHandler<ShowcaseDelete, bool>.Handle(ShowcaseDelete request)
        {
            DomainRepository.Delete<Showcase>(x => x.Id == request.Id);
            DomainRepository.UnitOfWork.SaveChanges();

            return true;
        }
    }
}
