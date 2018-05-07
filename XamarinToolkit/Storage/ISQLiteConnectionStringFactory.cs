namespace JobApp.Interfaces
{
    public interface ISQLiteConnectionStringFactory
    {
        string Create(string name);
    }
}