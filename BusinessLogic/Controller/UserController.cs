using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BusinessLogic.Controller
{
    public class UserController: BaseController
    {
        private  const string User_File_Name = "User.dat";
        public List<User> Users { get; }
        public User CurrentUSer { get; }
        public bool NewUSer { get; } = false;
        public UserController(string UserName)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                throw new ArgumentNullException("User name cannot be null or empty", nameof(UserName));
            }

            Users = GetUsersData();

            CurrentUSer = Users.SingleOrDefault(user => user.Name == UserName);

            if (CurrentUSer == null)
            {
                CurrentUSer = new User(UserName);
                Users.Add(CurrentUSer);
                NewUSer = true;
                Save();
            }

        }
        /// <summary>
        /// Save User List
        /// </summary>
        public void Save()
        {
            Save(User_File_Name, Users);
            /*var binaryFormatter = new BinaryFormatter();
            using (var filestream = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(filestream, Users);
            }*/
        }
        public void SetNewUserData(string gender, DateTime BirthDay, double weight=1, double height=1)
        {
            if (NewUSer)
            {
                CurrentUSer.Gender = new Gender(gender);
                CurrentUSer.BithDay = BirthDay;
                CurrentUSer.Weight = weight;
                CurrentUSer.Height = height;
                Save();
            }
        } 
        /// <summary>
        /// Retrieve Saved User List
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(User_File_Name)?? new List<User>();
            /*
            var binaryFormatter = new BinaryFormatter();
            using (var filestream = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                if (filestream == null)
                {
                    return new List<User>();
                }
                if (filestream.Length>0 && binaryFormatter.Deserialize(filestream) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }*/
           
        }

    }
}
    

    

