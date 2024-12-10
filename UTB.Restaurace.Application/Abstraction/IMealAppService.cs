using UTB.Restaurace.Domain.Entities;
namespace UTB.Restaurace.Application.Abstraction
{
    public interface IMealAppService
    {
        IList<Meal> Select();
        void Create(Meal meal);
        bool Delete(int id);
    }
}