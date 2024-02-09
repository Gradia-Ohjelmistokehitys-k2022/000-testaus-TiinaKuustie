using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingTodoListApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

//  Assert.ThrowsException<System.ArgumentException>(() => todoList.AddItemToList(new TodoTask("Take the trash out")));
namespace TestingTodoListApp.Tests
{
    [TestClass()]
    public class TodoListTests
    {


        [TestMethod()]
        public void AddItemToListTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");


        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddItemToListAlreadyInListTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Take the trash out", "by tomorrow");

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddItemToListOnlyNumbersTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("125874", "joskus");
        }

        [TestMethod()]
        public void RemoveItemFromListTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Wash your clothes", "by Friday");
            todoList.RemoveItemFromList("Wash your clothes");
        }

        [TestMethod()]
        public void RemoveItemFromListSeveralItemsTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Wash your clothes", "by Friday");
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Buy groceries", "tomorrow");

            todoList.RemoveItemFromList("Wash your clothes");
            todoList.RemoveItemFromList("2"); //ID ei indeksi
            todoList.RemoveItemFromList("3");
        }

        [TestMethod()]
        public void RemoveItemFromListLastItemTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Wash your clothes", "by Friday");
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Buy groceries", "tomorrow");
        
            todoList.RemoveLastItemFromList();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveItemFromListNotExistingIndexTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Wash your clothes", "by Friday");
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Buy groceries", "tomorrow");

            todoList.RemoveItemFromList("13");
        }
    


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveItemFromListNotOnListTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");

            todoList.RemoveItemFromList("Wash your clothes");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveItemFromListEmptyListTest()
        {
            TodoList todoList = new();


            todoList.RemoveItemFromList("Wash your clothes");
        }

        [TestMethod()]
        public void RemoveItemFromListByIdTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Wash your clothes", "by Friday");

            todoList.RemoveItemFromList("1");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveItemByIdwithSpaceTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Wash your clothes", "by Friday");

            todoList.RemoveItemFromList("1 ");
        }
        [TestMethod()]
      
        public void CompletedItemTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Wash your clothes", "by Friday");

            todoList.CompletedItem("Wash your clothes");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CompletedItemNotExistingIndexTest()
        {
            TodoList todoList = new();
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Wash your clothes", "by Friday");

            todoList.CompletedItem("13");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CompletedItemNoItemsInListTest()
        {
            TodoList todoList = new();
          

            todoList.CompletedItem("1");
        }

    }
}