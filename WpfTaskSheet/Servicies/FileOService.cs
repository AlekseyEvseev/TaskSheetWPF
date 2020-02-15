using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using WpfTaskSheet.Model;

namespace WpfTaskSheet.Servicies
{
    class FileOService
    {
        private readonly string PATH;

        public FileOService(string path)
        {
            PATH = path;
        }
        public BindingList<TodoModel> LoadData()
        {
            var fileExist =File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList < TodoModel >>(fileText);
            }
        }
        public void SaveData(BindingList<TodoModel> todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);                
            }  
        }
    }
}
