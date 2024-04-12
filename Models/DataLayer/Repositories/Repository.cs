using Microsoft.EntityFrameworkCore;

namespace QuarterlySalesApp.Models.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected QuarterlyEmployeeSalesDbContext _context { get; set; }

        private DbSet<T> dbset { get; set; }

        public Repository(QuarterlyEmployeeSalesDbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }

        private int? count;
        public int Count => count ?? dbset.Count();

        public virtual IEnumerable<T> List(QueryOptions<T> queryOptions)
        {
            IQueryable<T> query = BuildQuery(queryOptions);
            return query.ToList();
        }

        public virtual T Get(QueryOptions<T> queryOptions)
        {
            IQueryable<T> query = BuildQuery(queryOptions);
            return query.FirstOrDefault();
        }

        public virtual T Get(int id) => dbset.Find(id);

        public void Insert(T Entity) => dbset.Add(Entity);

        public void Update(T Entity) => dbset.Update(Entity);

        public void Save() => _context.SaveChanges();

        private IQueryable<T> BuildQuery(QueryOptions<T> queryOptions)
        {
            IQueryable<T> query = dbset;

            foreach (string include in queryOptions.GetIncludes())
            {
                query = query.Include(include);
            }

            if (queryOptions.HasWhere)
            {
                foreach (var clause in queryOptions.WhereClauses)
                {
                    query = query.Where(clause);
                }

                count = query.Count();
            }

            if (queryOptions.HasOrderBy)
            {
                if (queryOptions.OrderByDirection == "asc")
                    query = query.OrderBy(queryOptions.OrderBy);
                else
                    query = query.OrderByDescending(queryOptions.OrderBy);
            }
            if (queryOptions.HasPaging)
            {
                query = query.PageBy(queryOptions.PageNumber, queryOptions.PageSize);
            }



            return query;
        }
    }
}
