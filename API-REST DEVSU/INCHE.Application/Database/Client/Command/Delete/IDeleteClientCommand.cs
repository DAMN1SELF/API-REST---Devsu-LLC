
namespace INCHE.Application.Database.Client.Command.Delete
{
    public interface IDeleteClientCommand
    {
        Task<bool> Execute(int id);
    }
}