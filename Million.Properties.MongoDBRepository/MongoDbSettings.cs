namespace Million.Properties.MongoDBRepository;

public class MongoDbSettings
{
    public required string ConnectionString { get; set; }
    public string TtlTimeSpan { get; set; } = TimeSpan.MaxValue.ToString();
}
