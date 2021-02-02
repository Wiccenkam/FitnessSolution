using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BusinessLogic.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(string name, string GenderName, DateTime date, double weight, double height)
        {
            var gender = new Gender(GenderName);
            User = new User(name, gender, date, weight, height);
            //User = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));

        }
        public void Save()
        {
            var binaryFormatter = new BinaryFormatter();
            using (var filestream = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(filestream, User);
            }
        }
        public UserController()
        {
            var binaryFormatter = new BinaryFormatter();
            using (var filestream = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                if(binaryFormatter.Deserialize(filestream) is User user)
                {
                    User = user;
                }
            }
        }

    }
}
    

    

