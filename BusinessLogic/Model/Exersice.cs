using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    [Serializable]
    public class Exersice
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Activity Activity { get; set; }
        public User User { get; set;  }
        public Exersice (DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
