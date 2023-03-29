using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_todo_list.CSharp.Main
{
    public class TodoList
    {
        private List<TodoListItem> _tasks;
        public TodoList()
        {
            _tasks = new List<TodoListItem>();
        }
        public List<TodoListItem> GetAllTasks { get { return _tasks; } }
        public List<TodoListItem> GetCompleteTasks { get { return _tasks.Where(x => x.IsCompleted == true).ToList();  } }
        public List<TodoListItem> GetInCompleteTasks { get { return _tasks.Where(x => x.IsCompleted == false).ToList(); } }
        public void AddTask(TodoListItem item)
        {
            _tasks.Add(item);
        }
        public void DeleteTask(int id)
        {
            var taskToDelete = _tasks.Single(r => r.Id == 2);
            _tasks.Remove(taskToDelete);
        }
        public void SetTaskAs(int id, bool isComplete)
        {
            var task = _tasks.Where(i => i.Id==id).SingleOrDefault();
            if (task != null)
            {
                task.IsCompleted = isComplete;
            }
        }
        public bool FindTask(int id, out TodoListItem item)
        {            
            if (_tasks.Exists(x => x.Id==id))
            {
                item = _tasks.Where(i => i.Id == id).SingleOrDefault();
                return true;
            }
            item = null;
            return false;            
        }
    }
    public class TodoListItem
    {            
            public int Id { get; set; }
            public string Description { get; set; }
            public bool IsCompleted { get; set; }
    }
}
