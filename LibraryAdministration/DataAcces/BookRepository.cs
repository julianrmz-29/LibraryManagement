using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAdministration.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryAdministration.DataAcces
{
    public class BookRepository
    {
        private List<BookModel> _books;

        public BookRepository()
        {
            _books = new List<BookModel>();
        }


        public void AddBookRepository(string title, string author, int publicationYear)
        {
            BookModel newBook = new BookModel();
            newBook.Title = title;
            newBook.Author = author;
            newBook.PublicationYear = publicationYear;
            _books.Add(newBook);
            Console.WriteLine(" Book added successfully.");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
        }

        public void ShowBooksRepository()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("There are no books in the library.");
                return;
            }

            Console.WriteLine($"\n=== LIST OF BOOKS ===");
            Console.WriteLine("{0, -5} {1, -20} {2, -20} {3, -10}", "No.", "Title", "Author", "Year");
            Console.WriteLine(new string('-', 60));

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -20} {3, -10}",
                    i + 1,
                    _books[i].Title,
                    _books[i].Author,
                    _books[i].PublicationYear);
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
        }

        public void SearchBooksByTitleRepository(string searchTitle)
        {
            var foundBooks = _books.Where(book =>
                book.Title.ToLower().Contains(searchTitle.ToLower())).ToList();

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No books were found with the title '{searchTitle}'.");
                return;
            }

            Console.WriteLine($"\n=== SEARCH RESULTS: '{searchTitle}' ===");
            Console.WriteLine("{0, -5} {1, -20} {2, -20} {3, -10}", "No.", "Title", "Author", "PublicationYear");
            Console.WriteLine(new string('-', 60));
            for (int i = 0; i < foundBooks.Count; i++)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -20} {3, -10}",
                   i + 1,
                   foundBooks[i].Title,
                   foundBooks[i].Author,
                   foundBooks[i].PublicationYear);
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
        }

        public void DeleteBookRepository(int id)
        {
            if (id < 1 || id > _books.Count)
            {
                Console.WriteLine("Invalid index. Please select a valid number.");
                return;
            }

            BookModel deleteBook = _books[id - 1];
            _books.RemoveAt(id - 1);
            Console.WriteLine($"Book: '{deleteBook.Title}' successfully removed.");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
        }

        public int QuantityBooksRepository()
        {
            return _books.Count;
        }
    }
}
