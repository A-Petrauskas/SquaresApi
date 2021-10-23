namespace Repositories.Models
{
    public class SquaresDatabaseSettings : ISquaresDatabaseSettings
    {
        public string SquaresCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISquaresDatabaseSettings
    {
        string SquaresCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
