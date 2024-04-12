namespace QuarterlySalesApp.Models.DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> queryOptions);
        int Count { get; }
        T Get(QueryOptions<T> queryOptions);
        T Get(int id);
        void Insert(T Entity);
        void Update(T Entity);
        void Save();
    }
}
