using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_todo_list.CSharp.Main
{
    public class TodoListExtension
    {
        public TodoListExtension() { this.todoList = new Dictionary<int, TodoExtension>(); }

        public bool createTodo(string description, bool isCompleted = false)
        {
            bool success = false;

            if (description != null)
            {
                success = true;
                int id = this.todoList.Count > 0 ? this.todoList.Last().Key + 1 : 0;
                this.todoList.Add(id, new TodoExtension { id = id, description = description, status = isCompleted });
            }

            return success;
        }

        public bool updateTodo(int id, string newDescription, bool newStatus)
        {
            bool success = false;
            int index = findTodoIndex(id);
            if (index >= 0)
            {
                success = true;

                if (newDescription != null)
                {
                    this.todoList[index].description = newDescription;
                }
                this.todoList[index].status = newStatus;
            }

            return success;
        }

        public bool delete(int id)
        {
            bool success = false;
            int index = findTodoIndex(id);

            if (index >= 0)
            {
                success = this.todoList.Remove(index);
            }

            return success;
        }

        public Dictionary<int, TodoExtension> getAllTodo()
        {
            return this.todoList;
        }

        public Dictionary<int, TodoExtension> getAllTodoAscendingOrder()
        {
            Dictionary<int, TodoExtension> todos = new Dictionary<int, TodoExtension>();
            foreach (var todo in this.todoList.OrderBy(x => x.Key))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Dictionary<int, TodoExtension> getAllTodoDescendingOrder()
        {
            Dictionary<int, TodoExtension> todos = new Dictionary<int, TodoExtension>();
            foreach (var todo in this.todoList.OrderByDescending(x => x.Key))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Dictionary<int, TodoExtension> getAllTodoAlphabeticalAscendingOrder()
        {
            Dictionary<int, TodoExtension> todos = new Dictionary<int, TodoExtension>();
            foreach (var todo in this.todoList.OrderBy(x => x.Value.description))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Dictionary<int, TodoExtension> getAllTodoAlphabeticalDescendingOrder()
        {
            Dictionary<int, TodoExtension> todos = new Dictionary<int, TodoExtension>();
            foreach (var todo in this.todoList.OrderByDescending(x => x.Value.description))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public TodoExtension? getTodoById(int id)
        {
            int index = findTodoIndex(id);
            if (index >= 0)
            {
                return this.todoList[index];
            }
            return null;
        }

        public Dictionary<int, TodoExtension> getCompletedTodos()
        {
            Dictionary<int, TodoExtension> todos = new Dictionary<int, TodoExtension>();

            for (int i = 0; i < this.todoList.Count; i++)
            {
                if (this.todoList[i].status == true)
                {
                    todos.Add(i, this.todoList[i]);
                }
            }

            return todos;
        }

        public Dictionary<int, TodoExtension> getNotCompletedTodos()
        {
            Dictionary<int, TodoExtension> todos = new Dictionary<int, TodoExtension>();

            for (int i = 0; i < this.todoList.Count; i++)
            {
                if (this.todoList[i].status == false)
                {
                    todos.Add(i, this.todoList[i]);
                }
            }

            return todos;
        }

        public DateTime getTaskCreatedDate(int id)
        {
            DateTime createdAt = new DateTime();
            int index = findTodoIndex(id);
            if(index >= 0)
            {
                createdAt = this.todoList[index].created;
            }
            return createdAt;
        }

        private Dictionary<int, TodoExtension> todoList;

        private int findTodoIndex(int id)
        {
            int index = -1;
            for (int i = 0; i < this.todoList.Count; i++)
            {
                if (this.todoList[i].id == id)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }

    public class TodoExtension
    {
        public TodoExtension() { this._description = ""; this._status = false; this._created = DateTime.Now; this._updated = DateTime.Now; }
        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string description
        {
            get { return this._description; }
            set { this._description = value; this._updated = DateTime.Now; }
        }

        public bool status
        {
            get { return this._status; }
            set { this._status = value; this._updated = DateTime.Now; }
        }

        public DateTime created
        {
            get { return this._created; }
            set { this._created = value; }
        }

        public DateTime updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        private int _id;
        private string _description;
        private bool _status;

        private DateTime _created;
        private DateTime _updated;
    }

}
