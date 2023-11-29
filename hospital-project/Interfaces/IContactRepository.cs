using hospital_project.Models;

namespace hospital_project.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        bool Add(Contact contact);

        bool Save();

    }
}
