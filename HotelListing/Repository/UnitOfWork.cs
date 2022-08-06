using HotelListing.data;
using HotelListing.IRepository;

namespace HotelListing.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _context;

    public UnitOfWork(DataBaseContext context, IGenericRepository<Country> countries, IGenericRepository<Hotel> hotels)
    {
        _context = context;
        Countries = countries;
        Hotels = hotels;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IGenericRepository<Country> Countries { get; }
    public IGenericRepository<Hotel> Hotels { get; }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}