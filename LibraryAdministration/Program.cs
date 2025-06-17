using LibraryAdministration.DataAcces;

BookRepository bookRepository = new BookRepository();
bool keep = true;


Console.WriteLine("===================================================");
Console.WriteLine("==== Hello, Welcome to lLibrary Administration ====");
Console.WriteLine("===================================================");


Console.WriteLine();
Console.WriteLine("===================================================");
Console.WriteLine("====================   MENU  ======================");
Console.WriteLine("===================================================");

Console.WriteLine();

while (keep)
{
    Console.WriteLine("OPTIONS: (Press the number to select the option) ");
    Console.WriteLine("1. Add a new book");
    Console.WriteLine("2. Display a list of available books");
    Console.WriteLine("3. Search for a book by title");
    Console.WriteLine("4. Delete a book");
    Console.WriteLine("5. Exit");
    
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            AddBook(bookRepository);
            break;
        case "2":
            bookRepository.ShowBooksRepository();
            break;
        case "3":
            SearchBook(bookRepository);
            break;
        case "4":
            DeleteBook(bookRepository);
            break;
        case "5":
            Console.WriteLine("Thank you for using Book Manager!");
            keep = false;
            break;
        default:
            Console.WriteLine("Invalid option. Please select an option from 1 to 5.");
            break;
    }

    static void AddBook(BookRepository bookRepository)
    {
        Console.WriteLine("\n=== ADD NEW BOOK ===");

        Console.Write("Title of book: ");
        string title = Console.ReadLine();
        while (string.IsNullOrEmpty(title))
        {
            Console.Write("Title of book: ");
            title = Console.ReadLine();
        }

        Console.Write("Author of book: ");
        string author = Console.ReadLine();
        while (string.IsNullOrEmpty(author))
        {
            Console.Write("Author of book: ");
            author = Console.ReadLine();
        }

        Console.Write("Publication Year: ");
        if (int.TryParse(Console.ReadLine(), out int publicationYear))
        {
            bookRepository.AddBookRepository(title, author, publicationYear);
        }
        else
        {
            Console.WriteLine("Invalid year. The book was not added..");
        }
    }

    static void SearchBook(BookRepository bookRepository)
    {
        Console.WriteLine("\n=== SEARCH BOOK ===");
        Console.Write("Enter the title to search: ");
        string searchTitle = Console.ReadLine();

        if (!string.IsNullOrEmpty(searchTitle))
        {
            bookRepository.SearchBooksByTitleRepository(searchTitle);
        }
        else
        {
            Console.WriteLine("You must enter a title to search.");
        }
    }

    static void DeleteBook(BookRepository bookRepository)
    {
        if (bookRepository.QuantityBooksRepository() == 0)
        {
            Console.WriteLine("There are no books to delete.");
            return;
        }

        Console.WriteLine("\n=== DELETE BOOK ===");
        bookRepository.ShowBooksRepository();

        Console.Write("Enter the number of the book to be deleted: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            bookRepository.DeleteBookRepository(id);
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }
    }
}