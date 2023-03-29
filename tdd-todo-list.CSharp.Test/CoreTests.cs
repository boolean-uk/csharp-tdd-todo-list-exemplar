using NUnit.Framework;
using System.Threading.Tasks;
using tdd_todo_list.CSharp.Main;

namespace tdd_todo_list.CSharp.Test
{
    public class CoreTests
    {
        private TodoList _todoList;
        public CoreTests()
        {
            _todoList = new TodoList();

            _todoList.AddTask(new TodoListItem() { Id = 1, Description = "Make Bed", IsCompleted = false });
            _todoList.AddTask(new TodoListItem() { Id = 2, Description = "Clean Kitchen", IsCompleted = false });
        }

        [Test]
        public void AddItemTest()
        {
            _todoList.AddTask(new TodoListItem() { Id = 3, Description = "Mow the lawn", IsCompleted = false });

            Assert.IsTrue(_todoList.GetAllTasks.Exists(x => x.Id == 3));
        }
        [Test]
        public void ChangeIsCompleteTest()
        {
            _todoList.SetTaskAs(1, true);
            var task = _todoList.GetCompleteTasks.Where(i => i.Id == 1).SingleOrDefault();
            if (task != null)
            {
                Assert.IsTrue(task.IsCompleted == true);
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void TestOnlyComplete()
        {
            _todoList.GetCompleteTasks.ForEach(x =>
            {
                Assert.IsTrue(x.IsCompleted);

            });
        }
        [Test]
        public void TestOnlyInComplete()
        {
            _todoList.GetInCompleteTasks.ForEach(x =>
            {
                Assert.IsFalse(x.IsCompleted);

            });
        }
        [TestCase(3, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(10, false)]
        public void DoesTaskExist(int id, bool expected)
        {
            Assert.IsTrue(_todoList.FindTask(id,out TodoListItem item) == expected);
            if(expected)
            {
                Assert.IsNotNull(item);
            }
            else
            {
                Assert.IsNull(item);
            }
        }

    }
}