using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic.Controller
{
    
    public class ExersiceController: BaseController
    {
        const string Exersices_File_Name = "Exersices.dat";
        const string Activity_File_Name = "Activity.dat";

        private readonly User User;
        public List<Exersice> Exersices { get; }
        public List<Activity> Activities { get; }
        public ExersiceController(User User)
        {
            this.User = User ?? throw new ArgumentException(nameof(User));
            Exersices = GetAllExetsices();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(Activity_File_Name) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime start, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exersice = new Exersice(start,end,activity,User);
                Exersices.Add(exersice);
            }
            else
            {
                var exersice = new Exersice(start, end, act, User);
                Exersices.Add(exersice);
            }
            Save();
            
        }
        private List<Exersice> GetAllExetsices()
        {
            return Load<List<Exersice>>(Exersices_File_Name) ?? new List<Exersice>();
        }
        private void Save()
        {
            Save(Exersices_File_Name, Exersices);
            Save(Activity_File_Name, Activities);
        }
    }
}
