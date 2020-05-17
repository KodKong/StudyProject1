using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Работа7
{
    
    public struct Note
    {
        // открытые поля класса 
        internal string Name, Surname, Phone, DataBirsday;
        
        
        // конструктор с параметрами 
        public Note (string Name, string Surname, string Phone, string DataBirsday)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Phone = Phone;
            this.DataBirsday = DataBirsday; 


        }
    }

    // Определение базового класса (содержит коллекцию книг)
    public abstract class BaseNotes
    {
        protected List<Note> notes = new List<Note>(); 

        //конструктор класса 
        public BaseNotes()
        {
            notes.Add(new Note("Роман", "Музафаров", "+79126537694", "22.06.01"));
            notes.Add(new Note("Владимир", "Предеин", "+79127648040", "11.10.01"));
            notes.Add(new Note("Павел", "Гатин", "+79456237910", "27.01.97"));
            notes.Add(new Note("Игорь", "Стремилов", "+79638527640", "15.04.88"));
            notes.Add(new Note("Анна", "Садчикова", "+79638563980", "03.04.07"));
        }

        public string[] GetList()
        {
            string[] ArrStr = new string[notes.Count];
            for (int i = 0; i < notes.Count; i++)
                ArrStr[i] = notes[i].Name + ", " + notes[i].Surname + ", " + notes[i].Phone + ", " + notes[i].DataBirsday;
            return ArrStr; 
        }

        public void ClearList ()
        {
            notes.Clear(); 
        }
    }

    public class WorkNotes : BaseNotes
    {       
        public void RemNotes(int n)
        {
            notes.RemoveAt(n); 
        }
        public void AddNotes (string t, string a, string y, string z)
        {
            notes.Add(new Note(t, a, y, z));
            
        }
        public string[] GetNoteby(Comparison<Note> compare)
        {
            notes.Sort(compare);
            return GetList(); 
        }
    }

    public class MyIComparerData : IComparer<Note>
    {
        public int Compare(Note a, Note b)
        {
            return String.Compare(a.DataBirsday.Substring(3), b.DataBirsday.Substring(3));
        }    
    }
    public class MyIComparerName : IComparer<Note>
    {
        public int Compare(Note a, Note b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }
    public class MyIComparerSurname : IComparer<Note>
    {
        public int Compare(Note a, Note b)
        {
            return String.Compare(a.Surname, b.Surname);
        }
    }
    

}
