using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models
{
    class DeleteUserModel
    {
        private readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());
        private List<Users> _usersList;

        public DeleteUserModel()
        {
            User[] usersArray = uow.Users.GetAllUsers().ToArray();

            UsersList = new List<Users>();
            foreach (User user in usersArray)
            {
                UsersList.Add(new Users(user.ID, user.Login.ToString()));
            }
        }

        public List<Users> UsersList { get => _usersList; set => _usersList = value; }

        public class Users
        {
            private int _userID;
            private String _userLogin;

            public Users(int id, String login)
            {
                UserID = id;
                UserLogin = login;
            }

            public int UserID { get => _userID; set => _userID = value; }
            public String UserLogin { get => _userLogin; set => _userLogin = value; }
        }

    }
}
