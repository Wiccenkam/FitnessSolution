using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of gender cannot be null or empty");
            }
            Name = name;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
