using System.Linq.Expressions;
using HotelListing.data;
using HotelListing.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Repository;

public class GenericRepository<T> : IGenericRepository<T> where  T: class
{
    private readonly DataBaseContext _context;
    private readonly DbSet<T> _db;

    public GenericRepository(DataBaseContext context, DbSet<T> db)
    {
        _context = context;
        _db = db;
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
    {
        IQueryable<T> query = _db;

        query = query.Where(expression);

        query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        query = orderBy(query);
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
    {
        IQueryable<T> query = _db;
        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task Insert(T entity)
    {
        await _db.AddAsync(entity);
    }
    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _db.AddRangeAsync(entities);
    }

    public async Task Delete(int id)
    {
        var entity = await _db.FindAsync(id);
        _db.Remove(entity);

    }

    public void DeleteRange(IEnumerable<T> entities)
    {
       _db.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}