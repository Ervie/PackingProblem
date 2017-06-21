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

		public static bool DirectoryExist(string path)
		{
			path = Path.GetPathRoot(path);

			return (Directory.Exists(path));
		}

		public static bool FileExist(string path)
		{
			return (File.Exists(path));
		}

		public static bool HasAccessPermission(string path)
		{
			try
			{
				path = Path.GetPathRoot(path);

				System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(path);
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
			catch (ArgumentException)
			{
				return false;
			}

			return true;
		}

		public static void CreateNewFile(string filePath)
		{
			if (HasAccessPermission(filePath))
				File.Create(filePath).Close();
		}
    }
}
