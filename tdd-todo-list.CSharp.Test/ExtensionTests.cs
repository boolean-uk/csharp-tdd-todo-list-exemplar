using tdd_todo_list.CSharp.Main;
using NUnit.Framework;

namespace tdd_todo_list.CSharp.Test
{
    public class ExtensionTests
    {
        private TodoListExtension _extension;
        public ExtensionTests()
        {
            _extension = new TodoListExtension();

            this._extension.createTodo("2 Description");
            this._extension.createTodo("1 Description");
            this._extension.createTodo("0 Description", true);
        }

        [Test]
        public void updateTask()
        {
            Assert.IsTrue(this._extension.updateTodo(0, "Some New Description", true));
            Assert.AreEqual(this._extension.getTodoById(0).id, 0);
            Assert.AreEqual(this._extension.getTodoById(0).description, "Some New Description");
            Assert.AreEqual(this._extension.getTodoById(0).status, true);
        }

        [Test]
        public void dateTimesOfTask()
        {
            Assert.IsNotEmpty(this._extension.getTaskCreatedDate(0).ToString());
        }
    }
}
