using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestingTodoListApp
{
    public class TodoTask // ota selvää recordin toiminnasta -done muutin tän olentoclassiksi ohjeiden ehdotuksen mukaan ensin leikittyäni recordilla
    {
        public string TaskDescription { get; set; } //lisäsin tämän itse, mut records allow all parameters to be saved, even if there is no field for them
        public int Id { get; set; }//init makes property immutable which means you cannot change value with set afterwards.
        public bool IsCompleted { get; set; }

        public string ToDoBy { get; set; } //käyttäjä voi tähän itse specifioida sanallisesti, ei välttis datetime sovellu, esim. 'ennen talvea'

      
       public TodoTask(int ID, string task, bool completed, string todoby)
        {
            TaskDescription = task;
            Id = ID;
            IsCompleted = completed;
            ToDoBy = todoby;
        }
        public override string ToString()
        {
            return $"Id: {Id} + Task: {TaskDescription} + Did you do it?: {IsCompleted}";
        }
    }

}





