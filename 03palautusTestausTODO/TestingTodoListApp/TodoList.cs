using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestingTodoListApp
{
    public class TodoList
    {

        private readonly List<TodoTask> _tasks;
        private int _taskCounter = 0;
        public int UnfinishedTasks = 0;
        public IEnumerable<TodoTask> All => _TodoItems; //https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all?view=net-6.0
        public List<TodoTask> _TodoItems { get => _tasks; }

        /// <summary>
        /// Each time new todolist is created. New list of tasks is created.
        /// </summary>
        public TodoList()
        {
            _tasks = new List<TodoTask>();
            //string defaultTask = $"Task number {_taskCounter}"; // remove
            //TodoTask item = new(defaultTask);
        }
        public void AddItemToList(string description,string dueby)
        {
           
           // TodoTask testi = _tasks.Find(obj => obj.TaskDescription == item);
           bool listassa = false;

            if (Regex.IsMatch(description, @"^[0-9]+$") == true)
            {
                throw new System.ArgumentException("Syötit pelkkiä numeroita");
            }

                foreach (TodoTask obj in _tasks)
            {
               // Console.WriteLine("item " + item.TaskDescription + " " + obj.TaskDescription);
                if(obj.TaskDescription == description)
                {
                    Console.WriteLine($"'{obj.TaskDescription}' tehtävä on jo listassa");
                    listassa = true;
                    throw new System.ArgumentException("Tämä tehtävä on jo listassa");
                   
                }
            }
            if (listassa == false)
            {
                _taskCounter++;
                UnfinishedTasks++;
                TodoTask item = new(_taskCounter,description,false,dueby);
                _tasks.Add(item); //   _tasks.Add(item with { Id = _taskCounter });  with is used with immutable records. The old method of creating an object and then adding that to a list works too. With is more consise
            }
        }

        public void RemoveItemFromList(string description)
        {
            if (_tasks.Count > 0) //no onks meil ylipäänsä tehtäviä listassa
            {
                bool listassa = false;
                TodoTask objectx = _tasks[0];
                string descriptionx = description;

                if (Regex.IsMatch(description, @"^[0-9]+$") == true) //on numero
                {
                    int listanIndex = Convert.ToInt32(description);
                    Console.WriteLine($"Index: {listanIndex} Desc: {description} Tasks count {_tasks.Count}");


                    bool listalla = false;
                    foreach (TodoTask obj in _tasks)
                    {
                        Console.WriteLine($" Vertailu listassa: {obj.TaskDescription} sisään: {description}");
                        if (obj.Id == Convert.ToInt32(description))
                        {
                            listalla = true;
                        }

                    }
                    if (listalla == true)
                    {
                        descriptionx = GetDescById(Convert.ToInt32(description));
                    }
                  
                    
                    else
                    {
                        throw new System.ArgumentOutOfRangeException("Ei löydy listalta");
                    }
                  

                }
                else if (Regex.IsMatch(description, @"^[0-9]+$") == false)
                {
                    descriptionx = description;
                }
                else if (string.IsNullOrWhiteSpace(description))
                {
                    throw new System.ArgumentException($"Tyhjä syöte");
                }

                foreach (TodoTask item in _tasks)
                {
                    //Console.WriteLine($" Vertailu listassa: {item.TaskDescription} sisään: {description}");
                    if (item.TaskDescription == descriptionx)
                    {
                        objectx = item; // _tasks.Remove(item with { Id = _taskCounter-- }); eikös tää nyt aiheuta sen, ett seuraaval taskil on sama id ku viimestäedellisellä?
                        listassa = true;
                    }

                }
                if (listassa == false)
                {
                    throw new System.ArgumentException($"Tehtävää '{descriptionx}' ei ole listassa");
                }
                else
                {
                    UnfinishedTasks--;
                    _tasks.Remove(objectx); //ei voi muuttaa listaa kesken listan iteroinnin
                }
            }
            else { throw new ArgumentOutOfRangeException(); } //ei jäseniä listassa
           
        }
        public void CompletedItem(string indicator) //mark as completed, do not remove from list, indicator is either number or description
        {
            if (_tasks.Count > 0) //no onks meil ylipäänsä tehtäviä listassa
            {

                if (Regex.IsMatch(indicator, @"^[0-9]+$") == true) //on numero
                {


                    bool listalla = false;
                    foreach (TodoTask obj in _tasks)
                    {
                        //Console.WriteLine($" Vertailu listassa: {item.TaskDescription} sisään: {description}");
                        if (obj.Id == Convert.ToInt32(indicator))
                        {
                            listalla = true;
                        }

                    }
                    if (listalla == true)
                    {
                        UnfinishedTasks--;
                        var item = _tasks.First(x => x.Id == Convert.ToInt32(indicator));
                        item.IsCompleted = true;
                    }
                    else { throw new ArgumentOutOfRangeException($"{indicator} ei ole listalla"); } //ei ole listassa
                }
                else if (!string.IsNullOrWhiteSpace(indicator))
                {
                    bool listalla = false;
                    foreach (TodoTask obj in _tasks)
                    {
                        //Console.WriteLine($" Vertailu listassa: {item.TaskDescription} sisään: {description}");
                        if (obj.TaskDescription == indicator)
                        {
                            listalla = true;
                        }

                    }
                    if (listalla == true)
                    {
                        UnfinishedTasks--;
                        var item = _tasks.First(x => x.TaskDescription == indicator);
                        item.IsCompleted = true;
                    }
                } //else if
                else { throw new System.ArgumentException($"Tyhjä syöte"); }
            }
            else { throw new System.ArgumentOutOfRangeException($"Lista on tyhjä"); }

        }
      public void  RemoveLastItemFromList()
        {
            RemoveItemFromList(_taskCounter.ToString());
            _taskCounter--;
        }
        public int GetIdByDesc(string description)
        {

            var item = _tasks.First(x => x.TaskDescription == description);
            return item.Id;
        }
        public string GetDescById(int id) 
        {
           
            var item = _tasks.First(x => x.Id == id);
           return item.TaskDescription;
        }
    }
}
