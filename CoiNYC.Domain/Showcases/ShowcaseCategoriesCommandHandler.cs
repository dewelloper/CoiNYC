namespace CoiNYC.Domain.Categorys
{
    using CoiNYC.Core.CQRS;
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Showcases;
    using CoiNYC.Domain.Repositories;
    using System.Linq;

    class ShowcaseCategorysCommandHandler :
            IRequestHandler<ShowcaseCategorysAdd, int>,
            IRequestHandler<ShowcaseCategorysEdit, int>,
            IRequestHandler<ShowcaseCategorysDelete, bool>
    {
        public IDomainRepository DomainRepository { get; set; }
        int IRequestHandler<ShowcaseCategorysAdd, int>.Handle(ShowcaseCategorysAdd request)
        {
            var existingEntity = DomainRepository.GetQuery<ShowcaseCategory>(x => x.ShowcaseId == request.ShowcaseId && x.CategoryId == request.CategoryId).FirstOrDefault();
            if (existingEntity != null)
            {
                existingEntity.DisplayOrder = request.DisplayOrder;
                DomainRepository.Update(existingEntity);
                DomainRepository.UnitOfWork.SaveChanges();
                return existingEntity.Id;
            }

            ShowcaseCategory entity = new ShowcaseCategory
            {
                ShowcaseId = request.ShowcaseId,
                CategoryId = request.CategoryId,
                DisplayOrder = request.DisplayOrder
            };
            entity = DomainRepository.Save(entity);

            return entity.Id;
        }

        int IRequestHandler<ShowcaseCategorysEdit, int>.Handle(ShowcaseCategorysEdit request)
        {
            ShowcaseCategory entity = DomainRepository.GetQuery<ShowcaseCategory>(x => x.Id == request.Id).FirstOrDefault();

            if (entity == null)
                throw new BusinessException("Does Not Exists"); //"Record does not exists"


            var alreadyExists = DomainRepository.GetQuery<ShowcaseCategory>(x => ( x.ShowcaseId==request.ShowcaseId && x.CategoryId == request.CategoryId) && x.Id != request.Id).Any();
            if (alreadyExists)
                throw new BusinessException("Duplicate");

            entity.ShowcaseId = request.ShowcaseId;
            entity.CategoryId = request.CategoryId;
            entity.DisplayOrder = request.DisplayOrder;

            DomainRepository.Update(entity);
            DomainRepository.UnitOfWork.SaveChanges();

            return entity.Id;

        }

        bool IRequestHandler<ShowcaseCategorysDelete, bool>.Handle(ShowcaseCategorysDelete request)
        {
            DomainRepository.Delete<ShowcaseCategory>(x => x.Id == request.Id);
            DomainRepository.UnitOfWork.SaveChanges();

            return true;
        }
    }
}
