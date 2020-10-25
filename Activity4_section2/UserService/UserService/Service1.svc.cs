using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<User> users = new List<User>();
        public Service1()
        {
            List<int> scores1 = new List<int>();
            scores1.Add(99);
            scores1.Add(93);
            scores1.Add(85);
            scores1.Add(92);
            scores1.Add(90);
            User u1 = new User(1, "Crystal", true, 92000, scores1);

            List<int> scores2 = new List<int>();
            scores1.Add(93);
            scores1.Add(93);
            scores1.Add(82);
            scores1.Add(99);
            scores1.Add(98);
            User u2 = new User(2, "Michael", true, 100000, scores2);

            List<int> scores3 = new List<int>();
            scores1.Add(85);
            scores1.Add(90);
            scores1.Add(95);
            scores1.Add(91);
            scores1.Add(93);
            User u3 = new User(3, "Lily", false, 15000, scores3);

            List<int> scores4 = new List<int>();
            scores1.Add(88);
            scores1.Add(87);
            scores1.Add(98);
            scores1.Add(90);
            scores1.Add(85);
            User u4 = new User(4, "Rogan", false, 15000, scores4);

            users.Add(u1);
            users.Add(u2);
            users.Add(u3);
            users.Add(u4);






        }

        public UserDTO GetAllUsers()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.MessageCode = 1;
            userDTO.MessageText = "Everybody is here!";
            userDTO.userList = users;
            return userDTO;
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public UserDTO GetUserById(string id)
        {
            UserDTO userDTO = new UserDTO();
            List<User> returnedUser = new List<User>();

            returnedUser = users.Where(x => x.Id.ToString().Equals(id.ToString())).ToList();
            userDTO.userList = returnedUser;
            userDTO.MessageCode = returnedUser[0].Id;
            userDTO.MessageText = "This is the user who was found by the ID: " + id;
            return userDTO;
        }

        public UserDTO GetUsersByName(string name)
        {
            UserDTO userDTO = new UserDTO();
            List<User> returnThesePeople = users.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            userDTO.userList = returnThesePeople;
            userDTO.MessageCode = returnThesePeople.Count();
            userDTO.MessageText = "These are the people who have : " + name + " in their name";
            return userDTO;
        }
    }
}
