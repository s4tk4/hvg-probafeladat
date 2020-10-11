using proba.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace proba.Repositories
{
    public class dblayer
    {
        #region private
        private static dblayer Instance;

        private dblayer()
        {
            var title = ConfigurationManager.AppSettings["title"];
            var language = ConfigurationManager.AppSettings["language"];
        }
        #endregion
        #region public 
        public static dblayer ME { get { if (Instance == null) { Instance = new dblayer(); } return Instance; } }

        public void InsertNewItem(object data, string v)
        {
            string dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            AppendJSONDataFile(dataJson, v);
        }

        public T GetItems<T>(string tablename) where T : class, new()
        {
            var obj = ReadJSONDataFile(tablename);
            T resultData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(obj);

            return resultData;
        }
        #endregion

        #region private
        private string ReadJSONDataFile(string fileName)
        {
            string dbdatafolder=  ConfigurationManager.AppSettings["dbdatafolder"];
            string path = Path.Combine(dbdatafolder, fileName);
            if(!Directory.Exists(dbdatafolder))
            {
                Directory.CreateDirectory(dbdatafolder);
            }
            
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using(StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }

        }

        private void AppendJSONDataFile(string data, string fileName)
        {
            string dbdatafolder = ConfigurationManager.AppSettings["dbdatafolder"];
            string path = Path.Combine(dbdatafolder, fileName);
            if (!Directory.Exists(dbdatafolder))
            {
                Directory.CreateDirectory(dbdatafolder);
            }

            if (!File.Exists(path))
            {
                using (File.Create(path)) { } 
            }
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                sw.WriteLine(data);
            }
        }
        #endregion
    }
}