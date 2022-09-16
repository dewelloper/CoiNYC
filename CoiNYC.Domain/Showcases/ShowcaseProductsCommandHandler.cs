namespace CoiNYC.Domain.Products
{
    using CoiNYC.Core.CQRS;
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Showcases;
    using CoiNYC.Domain.Repositories;
    using System.Linq;

    class ShowcaseProductsCommandHandler :
            IRequestHandler<ShowcaseProductsAdd, int>,
            IRequestHandler<ShowcaseProductsEdit, int>,
            IRequestHandler<ShowcaseProductsDelete, bool>
    {
        public IDomainRepository DomainRepository { get; set; }
        int IRequestHandler<ShowcaseProductsAdd, int>.Handle(ShowcaseProductsAdd request)
        {
            var existingEntity = DomainRepository.GetQuery<ShowcaseProduct>(x => x.ShowcaseId == request.ShowcaseId && x.ProductId == request.ProductId).FirstOrDefault();
            if (existingEntity != null)
            {
                existingEntity.DisplayOrder = request.DisplayOrder;
                DomainRepository.Update(existingEntity);
                DomainRepository.UnitOfWork.SaveChanges();
                return existingEntity.Id;
            }

            ShowcaseProduct entity = new ShowcaseProduct
            {
                ShowcaseId = request.ShowcaseId,
                ProductId = request.ProductId,
                DisplayOrder = request.DisplayOrder
            };
            entity = DomainRepository.Save(entity);

            return entity.Id;
        }

        int IRequestHandler<ShowcaseProductsEdit, int>.Handle(ShowcaseProductsEdit request)
        {
            ShowcaseProduct entity = DomainRepository.GetQuery<ShowcaseProduct>(x => x.Id == request.Id).FirstOrDefault();

            if (entity == null)
                throw new BusinessException("Does Not Exists"); //"Record does not exists"


            var alreadyExists = DomainRepository.GetQuery<ShowcaseProduct>(x => ( x.ShowcaseId==request.ShowcaseId && x.ProductId == request.ProductId) && x.Id != request.Id).Any();
            if (alreadyExists)
                throw new BusinessException("Duplicate");

            entity.ShowcaseId = request.ShowcaseId;
            entity.ProductId = request.ProductId;
            entity.DisplayOrder = request.DisplayOrder;

            DomainRepository.Update(entity);
            DomainRepository.UnitOfWork.SaveChanges();

            return entity.Id;

        }

        bool IRequestHandler<ShowcaseProductsDelete, bool>.Handle(ShowcaseProductsDelete request)
        {
            DomainRepository.Delete<ShowcaseProduct>(x => x.Id == request.Id);
            DomainRepository.UnitOfWork.SaveChanges();

            return true;
        }
    }
}
