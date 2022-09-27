using System;
using System.ComponentModel;
using System.Windows;
using ToDoApp.models;
using ToDoApp.services;

namespace ToDoApp.viewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        private readonly FileIOService fileIOService = new FileIOService();
        private BindingList<TodoModel> todoDataList;

        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<TodoModel> TodoDataList
        {
            get => todoDataList;
            set
            {
                if (todoDataList == value)
                {
                    return;
                }

                todoDataList = value;
                OnPropertyChanged(nameof(TodoDataList));
            }
        }

        public void Load()
        {
            try
            {
                TodoDataList = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TodoDataList.ListChanged += TodoDataList_ListChanged;
        }

        private void TodoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
