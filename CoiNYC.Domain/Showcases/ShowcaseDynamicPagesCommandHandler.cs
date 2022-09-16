namespace CoiNYC.Domain.DynamicPages
{
    using CoiNYC.Core.CQRS;
    using CoiNYC.Core.Data;
    using CoiNYC.Domain.Showcases;
    using CoiNYC.Domain.Repositories;
    using System.Linq;

    class ShowcaseDynamicPagesCommandHandler :
            IRequestHandler<ShowcaseDynamicPagesAdd, int>,
            IRequestHandler<ShowcaseDynamicPagesEdit, int>,
            IRequestHandler<ShowcaseDynamicPagesDelete, bool>
    {
        public IDomainRepository DomainRepository { get; set; }
        int IRequestHandler<ShowcaseDynamicPagesAdd, int>.Handle(ShowcaseDynamicPagesAdd request)
        {
            var existingEntity = DomainRepository.GetQuery<ShowcaseDynamicPage>(x => x.ShowcaseId == request.ShowcaseId && x.Title == request.Title && x.Url == request.Url).FirstOrDefault();
            if (existingEntity != null)
            {
                existingEntity.ButtonText = request.ButtonText;
                existingEntity.Description = request.Description;
                existingEntity.Title = request.Title;
                existingEntity.Url = request.Url;
                DomainRepository.Update(existingEntity);
                DomainRepository.UnitOfWork.SaveChanges();
                return existingEntity.Id;
            }


            ShowcaseDynamicPage entity = new ShowcaseDynamicPage
            {
                ShowcaseId = request.ShowcaseId,
                ButtonText = request.ButtonText,
                Description = request.Description,
                Title = request.Title,
                Url = request.Url
            };
            entity = DomainRepository.Save(entity);

            return entity.Id;
        }

        int IRequestHandler<ShowcaseDynamicPagesEdit, int>.Handle(ShowcaseDynamicPagesEdit request)
        {
            ShowcaseDynamicPage entity = DomainRepository.GetQuery<ShowcaseDynamicPage>(x => x.Id == request.Id).FirstOrDefault();

            if (entity == null)
                throw new BusinessException("Does Not Exists"); //"Record does not exists"


            var alreadyExists = DomainRepository.GetQuery<ShowcaseDynamicPage>(x => (x.ShowcaseId == request.ShowcaseId) && x.Id != request.Id).Any();
            if (alreadyExists)
                throw new BusinessException("Duplicate");

            entity.ShowcaseId = request.ShowcaseId;
            entity.ButtonText = request.ButtonText;
            entity.Description = request.Description;
            entity.Title = request.Title;
            entity.Url = request.Url;

            DomainRepository.Update(entity);
            DomainRepository.UnitOfWork.SaveChanges();

            return entity.Id;

        }

        bool IRequestHandler<ShowcaseDynamicPagesDelete, bool>.Handle(ShowcaseDynamicPagesDelete request)
        {
            DomainRepository.Delete<ShowcaseDynamicPage>(x => x.Id == request.Id);
            DomainRepository.UnitOfWork.SaveChanges();

            return true;
        }
    }
}
