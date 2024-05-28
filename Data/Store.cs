namespace LibCarter.Data;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Car> Cars { get; set; }
}
