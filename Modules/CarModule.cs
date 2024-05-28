using Carter;
using LibCarter.Data;
using LibCarter.Repos;

namespace LibCarter.Modules;

public class CarModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/car/{id}", GetCarByIdAsync);        
        app.MapPost("/car", CreateCarAsync);
        app.MapGet("/car", GetAllAsync);
        app.MapDelete("/car/{id}", DeleteCarById);
        app.MapPut("/car/{id}", UpdateCar);
    }

    async Task<IResult> GetAllAsync(ICarRepository repo)
    {
        IEnumerable<Car> allCars = await repo.GetAllCars();
        return Results.Ok(allCars);
    }

    async Task<IResult> GetCarByIdAsync(int id, ICarRepository repo)
    {
        var car = await repo.GetCar(id);
        return Results.Ok(car);
    }

    async Task<IResult> CreateCarAsync(Car car, ICarRepository repo)
    {
        await repo.CreateCar(car.Name, car.Price);
        return Results.Created();
    }

    async Task<IResult> UpdateCar(int id, Car car, ICarRepository repo)
    {
        await repo.UpdateCar(id, car.Name, car.Price);
        return Results.NoContent();
    }

    async Task<IResult> DeleteCarById(int id, ICarRepository repo)
    {
        await repo.DeleteCar(id);
        return Results.NoContent();
    }
}
