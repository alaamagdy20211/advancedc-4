using System.Diagnostics;
using System.Globalization;

namespace advancedc_4
{

    public class LibraryBook
    {
        public string BookISBN { get; private set; }
        public string BookTitle { get; private set; }
        public string[] BookAuthors { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public decimal BookPrice { get; private set; }

        public LibraryBook(string isbn, string title, string[] authors, DateTime releaseDate, decimal price)
        {
            this.BookISBN = isbn;
            this.BookTitle = title;
            this.BookAuthors = authors ?? Array.Empty<string>();
            this.ReleaseDate = releaseDate;
            this.BookPrice = price;
        }

       
        public override string ToString()
        {
            return $"\"{BookTitle}\" (ISBN: {BookISBN}) by {string.Join(", ", BookAuthors)} " +
                   $"- Released on {ReleaseDate.ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture)} - " +
                   $"Cost: {BookPrice:C2}";
        }
    }

    public static class LibraryUtils
    {
        public static string FetchTitle(LibraryBook book)
        {
            return book?.BookTitle ?? "Title Not Available";
        }

        public static string FetchAuthors(LibraryBook book)
        {
            return book != null && book.BookAuthors.Length > 0 ? string.Join(", ", book.BookAuthors) : "Author(s) Unknown";
        }

        public static string FetchPrice(LibraryBook book)
        {
            return book != null ? book.BookPrice.ToString("C2", CultureInfo.InvariantCulture) : "Price Unavailable";
        }
    }
    public class Book
    {
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }

    public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
    {
        ISBN = _ISBN;
        Title = _Title;
        Authors = _Authors;
        PublicationDate = _PublicationDate;
        Price = _Price;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
    }
}

public class BookFunctions
{
    public static string GetTitle(Book B)
    {
        return B.Title;
    }

    public static string GetAuthors(Book B)
    {
        return string.Join(", ", B.Authors);
    }

    public static string GetPrice(Book B)
    {
        return B.Price.ToString("C");
    }
}


    public class CustomList<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item) => items.Add(item);

        public bool Exists(Predicate<T> match) => items.Find(match) != null;

        public T Find(Predicate<T> match)
        {
            foreach (var item in items)
            {
                if (match(item))
                    return item;
            }
            return default;
        }

        public List<T> FindAll(Predicate<T> match)
        {
            List<T> results = new List<T>();
            foreach (var item in items)
            {
                if (match(item))
                    results.Add(item);
            }
            return results;
        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            for (int i = startIndex; i < items.Count; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        public T FindLast(Predicate<T> match)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (match(items[i]))
                    return items[i];
            }
            return default;
        }

        public int FindLastIndex(Predicate<T> match)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        public int FindLastIndex(int startIndex, Predicate<T> match)
        {
            for (int i = startIndex; i >= 0; i--)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public bool TrueForAll(Predicate<T> match)
        {
            foreach (var item in items)
            {
                if (!match(item))
                    return false;
            }
            return true;
        }

       
        public void Print()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            #region 

            LibraryBook book = new LibraryBook(
            "8894555",
            "Programming",
            new string[] { "alaa magdy" },
            new DateTime(1968, 1, 1),
            999999.99m
        );

            Console.WriteLine("Book Title: " + LibraryUtils.FetchTitle(book));
            Console.WriteLine("Book Authors: " + LibraryUtils.FetchAuthors(book));
            Console.WriteLine("Book Price: " + LibraryUtils.FetchPrice(book));

            Console.WriteLine("\nFull Book Details:");
            Console.WriteLine(book.ToString());
            #endregion


            #region
            CustomList<Book> bookList = new CustomList<Book>();

            bookList.Add(new Book("123", " Programming", new string[] { "alaa" }, new DateTime(1988, 1, 1), 99.99m));
            bookList.Add(new Book("456", " scince of Algorithms", new string[] { "magdy" }, new DateTime(2003, 9, 1), 1200.50m));
            bookList.Add(new Book("789", " Python", new string[] { "esraa" }, new DateTime(2019, 4, 14), 2999.99m));

            Console.WriteLine("All Books:");
            bookList.Print();

            bool exists = bookList.Exists(b => b.Price > 100);
            Console.WriteLine("\nAny book with price over $100? " + exists);

            Book foundBook = bookList.Find(b => b.Title.Contains("Algorithms"));
            Console.WriteLine("\nFound Book: " + foundBook);

            List<Book> booksByalaa = bookList.FindAll(b => Array.Exists(b.Authors, author => author == "alaa"));
            Console.WriteLine("\nBooks by alaa:");
            foreach (var x in booksByalaa)
            {
                Console.WriteLine(x);
            }
            #endregion
        }
    }
}
