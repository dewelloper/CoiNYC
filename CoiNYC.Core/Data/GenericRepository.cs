using CoiNYC.Core.Linq.Specifications;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
//using System.Data;
using System.Data.Common;
//using System.Data.Entity;
//using System.Data.Entity.Core.Metadata.Edm;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Design.PluralizationServices;
//using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
//using System.Data.Entity.Infrastructure;

namespace CoiNYC.Core.Data
{
    public partial class GenericRepository : IRepository
    {
        private readonly string _connectionStringName;
        public DbContext _context;
        //private readonly PluralizationService _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));

        public GenericRepository()
            : this(string.Empty)
        {
        }

        public GenericRepository(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        public GenericRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
        }

        public GenericRepository(DbContextOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("contextOptionsIsNull");
            _context = new DbContext(options);
        }

        //public TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
        //{
        //    System.Data.Entity.Core.EntityKey key = GetEntityKey<TEntity>(keyValue);

        //    object originalItem;
        //    //if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
        //    //{
        //    //    return (TEntity)originalItem;
        //    //}
        //    return default(TEntity);
        //}

        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            var entityName = GetEntityName<TEntity>();
            //return ((IObjectContextAdapter)DbContext).ObjectContext.CreateQuery<TEntity>(entityName);
            return _context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetQuery<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetQuery<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>());
        }

        public IEnumerable<TEntity> Get<TEntity, TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return GetQuery<TEntity>().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return GetQuery<TEntity>().OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<TEntity> Get<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return GetQuery<TEntity>(criteria).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return GetQuery<TEntity>(criteria).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<TEntity> Get<TEntity, TOrderBy>(ISpecification<TEntity> specification, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Single<TEntity>(criteria);
        }

        public TEntity Single<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return criteria.SatisfyingEntityFrom(GetQuery<TEntity>());
        }

        public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetQuery<TEntity>().First(predicate);
        }

        public TEntity First<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).First();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            DbContext.Set<TEntity>().Attach(entity);
        }

        //public void Truncate<TEntity>() where TEntity : class
        //{
        //    var entityName = GetTableName(typeof(TEntity), DbContext);

        //    DbContext.Database.ExecuteSqlCommand(String.Format("TRUNCATE TABLE {0}", entityName));
        //}

        //public static string GetTableName(Type type, DbContext context)
        //{
        //    var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;

        //    var entityType = metadata.GetItems<EntityType>(DataSpace.SSpace).Single(x => x.Name == type.Name);

        //    var o = entityType.MetadataProperties["TableName"].Value ?? entityType.Name;

        //    return o.ToString();

        //}

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IEnumerable<TEntity> records = Find<TEntity>(criteria);

            foreach (TEntity record in records)
            {
                Delete<TEntity>(record);
            }
        }

        public void Delete<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            IEnumerable<TEntity> records = Find<TEntity>(criteria);
            foreach (TEntity record in records)
            {
                Delete<TEntity>(record);
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().AsEnumerable();
        }

        public TEntity Save<TEntity>(TEntity entity) where TEntity : class
        {
            Add<TEntity>(entity);
            //if (!UnitOfWork.IsInTransaction)
            DbContext.SaveChanges();
            return entity;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            var fqen = GetEntityName<TEntity>();

            object originalItem;
            //System.Data.Entity.Core.EntityKey key = ((IObjectContextAdapter)DbContext).ObjectContext.CreateEntityKey(fqen, entity);
            //if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
            //{
            //    ((IObjectContextAdapter)DbContext).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
            //}
        }

        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria);
        }

        public TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria).FirstOrDefault();
        }

        public TEntity FindOne<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return criteria.SatisfyingEntityFrom(GetQuery<TEntity>());
        }

        public IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).AsEnumerable();
        }

        public int Count<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().Count();
        }

        public int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Count(criteria);
        }

        public int Count<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).Count();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(DbContext);
                }
                return unitOfWork;
            }
        }

        //private System.Data.Entity.Core.EntityKey GetEntityKey<TEntity>(object keyValue) where TEntity : class
        //{
        //    //var entitySetName = GetEntityName<TEntity>();
        //    //var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<TEntity>();
        //    //var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
        //    //var entityKey = new System.Data.Entity.Core.EntityKey(entitySetName, new[] { new System.Data.Entity.Core.EntityKeyMember(keyPropertyName, keyValue) });
        //    //return entityKey;
        //    return null;
        //}

        private string GetEntityName<TEntity>() where TEntity : class
        {
            //string entitySetName = ((IObjectContextAdapter)DbContext).ObjectContext
            //    .MetadataWorkspace
            //    .GetEntityContainer(((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, DataSpace.CSpace)
            //                        .BaseEntitySets.Where(bes => bes.ElementType.Name == typeof(TEntity).Name).First().Name;
            //return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, entitySetName);
            return null;

            //return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, _pluralizer.Pluralize(typeof(TEntity).Name));
            //TableAttribute Desteklemiyor Kardesim
        }

        //private string GetEntityNameSingle<TEntity>() where TEntity : class
        //{
        //    return string.Format("{0}", _pluralizer.Pluralize(typeof(TEntity).Name));
        //}

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryInclude<TEntity>(Expression<Func<TEntity, object>> path) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Truncate<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable SqlQuerySmart(Type elementType, string storedProcedure, object inputParameters = null, params SqlParameter[] outpuParameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SqlQuerySmart<TEntity>(string storedProcedure, object inputParameters = null, params SqlParameter[] outpuParameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommandSmart(string storedProcedure, object inputParameters = null, SqlParameter[] outpuParameters = null)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommandSmart(bool ensureTransaction, string storedProcedure, object inputParameters = null, SqlParameter[] outpuParameters = null)
        {
            throw new NotImplementedException();
        }

        public StoredProcedureResult ExecuteSqlCommandSmartError(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        {
            throw new NotImplementedException();
        }

        public StoredProcedureListResult<TEntity> SqlQuerySmartError<TEntity>(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ExecuteReaderSmart(string storedProcedure, object inputParameters = null, params SqlParameter[] outpuParameters)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
        {
            throw new NotImplementedException();
        }

        void IRepository.ChangeState<TEntity>(int Id)
        {
            throw new NotImplementedException();
        }

        public DbContext DbContext
        {
            get
            {
                if (_context == null)
                {
                    if (_connectionStringName == string.Empty)
                        _context = DbContextManager.Current;
                    else
                        _context = DbContextManager.CurrentFor(_connectionStringName);
                }
                return _context;
            }
        }

        private IUnitOfWork unitOfWork;
    }


    public partial class GenericRepository : IRepository
    {
        public IPagedList<TEntity> GetPageList<TEntity>(int pageIndex, int pageSize) where TEntity : class, IUniqueable
        {

            IQueryable<TEntity> query = GetQuery<TEntity>().OrderBy(c => c.Id); ;
            PagedList<TEntity> list = new PagedList<TEntity>(query, pageIndex, pageSize);
            return list;
        }

        public IPagedList<KEntity> GetPageList<TEntity, KEntity>(IQueryable<TEntity> query, int pageIndex, int pageSize, Expression<Func<TEntity, KEntity>> columns)
            where TEntity : class, IUniqueable
            where KEntity : class
        {

            IQueryable<KEntity> query2 = query.Select<TEntity, KEntity>(columns);
            PagedList<KEntity> list = new PagedList<KEntity>();
            list.Initialize(query2, pageIndex, pageSize);
            return list;
        }

        public void MoveUpOne<TEntity>(int position, Expression<Func<TEntity, bool>> criteria = null) where TEntity : class, ISequential
        {

            IQueryable<TEntity> entity;

            if (criteria != null)
            {
                entity = GetQuery<TEntity>(criteria);
            }
            else
            {
                entity = GetQuery<TEntity>();
            }

            if (entity.Any(i => i.Sequence < position))
            {
                var swapEntity = entity.SingleOrDefault(i1 => entity.Where(i2 => i2.Sequence < position).Max(i3 => i3.Sequence) == i1.Sequence);
                if (swapEntity == null) return;

                ISequential item = entity.SingleOrDefault(i => i.Sequence == position);
                if (item == null)
                    throw new ApplicationException("There is no item at position");

                int tempPosition = swapEntity.Sequence;
                swapEntity.Sequence = item.Sequence;
                item.Sequence = tempPosition;
                UnitOfWork.SaveChanges();

            }
        }

        public void MoveDownOne<TEntity>(int position, Expression<Func<TEntity, bool>> criteria = null) where TEntity : class, ISequential
        {

            IQueryable<TEntity> entity;

            if (criteria != null)
            {
                entity = GetQuery<TEntity>(criteria);
            }
            else
            {
                entity = GetQuery<TEntity>();
            }


            if (entity.Any(i => i.Sequence > position))
            {
                var swapEntity = entity.SingleOrDefault(i1 => entity.Where(i2 => i2.Sequence > position).Min(i3 => i3.Sequence) == i1.Sequence);
                if (swapEntity == null) return;

                ISequential item = entity.SingleOrDefault(i => i.Sequence == position);
                if (item == null)
                    throw new ApplicationException("There is no item at position");

                int tempPosition = swapEntity.Sequence;
                swapEntity.Sequence = item.Sequence;
                item.Sequence = tempPosition;
                this.UnitOfWork.SaveChanges();

            }
        }




        //public void ChangeState<TEntity>(int Id) where TEntity : class, IActivable, IUniqueable, new()
        //{
        //    var entity = this.GetByKey<TEntity>(Id);

        //    if (entity != null)
        //    {
        //        entity.Active = !entity.Active;
        //    }

        //    this.DbContext.SaveChanges();
        //}

        public void Delete<TEntity>(int Id) where TEntity : class, IDeleteableEntity, IUniqueable, new()
        {
            var entity = new TEntity() { Id = Id, Deleted = true };
            this.Attach(entity);
            this.DbContext.Entry(entity).Property(x => x.Deleted).IsModified = true;
            this.DbContext.SaveChanges();
        }


        //public System.Data.Entity.Core.Objects.ObjectResult<TEntity> Translate<TEntity>(DbDataReader reader) where TEntity : class
        //{
        //    //var objectContext = ((IObjectContextAdapter)DbContext).ObjectContext;
        //    //return objectContext.Translate<TEntity>(reader);
        //    return null;
        //}


        //public System.Data.Entity.Core.Objects.ObjectResult<TEntity> Translate<TEntity>(DbDataReader reader, string entitySetName, System.Data.Entity.Core.Objects.MergeOption mergeOption)
        //{
        //    //var objectContext = ((IObjectContextAdapter)DbContext).ObjectContext;
        //    //var result = objectContext.Translate<TEntity>(reader, entitySetName, mergeOption);
        //    //return result;
        //    return null;
        //}

        //public IEnumerable<TEntity> SqlQuerySmart<TEntity>(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        //{
        //    if (string.IsNullOrEmpty(storedProcedure))
        //        throw new ArgumentException("storedProcedure");

        //    var arguments = PrepareArguments(storedProcedure, inputParameters, outputParameters);
        //    return this.DbContext.Database.SqlQuery<TEntity>(arguments.Item1, arguments.Item2);
        //}

        //public IEnumerable SqlQuerySmart(Type elementType, string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        //{
        //    if (elementType == null)
        //        throw new ArgumentNullException("elementType");
        //    if (string.IsNullOrEmpty(storedProcedure))
        //        throw new ArgumentException("storedProcedure");

        //    var arguments = PrepareArguments(storedProcedure, inputParameters, outputParameters);


        //    return this.DbContext.Database.SqlQuery(elementType, arguments.Item1, arguments.Item2);
        //}


        public IDataSetObjects SqlQueryDataset(Type[] types, string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        {
            if (string.IsNullOrEmpty(storedProcedure))
                throw new ArgumentException("storedProcedure");

            var arguments = PrepareArguments(storedProcedure, inputParameters, outputParameters);

            DataSetObjects value = null;
            using (var reader = ExecuteReaderSmart(storedProcedure, inputParameters, outputParameters))
            {
                value = new DataSetObjects(DbContext, reader, types);
            }
            return value;
        }

        //public int ExecuteSqlCommandSmart(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        //{
        //    if (string.IsNullOrEmpty(storedProcedure))
        //        throw new ArgumentException("storedProcedure");

        //    try
        //    {
        //        var arguments = PrepareArguments(storedProcedure, inputParameters, outputParameters);

        //        var result = this.DbContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, arguments.Item1, arguments.Item2);

        //        return result;
        //    }
        //    catch(Exception ex)
        //    {
        //        ;
        //    }
        //    return -1;
        //}

        //public int ExecuteSqlCommandSmart(bool ensureTransaction, string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        //{
        //    if (string.IsNullOrEmpty(storedProcedure))
        //        throw new ArgumentException("storedProcedure");

        //    var arguments = PrepareArguments(storedProcedure, inputParameters, outputParameters);
        //    TransactionalBehavior transactionalBehavior = ensureTransaction ? TransactionalBehavior.EnsureTransaction : TransactionalBehavior.DoNotEnsureTransaction;

        //    var result = this.DbContext.Database.ExecuteSqlCommand(transactionalBehavior, arguments.Item1, arguments.Item2);

        //    return result;
        //}

        //public StoredProcedureResult ExecuteSqlCommandSmartError(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        //{
        //    SqlParameter errorValue = new SqlParameter("Err", DbType.Int32);

        //    errorValue.Direction = ParameterDirection.Output;

        //    if (outputParameters.Length == 0)
        //    {
        //        outputParameters = new SqlParameter[1];
        //    }

        //    outputParameters.SetValue(errorValue, outputParameters.Length - 1);

        //    int AffectedRows = this.ExecuteSqlCommandSmart(storedProcedure, inputParameters, outputParameters);

        //    StoredProcedureResult spError = new StoredProcedureResult(storedProcedure, Math.Abs((int)errorValue.Value));
        //    spError.AffectedRows = AffectedRows;

        //    return spError;
        //}

        //public StoredProcedureListResult<TEntity> SqlQuerySmartError<TEntity>(string storedProcedure, object inputParameters = null, params SqlParameter[] outputParameters)
        //{
        //    SqlParameter errorValue = new SqlParameter("Err", DbType.Int32);

        //    errorValue.Direction = ParameterDirection.Output;

        //    if (outputParameters.Length == 0)
        //    {
        //        outputParameters = new SqlParameter[1];
        //    }

        //    outputParameters.SetValue(errorValue, outputParameters.Length - 1);

        //    var result = this.SqlQuerySmart<TEntity>(storedProcedure, inputParameters, outputParameters).ToList();

        //    StoredProcedureListResult<TEntity> list = new StoredProcedureListResult<TEntity>(result);

        //    list.Result = new StoredProcedureResult(storedProcedure, Math.Abs((int)errorValue.Value));

        //    return list;
        //}


        //public SqlDataReader ExecuteReaderSmart(string storedProcedure, object inputParameters = null, SqlParameter[] outputParameters = null)
        //{
        //    var objectContext = ((IObjectContextAdapter)DbContext).ObjectContext;
        //    var sqlConnection = new SqlConnection(this.DbContext.Database.Connection.ConnectionString);
        //    //var sqlConnection = new SqlConnection(ConfigReader.GetConnectionstring());
        //    var sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    var arguments = PrepareArguments(storedProcedure, inputParameters, outputParameters);
        //    sqlCommand.CommandText = storedProcedure;
        //    sqlCommand.Parameters.AddRange(arguments.Item2);
        //    sqlConnection.Open();
        //    return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //}



        private static Tuple<string, object[]> PrepareArguments(string storedProcedure, object inputParameters, params SqlParameter[] outputParameters)
        {
            var parameterNames = new List<string>();
            var parameters = new List<object>();

            if (inputParameters != null)
            {
                foreach (PropertyInfo propertyInfo in inputParameters.GetType().GetProperties())
                {
                    string name = "@" + propertyInfo.Name;
                    object value = propertyInfo.GetValue(inputParameters, null);

                    parameterNames.Add(name);
                    parameters.Add(new SqlParameter(name, value ?? DBNull.Value));
                }
            }

            if (outputParameters != null)
            {
                foreach (SqlParameter outputParameter in outputParameters)
                {
                    parameterNames.Add(String.Format("{0} OUT", outputParameter.ParameterName));
                    parameters.Add(outputParameter);
                }
            }

            if (parameterNames.Count > 0)
            {
                storedProcedure += " " + string.Join(", ", parameterNames);
            }

            return new Tuple<string, object[]>(storedProcedure, parameters.ToArray());
        }

        //public IQueryable<TEntity> GetQueryInclude<TEntity>(Expression<Func<TEntity, object>> path) where TEntity : class
        //{
        //    return GetQuery<TEntity>().Include(path);
        //}

    }

    public class DataSetObjects : IDataSetObjects
    {
        private Dictionary<Type, object> sets = new Dictionary<Type, object>();
        private Dictionary<Type, List<object>> rawSets = new Dictionary<Type, List<object>>();
        private static MethodInfo translateMethod;
        private static ConcurrentDictionary<Type, MethodInfo> cachedMethods = new ConcurrentDictionary<Type, MethodInfo>();

        static DataSetObjects()
        {
            //translateMethod = typeof(ObjectContext).GetMethod("Translate", new Type[] { typeof(DbDataReader) });
        }

        private MethodInfo GetTranslateMethod(Type type)
        {
            MethodInfo methodInfo = null;
            if (!cachedMethods.TryGetValue(type, out methodInfo))
            {
                methodInfo = translateMethod.MakeGenericMethod(type);
                cachedMethods.AddOrUpdate(type, methodInfo, (t, m) => methodInfo);
            }

            return methodInfo;
        }
        private DataSetObjects()
        {
        }

        internal DataSetObjects(DbContext context, SqlDataReader reader, params Type[] types)
        {
            //var objectContext = ((IObjectContextAdapter)context).ObjectContext;

            //int i = 0;
            //do
            //{
            //    if (i >= types.Length)
            //        break;
            //    MethodInfo generic = GetTranslateMethod(types[i]);
            //    var translatedList = new List<object>(generic.Invoke(objectContext, new object[] { reader }) as IEnumerable<object>);

            //    rawSets.Add(types[i], translatedList);
            //    i++;
            //} while (reader.NextResult());
            
        }


        public List<T> GetResult<T>()
        {
            var type = typeof(T);
            if (!sets.ContainsKey(type))
            {
                List<T> list = new List<T>();
                if (rawSets.ContainsKey(type) && rawSets[type] != null)
                {
                    foreach (object item in rawSets[type])
                    {
                        list.Add((T)item);
                    }
                }

                sets[type] = list;
            }
            return sets[type] as List<T>;
        }

    }
}
