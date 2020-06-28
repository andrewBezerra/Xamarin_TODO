using MvvmHelpers;
using System;

namespace Xamarin_TODO.Model
{
    public class TodoTask : ObservableObject
    {
        Guid id;
        public Guid ID
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
            }
        }
        string description;
        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }
        bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                SetProperty(ref done, value);
            }
        } 

        public TodoTask()
        {
            id = Guid.NewGuid();
            done = false;
        }
    }
}