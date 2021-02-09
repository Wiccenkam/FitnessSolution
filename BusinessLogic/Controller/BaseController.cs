using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BusinessLogic.Controller
{
    public abstract class BaseController
    {
        
        protected void Save(string FileName, object item)
        {
            var binaryFormatter = new BinaryFormatter();

            using (var filestream = new FileStream(FileName,FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(filestream, item);
            }

        }
        protected T Load<T>(string FileName)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var filestream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                
                if (filestream.Length > 0 && binaryFormatter.Deserialize(filestream) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

    }
}
