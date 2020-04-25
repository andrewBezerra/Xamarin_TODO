using AsyncAwaitBestPractices.MVVM;
using MvvmHelpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_TODO.Model;

namespace Xamarin_TODO.ViewModel
{
    public class TodoViewModel : BaseViewModel
    {
        string description = string.Empty;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);

        }
        int totaltasks = 0;
        public int TotalTasks
        {
            get => totaltasks;
            set
            {
                SetProperty(ref totaltasks, value);
               
            }

        }
        public TodoViewModel()
        {
          
            TodoTasks = new ObservableCollection<TodoTask>();
            TodoTasks.CollectionChanged += (sender, args) =>
              {
                 
                  TotalTasks = TodoTasks.Count;
              };
            
            AddTodoTask = new AsyncCommand(AddTodo);



        }
        public ObservableCollection<TodoTask> TodoTasks { get; set; }

        public IAsyncCommand AddTodoTask { get; private set; }
                                                         
        async Task AddTodo()
        {
            TodoTasks.Add(new TodoTask() { Description = Description });            
            Description = string.Empty;
        }


    }
}
