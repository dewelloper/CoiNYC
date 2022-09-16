using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CoiNYC.Core.Data;
using CoiNYC.Core.Linq.Specifications;

namespace CoiNYC.Core.Data
{

    public partial interface IRepository
    {
        TEntity GetByKey<TEntity>(object keyValue) where TEntity : class;
        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IQueryable<TEntity> GetQuery<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        IQueryable<TEntity> GetQueryInclude<TEntity>(Expression<Func<TEntity, object>> path) where TEntity : class;
        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        TEntity Single<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity First<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Attach<TEntity>(TEntity entity) where TEntity : class;
        void Truncate<TEntity>() where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        void Delete<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity Save<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
        IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        TEntity FindOne<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        IEnumerable<TEntity> Get<TEntity, TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;
        IEnumerable<TEntity> Get<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;
        IEnumerable<TEntity> Get<TEntity, TOrderBy>(ISpecification<TEntity> specification, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;
        int Count<TEntity>() where TEntity : class;
        int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        int Count<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        IUnitOfWork UnitOfWork { get; }

        IPagedList<TEntity> GetPageList<TEntity>(int pageIndex, int pageSize) where TEntity : class,IUniqueable;
        IPagedList<KEntity> GetPageList<TEntity, KEntity>(IQueryable<TEntity> query, int pageIndex, int pageSize, Expression<Func<TEntity, KEntity>> columns)
            where TEntity : class,IUniqueable
            where KEntity : class;
        void MoveUpOne<TEntity>(int position, Expression<Func<TEntity, bool>> criteria = null) where TEntity : class,ISequential;
        void MoveDownOne<TEntity>(int position, Expression<Func<TEntity, bool>> criteria = null) where TEntity : class,ISequential;
        void ChangeState<TEntity>(int Id) where TEntity : class,IActivable, IUniqueable, new();
        void Delete<TEntity>(int Id) where TEntity : class,IDeleteableEntity, IUniqueable, new();
        IEnumerable SqlQuerySmart(Type elementType, string storedProcedure, object inputParameters = null, params SqlParameter[] outpuParameters);
        IEnumerable<TEntity> SqlQuerySmart<TEntity>(string storedProcedure, object inputParameters = null, params SqlParameter[] outpuParameters);
        int ExecuteSqlCommandSmart(string storedProcedure, object inputParameters = null, SqlParameter[] outpuParameters = null);
        int ExecuteSqlCommandSmart(bool ensureTransaction, string storedProcedure, object inputParameters = null, SqlParameter[] outpuParameters = null);
        StoredProcedureResult ExecuteSqlCommandSmartError(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters);
        StoredProcedureListResult<TEntity> SqlQuerySmartError<TEntity>(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters);
        SqlDataReader ExecuteReaderSmart(string storedProcedure, object inputParameters = null, params SqlParameter[] outpuParameters);
        IDataSetObjects SqlQueryDataset(Type[] types, string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters);
    }



}
