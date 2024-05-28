using LibCarter.Data;

namespace LibCarter.Repos;

public interface ICarRepository
{
    Task CreateCar(string name, double price);
    Task<Car> GetCar(int id);
    Task<IEnumerable<Car>> GetAllCars();
    Task DeleteCar(int id);
    Task UpdateCar(int id, string name, double price);
}
