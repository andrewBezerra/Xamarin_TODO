using AsyncAwaitBestPractices.MVVM;
using MvvmHelpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin_TODO.Model;

namespace Xamarin_TODO.ViewModel
{
    public class TodoViewModel : BaseViewModel
    {
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }
        public TodoViewModel()
        {
            Title = "Tasks";
            TodoTasks = new ObservableCollection<TodoTask>();
            TodoTasks.CollectionChanged += (sender, args) =>
              {
                  Title = $"Tasks ({TodoTasks.Count})";
              };
            AddTodoTask = new AsyncCommand(AddTodo);
           
        }
        public ObservableCollection<TodoTask> TodoTasks { get; set; }

        public IAsyncCommand AddTodoTask { get; private set; }

        async Task AddTodo()
        {
            await Task.Run(() => { 
                TodoTasks.Add(new TodoTask() { Description = Description });
            });
        }


    }
}
