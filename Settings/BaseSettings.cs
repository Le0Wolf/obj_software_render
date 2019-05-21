using System;
using System.IO;
using Newtonsoft.Json;

namespace SoftwareRenderer.Settings
{
    public class BaseSettings<T> where T : class, new()
    {
        private static string defaultPath;

        static BaseSettings()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            defaultPath = Path.Combine(appData, "SoftwareRenderer", "settings.json");
        }

        public static T Load(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data); ;
        }

        public static T Load()
        {
            return Load(defaultPath);
        }

        public void Save(string path)
        {
            var data = JsonConvert.SerializeObject(this);
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(path, data);
        }

        public void Save()
        {
            this.Save(defaultPath);
        }
    }
}