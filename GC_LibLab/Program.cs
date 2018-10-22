using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_LibLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> Books = new List<List<string>>();


            Books.Add(new List<string> { "Roadside Picnic", "Arkady and Boris Strugasky", "Science Fiction", "Checked In" });
            Books.Add(new List<string> { "Metro 2033", "Dmitry Glikhovsky", "Science Fiction", "Checked In" });
            Books.Add(new List<string> { "The Mayor of Castro Street", "Randy Shilts", "Biography", "Checked In" });
            Books.Add(new List<string> { "The Wheel Of Time series", "Robert Jordan", "Fantasy", "Checked In" });
            Books.Add(new List<string> { "The Kingkiller Chronicles", "Patrick Rothfuss", "Fantasy", "Checked In" });
            Books.Add(new List<string> { "The Stormlight Archives series", "Brandon Sanderson", "Fantasy", "Checked In" });
            Books.Add(new List<string> { "Pilog X", "Tom Merrit", "Science Fiction", "Checked In" });
            Books.Add(new List<string> { "Mistborn series", "Brandon Sanderson", "Fantasy", "Checked In" });
            Books.Add(new List<string> { "The Danish Girl", "David Ebershoff", "Biography", "Checked In" });
            Books.Add(new List<string> { "The Dark Tower series", "Steven King", "Science Fiction", "Checked In" });
            Books.Add(new List<string> { "The Road", "Cormac McCarthy", "Science Fiction", "Checked In" });
            Books.Add(new List<string> { "Life Engineered", "J.F. Dubeau", "Science Fiction", "Checked In" });

            while (true)
            {
                try
                {
                    Console.WriteLine("Welcome to the Library. Please select one of the following options:");
                    Console.WriteLine("1) List all books in the library \n2) Search for book by Author \n3) Search for book by Title Keyword \n4) Check book out \n5) Return Book \n6) Display list of checked in and checked out books \n");
                    int function = int.Parse(Console.ReadLine());

                    if (function == 1)
                    {
                        ListBooks(Books);
                    }
                    if (function == 2)
                    {
                        AuthorSearch(Books);
                    }
                    if (function == 3)
                    {
                        TitleSearch(Books);
                    }
                    if (function == 4)
                    {
                        CheckOut(Books);
                    }
                    if (function == 5)
                    {
                        CheckIn(Books);
                    }
                    if (function == 6)
                    {
                        SortList(Books);
                    }
                }
                catch{ Console.WriteLine("That is not a valid entry. Please choose again."); continue;}
            }
        }
        public static void ListBooks(List<List<string>> Books)
        {
            Console.WriteLine("Title".PadRight(25) + "Author".PadRight(25) + "Genre".PadRight(25) + "Status".PadRight(25));

            for (int i = 0; i < Books.Count; i++)
            {
                string title = Books[i][0];
                if (title.Length > 20) { title = title.Substring(0, 17) + "..."; }
                string author = Books[i][1];
                if (author.Length > 20) { author = author.Substring(0, 17) + "..."; }

                Console.WriteLine(title.PadRight(25) + author.PadRight(25) + Books[i][2].PadRight(25) + Books[i][3].PadRight(25));


            }
            Console.WriteLine("\n \n");

        }
        public static void AuthorSearch(List<List<string>> Books)
        {
            while (true)
            {
                try
                {
                    Console.Write("Search Authors for:");
                    string NameSearch = Console.ReadLine().ToLower();
                    int count = 0;
                    for (int i = 0; i < Books.Count; i++)
                    {
                        if (Books[i][1].ToLower().Contains(NameSearch))
                        {
                            Console.WriteLine($"\nTitle: {Books[i][0]}\nAuthor: {Books[i][1]}\nGenre: {Books[i][2]}\nStatus: {Books[i][3]}\n");
                            count += 1;
                        }
                    }
                    Console.WriteLine($"There are {count} books that match your search criteria\n");

                    Console.WriteLine("Would you like to \n1)Continue 2) Exit to main screen");
                    string Cont = Console.ReadLine().ToLower();
                    if (Cont == "1" || "continue".Contains(Cont)) { continue; }
                    if (Cont == "2" || "exit to main screen".Contains(Cont)) { break; }
                }
                catch
                {
                    Console.WriteLine("Entry was invalid. Please try again. \n");
                    continue;
                }
            }
        }
        public static void TitleSearch(List<List<string>> Books)
        {
            while (true)
            {
                try
                {
                    Console.Write("Search Titles for:");
                    string NameSearch = Console.ReadLine().ToLower();
                    int count = 0;
                    for (int i = 0; i < Books.Count; i++)
                    {
                        if (Books[i][0].ToLower().Contains(NameSearch))
                        {
                            Console.WriteLine($"\nTitle: {Books[i][0]}\nAuthor: {Books[i][1]}\nGenre: {Books[i][2]}\nStatus: {Books[i][3]}\n");
                            count += 1;
                        }
                    }
                    Console.WriteLine($"There are {count} books that match your search criteria\n");

                    Console.WriteLine("Would you like to \n1)Continue 2) Exit to main screen");
                    int Cont = int.Parse(Console.ReadLine());
                    if (Cont == "1" || "continue".Contains(Cont)) { continue; }
                    if (Cont == "2" || "exit to main screen".Contains(Cont)) { break; }
                }
                catch
                {
                    Console.WriteLine("Entry was invalid. Please try again. \n");
                    continue;
                }
            }
        }
        public static void CheckOut(List<List<string>> Books)
        {


            while (true)
            {
                try
                {
                    Console.WriteLine("Enter book title to check out. (Enter 'Quit' to exit to main menu.)");
                    string bookcheck = Console.ReadLine().ToLower();
                    int count = 0;
                    int x = 0;
                    if (bookcheck == "quit") { break; }
                    for (int i = 0; i < Books.Count; i++)
                    {
                        if (Books[i][0].ToLower().Contains(bookcheck) && Books[i][3] == "Checked In")
                        {

                            string title = Books[i][0];
                            if (title.Length > 20) { title = title.Substring(0, 17) + "..."; }
                            string author = Books[i][1];
                            if (author.Length > 20) { author = author.Substring(0, 17) + "..."; }
                            Console.WriteLine(title.PadRight(25) + author.PadRight(25) + Books[i][2].PadRight(25) + Books[i][3].PadRight(25));

                            count += 1;
                            x = x + i;

                        }
                        if (Books[i][0].ToLower().Contains(bookcheck) && Books[i][3] == "Checked Out")
                        {
                            string title = Books[i][0];
                            if (title.Length > 20) { title = title.Substring(0, 17) + "..."; }
                            string author = Books[i][1];
                            if (author.Length > 20) { author = author.Substring(0, 17) + "..."; }
                            Console.WriteLine(title.PadRight(25) + author.PadRight(25) + Books[i][2].PadRight(25) + Books[i][3].PadRight(25));
                        }
                    }

                    if (count == 1)
                    {
                        Console.WriteLine($"\nThere is {count} book that matches your search");
                        Console.WriteLine("Is this the book you would like to check out? \n1) Yes \n2) No");
                        string entry = Console.ReadLine();
                        if (entry == "1" || "yes".Contains(entry.ToLower());
                        {

                            Books[x][3] = "Checked Out";

                            Books[x].Add(DateTime.Now.AddDays(14).ToString("dddd, MMMM dd, yyyy"));
                            Console.WriteLine($"{Books[x][0]} has been checked out. It is due back {Books[x][4]}.\n");
                            break;
                        }
                    }
                    if (count > 1) { Console.WriteLine("\nMultiple books match your search criteria. Please narrow your search.\n"); continue; }
                    if (count < 1) { Console.WriteLine("\nNo books that are currently checked in match that criterial. Please broaden your search.\n"); continue; }

                }
                catch { Console.WriteLine("Incorrect Entry. Please try again."); continue; }
            }



        }
        public static void CheckIn(List<List<string>> Books)

        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the title of the book to check in. (Enter 'quit' to return to main menu.");
                    string checkIn = Console.ReadLine().ToLower();
                    if (checkIn == "quit") { break; }
                    int count = 0;
                    int x = 0;
                    for (int i = 0; i < Books.Count; i++)
                    {
                        if (Books[i][3] == "Checked Out" && Books[i][0].ToLower().Contains(checkIn))
                        {
                            string title = Books[i][0];
                            if (title.Length > 20) { title = title.Substring(0, 17) + "..."; }
                            string author = Books[i][1];
                            if (author.Length > 20) { author = author.Substring(0, 17) + "..."; }
                            Console.WriteLine(title.PadRight(25) + author.PadRight(25) + Books[i][2].PadRight(25) + Books[i][3].PadRight(25));

                            count += 1;
                            x = x + i;
                        }

                    }
                    if (count == 1)
                    {
                        Console.WriteLine($"\nThere is {count} book that matches your search");
                        Console.WriteLine("Is this the book you would like to check in? \n1) Yes \n2) No");
                        string entry = Console.ReadLine();
                        if (entry == "1" || "yes".Contains(entry.ToLower());
                        {
                            if (DateTime.Parse(Books[x][4]) < DateTime.Now)
                            { Console.WriteLine("***BOOK IS LATE! INITIATE LATE FEE COLLECTION MODE!***"); }


                            Books[x][3] = "Checked In";
                            Books[x].RemoveAt(4);
                            Console.WriteLine($"{Books[x][0]} has been checked in\n");
                        }
                    }
                }
                catch { Console.WriteLine("Incorrect Entry. Please try again.\n"); continue; }
            }
        }
        public static void SortList(List<List<string>> Books)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Show books that are \n1)Checked in \n2)Checked Out \n(enter 'quit' to return to main menu.");
                    string InOut = Console.ReadLine();
                    if (InOut.ToLower() == "quit") { break; }
                    Console.WriteLine("Title".PadRight(25) + "Author".PadRight(25) + "Genre".PadRight(25) + "Status".PadRight(25));

                    for (int i = 0; i < Books.Count; i++)
                    {
                        if (InOut == "1" && Books[i][3] == "Checked In")
                        {
                            string title = Books[i][0];
                            if (title.Length > 20) { title = title.Substring(0, 17) + "..."; }
                            string author = Books[i][1];
                            if (author.Length > 20) { author = author.Substring(0, 17) + "..."; }

                            Console.WriteLine(title.PadRight(25) + author.PadRight(25) + Books[i][2].PadRight(25) + Books[i][3].PadRight(25));
                        }
                        if (InOut == "2" && Books[i][3] == "Checked Out")
                        {
                            string title = Books[i][0];
                            if (title.Length > 20) { title = title.Substring(0, 17) + "..."; }
                            string author = Books[i][1];
                            if (author.Length > 20) { author = author.Substring(0, 17) + "..."; }

                            Console.WriteLine(title.PadRight(25) + author.PadRight(25) + Books[i][2].PadRight(25) + Books[i][3].PadRight(25) + Books[i][4].PadRight(25));
                        }
                    }
                }
                catch { Console.WriteLine("Invalid entry. Please try again"); continue; }
            }
        }
    }
}
