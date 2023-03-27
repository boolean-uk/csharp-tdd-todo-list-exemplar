using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tdd_todo_list.CSharp.Main
{
    public class TodoList
    {
        public TodoList() { this.todoList = new Dictionary<int, Todo>(); }

        public bool createTodo(string description, bool isCompleted = false)
        {
            bool success = false;

            if(description != null)
            {
                success = true;
                int id = this.todoList.Count > 0 ? this.todoList.Last().Key + 1 : 0;
                this.todoList.Add(id, new Todo { id = id, description = description, status = isCompleted });
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

        public Dictionary<int, Todo> getAllTodo()
        {
            return this.todoList;
        }

        public Dictionary<int, Todo> getAllTodoAscendingOrder()
        {
            Dictionary<int, Todo> todos = new Dictionary<int, Todo>();
            foreach (var todo in this.todoList.OrderBy(x => x.Key))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Dictionary<int, Todo> getAllTodoDescendingOrder()
        {
            Dictionary<int, Todo> todos = new Dictionary<int, Todo>();
            foreach (var todo in this.todoList.OrderByDescending(x => x.Key)) {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Dictionary<int, Todo> getAllTodoAlphabeticalAscendingOrder()
        {
            Dictionary<int, Todo> todos = new Dictionary<int, Todo>();
            foreach (var todo in this.todoList.OrderBy(x => x.Value.description))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Dictionary<int, Todo> getAllTodoAlphabeticalDescendingOrder()
        {
            Dictionary<int, Todo> todos = new Dictionary<int, Todo>();
            foreach (var todo in this.todoList.OrderByDescending(x => x.Value.description))
            {
                todos.Add(todo.Key, todo.Value);
            }
            return todos;
        }

        public Todo? getTodoById(int id)
        {
            int index = findTodoIndex(id);
            if(index >= 0)
            {
                return this.todoList[index];
            }
            return null;
        }

        public Dictionary<int, Todo> getCompletedTodos()
        {
            Dictionary<int, Todo> todos = new Dictionary<int, Todo>();

            for (int i = 0; i < this.todoList.Count; i++)
            {
                if (this.todoList[i].status == true)
                {
                    todos.Add(i, this.todoList[i]);
                }
            }

            return todos;
        }

        public Dictionary<int, Todo> getNotCompletedTodos()
        {
            Dictionary<int, Todo> todos = new Dictionary<int, Todo>();

            for (int i = 0; i < this.todoList.Count; i++)
            {
                if (this.todoList[i].status == false)
                {
                    todos.Add(i, this.todoList[i]);
                }
            }

            return todos;
        }

        private Dictionary<int, Todo> todoList;

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

    public class Todo
    {
        public Todo() { this._description = "";  this._status = false; }
        public int id { 
            get { return this._id; }
            set { this._id = value; }
        }

        public string description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public bool status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        private int _id;
        private string _description;
        private bool _status;
    }

}
