using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book> 
    {

        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books.OrderBy(x =>x , new BookComparator()).ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public class LibraryIterator : IEnumerator<Book>
        {
            int index = -1;
            private List<Book> books;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }
            public Book Current => books[index];

            object IEnumerator.Current => books[index];


            public bool MoveNext()
            {
                index++; 
                return index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
            public void Dispose()
            {
                
            }
        }
    }
}
