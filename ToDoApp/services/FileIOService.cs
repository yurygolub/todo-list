using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using ToDoApp.models;

namespace ToDoApp.services
{
    public class FileIOService
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";

        public BindingList<TodoModel> LoadData()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }

            using var reader = File.OpenText(PATH);
            var fileText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
        }

        public void SaveData(object todoDataList)
        {
            using StreamWriter writer = File.CreateText(PATH);
            string output = JsonConvert.SerializeObject(todoDataList);
            writer.Write(output);
        }
    }
}
