namespace Million.Properties.WebApi.Dtos;

public class PropertyDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public string? CodeInternal { get; set; }
    public OwnerDto Owner { get; set; }
    public List<PropertyImageDto> PropertyImages { get; set; }
    public List<PropertyTraceDto> PropertyTraces { get; set; }
}