using System.Collections.Generic;

namespace EksamensProjekt3.Managers
{
    public interface IManageUsers
    {
        IEnumerable<User> GetAll();

        User Get(int id);


        bool Create(User user);

        bool Update(int id, User pizza);

        User Delete(int id);

    }
}
