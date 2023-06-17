using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        string title;
        int year;
        List<string> autors;
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Autors { get; set; }
        public Book(string title, int year, params string[] autors)
        {
            Title = title;
            Year = year;
            Autors = autors.ToList();

        }

        public int CompareTo(Book other)
        {
            int result = this.year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.title.CompareTo(other.Title);
            }
            return result;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
