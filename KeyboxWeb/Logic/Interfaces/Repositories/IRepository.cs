using KeyboxWeb.Logic.Interfaces.Markers;

namespace KeyboxWeb.Logic.Interfaces.Repositories;

public interface IRepository<T> where T : IModel
{
    void Add(T model);
    void Delete(int id);
    IEnumerable<T> Get();
    T? Get(int id);
    void Update(T model);
}