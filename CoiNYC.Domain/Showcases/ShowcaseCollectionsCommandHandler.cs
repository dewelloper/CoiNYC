namespace CoiNYC.Domain.Collections
{
    using CoiNYC.Core.CQRS;
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Showcases;
    using CoiNYC.Domain.Repositories;
    using System.Linq;

    class ShowcaseCollectionsCommandHandler :
            IRequestHandler<ShowcaseCollectionsAdd, int>,
            IRequestHandler<ShowcaseCollectionsEdit, int>,
            IRequestHandler<ShowcaseCollectionsDelete, bool>
    {
        public IDomainRepository DomainRepository { get; set; }
        int IRequestHandler<ShowcaseCollectionsAdd, int>.Handle(ShowcaseCollectionsAdd request)
        {
            var existingEntity = DomainRepository.GetQuery<ShowcaseCollection>(x => x.ShowcaseId == request.ShowcaseId && x.CollectionId == request.CollectionId).FirstOrDefault();
            if (existingEntity != null)
            {
                existingEntity.DisplayOrder = request.DisplayOrder;
                DomainRepository.Update(existingEntity);
                DomainRepository.UnitOfWork.SaveChanges();
                return existingEntity.Id;
            }


            ShowcaseCollection entity = new ShowcaseCollection
            {
                ShowcaseId = request.ShowcaseId,
                CollectionId = request.CollectionId,
                DisplayOrder = request.DisplayOrder
            };
            entity = DomainRepository.Save(entity);

            return entity.Id;
        }

        int IRequestHandler<ShowcaseCollectionsEdit, int>.Handle(ShowcaseCollectionsEdit request)
        {
            ShowcaseCollection entity = DomainRepository.GetQuery<ShowcaseCollection>(x => x.Id == request.Id).FirstOrDefault();

            if (entity == null)
                throw new BusinessException("Does Not Exists"); //"Record does not exists"


            var alreadyExists = DomainRepository.GetQuery<ShowcaseCollection>(x => ( x.ShowcaseId==request.ShowcaseId && x.CollectionId == request.CollectionId) && x.Id != request.Id).Any();
            if (alreadyExists)
                throw new BusinessException("Duplicate");

            entity.ShowcaseId = request.ShowcaseId;
            entity.CollectionId = request.CollectionId;
            entity.DisplayOrder = request.DisplayOrder;

            DomainRepository.Update(entity);
            DomainRepository.UnitOfWork.SaveChanges();

            return entity.Id;

        }

        bool IRequestHandler<ShowcaseCollectionsDelete, bool>.Handle(ShowcaseCollectionsDelete request)
        {
            DomainRepository.Delete<ShowcaseCollection>(x => x.Id == request.Id);
            DomainRepository.UnitOfWork.SaveChanges();

            return true;
        }
    }
}
