namespace JobApp.Shared.Interfaces.Storage
{
    public interface ISQLiteConnectionStringFactory
    {
        string Create(string name);
    }
}