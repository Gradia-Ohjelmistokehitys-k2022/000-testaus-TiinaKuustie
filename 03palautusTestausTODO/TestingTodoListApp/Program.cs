using System.Collections.Generic;
using System.Linq;
using TestingTodoListApp;

namespace TodoListNS
{

    /// <summary>
    /// Todo list. You can inserts things to do. Delete them. Complete them.
    /// </summary>
    public class Program
    {

        public static void Main()
        {
            /*TodoList todoList = new ();
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Wash your clothes", "by Friday");
            var list = todoList.All; //for iterations
            foreach (var item in list)
            {
                string status = "Incomplete";
                if (item.IsCompleted == true) { status = "Completed"; }
                Console.WriteLine($"item is: {item.Id} '{item.TaskDescription}' status: {status}");
            }

            Console.WriteLine("\n\n");


         
            try
            {
                todoList.RemoveItemFromList("1");
            }
            catch (Exception ex) { Console.WriteLine("Viesti on " + ex.Message); }

            foreach (var item in list)
            {
                string status = "Incomplete";
                if (item.IsCompleted == true) { status = "Completed"; }
                Console.WriteLine($"item is: {item.Id} '{item.TaskDescription}' status: {status}");
            }

          int ID =  todoList.GetIdByDesc("Wash your clothes");
            Console.WriteLine(ID.ToString());

           /* foreach (var item in anotherList)
            {
                Console.WriteLine(item);
            }*/

           
            TodoList todoList = new();
            todoList.AddItemToList("Wash your clothes", "by Friday");
            todoList.AddItemToList("Take the trash out", "by tomorrow");
            todoList.AddItemToList("Buy groceries", "tomorrow");
            var list = todoList.All; //for iterations
            foreach (var item in list)
            {
                string status = "Incomplete";
                if (item.IsCompleted == true) { status = "Completed"; }
                Console.WriteLine($"item is: {item.Id} '{item.TaskDescription}' status: {status}");
            }

            Console.WriteLine("\n\n");

            try
            {
               

                todoList.RemoveItemFromList("Wash your clothes");
                todoList.RemoveItemFromList("2"); //ID ei indeksi
                todoList.RemoveItemFromList("3");
            
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
            foreach (var item in list)
            {
                string status = "Incomplete";
                if (item.IsCompleted == true) { status = "Completed"; }
                Console.WriteLine($"item is: {item.Id} '{item.TaskDescription}' status: {status}");
            }

            Console.WriteLine("\n\n");

        }

    }
}
