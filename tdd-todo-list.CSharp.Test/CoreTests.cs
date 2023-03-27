using tdd_todo_list.CSharp.Main;
using NUnit.Framework;

namespace tdd_todo_list.CSharp.Test
{
    public class CoreTests
    {
        TodoList _core;
        public CoreTests()
        {
            this._core = new TodoList();

            this._core.createTodo("2 Description");
            this._core.createTodo("1 Description");
            this._core.createTodo("0 Description", true);
        }

        // test getAll
        [Test]
        public void getAll()
        {
            Assert.AreEqual(this._core.getAllTodo()[0].id, 0);
            Assert.AreEqual(this._core.getAllTodo()[1].id, 1);
            Assert.AreEqual(this._core.getAllTodo()[2].id, 2);
        }
        // test getById
        [Test]
        public void getById()
        {
            Assert.NotNull(_core.getTodoById(1));
            Assert.AreEqual(this._core.getTodoById(0).description, "2 Description");
            Assert.AreEqual(this._core.getTodoById(0).id, 0);
        }
        // test getCompleted
        [Test]
        public void getCompletedTodos()
        {
            Assert.AreEqual(this._core.getCompletedTodos().Count, 1);
        }
        // test getIncompleted
        [Test]
        public void getNotCompletedTodos()
        {
            Assert.AreEqual(this._core.getCompletedTodos().Count, 1);
        }

        [Test]
        public void getAllAscending()
        {
            Assert.AreEqual(this._core.getAllTodoAscendingOrder().First().Key, 0);
            Assert.AreEqual(this._core.getAllTodoAscendingOrder().Last().Key, 2);
        }

        [Test]
        public void getAllDescending()
        {
            Assert.AreEqual(this._core.getAllTodoDescendingOrder().First().Key, 2);
            Assert.AreEqual(this._core.getAllTodoDescendingOrder().Last().Key, 0);
        }

        [Test]
        public void getAllAscendingAlphabetical()
        {
            Assert.AreEqual(this._core.getAllTodoAlphabeticalAscendingOrder().First().Key, 2);
            Assert.AreEqual(this._core.getAllTodoAlphabeticalAscendingOrder().Last().Key, 0);
        }

        [Test]
        public void getAllDescendingAlphabetical()
        {
            Assert.AreEqual(this._core.getAllTodoAlphabeticalDescendingOrder().First().Key, 0);
            Assert.AreEqual(this._core.getAllTodoAlphabeticalDescendingOrder().Last().Key, 2);
        }

        // test create
        [Test]
        public void createTask()
        {
            Assert.IsTrue(this._core.createTodo("3 Description"));
        }

        [Test]
        public void deleteTodo()
        {
            Assert.IsTrue(this._core.delete(3));
        }
    }
}