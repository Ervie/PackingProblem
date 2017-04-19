using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utilities.Files
{
    public static class FileHelper
    {
        public static void Save<T>(File<T> file)
        {
            using (Stream stream = File.Open(file.Path, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, file.Content);
            }
        }

        public static File<T> Load<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                var file = new File<T>
                {
                    Path = filePath,
                    Content = (T)bformatter.Deserialize(stream)
                };

                return file;
            }
        }
    }
}
