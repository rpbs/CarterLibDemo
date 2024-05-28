using LibCarter.Data;
using Microsoft.EntityFrameworkCore;

namespace LibCarter.Repos;

public class CarRepository(Context context) : ICarRepository
{
    readonly Context _context = context;

    public async Task CreateCar(string name, double price)
    {
        await _context.AddAsync(new Car { Name = name, Price = price });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCar(int id)
    {
        var car = await GetCar(id);
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Car>> GetAllCars()
    {
        return await _context.Cars.ToArrayAsync();
    }

    public async Task<Car> GetCar(int id)
    {
        return await _context.Cars.AsNoTracking().FirstAsync(c => c.Id == id);
    }

    public async Task UpdateCar(int id, string name, double price)
    {
        var car = await GetCar(id);
        car.Name = name;
        car.Price = price;
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
    }
}
