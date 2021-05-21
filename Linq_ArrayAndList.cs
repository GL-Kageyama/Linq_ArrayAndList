using System;
using System.Linq;
using System.Collections.Generic;

namespace Linq_ArrayAndList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var arrayAndList = new ArrayAndList();

            arrayAndList.ArrayRange();

            arrayAndList.numAverage();

            arrayAndList.numAverage2();

            arrayAndList.ListSum();

            arrayAndList.minList();

            arrayAndList.maxList();

            arrayAndList.ListCount();

            arrayAndList.StoryCount();

            arrayAndList.CheckSix();

            arrayAndList.Check1000();

            arrayAndList.CheckZero();

            arrayAndList.CheckPrice();

            arrayAndList.ListEqual();

            arrayAndList.CheckThree();

            arrayAndList.FindIndex();

            arrayAndList.TakeIndex();

            arrayAndList.TakeUnder600();

            arrayAndList.selectLower();

            arrayAndList.makeCollection();

            arrayAndList.outDuplicate();

            arrayAndList.orderBy();
        }
    }

    class ArrayAndList
    {
        Books Books = new Books();

        private IEnumerable<Book> books = Books.GetBooks();

        List<int> numbers = new List<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
        };

        List<int> numbers1 = new List<int>
        {
            1, 2, 3, 4, 5,
        };

        List<int> numbers2 = new List<int>
        {
            1, 2, 3, 4, 5,
        };

        string text = "This is a pen. That is a dog. It is a cup.";

        List<string> words = new List<string>
        {
            "Microsoft", "Apple", "Google", "Facebook", "Amazon", 
        };

        // Putting consecutive values in an array
        public void ArrayRange()
        {
            var array = Enumerable.Range(1, 20).ToArray();
            foreach (var num in array)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        // Find the average value of the list
        public void numAverage()
        {
            var average = numbers.Average();
            Console.WriteLine(average);
            Console.WriteLine();
        }

        // Find the average price of a literary work
        public void numAverage2()
        {
            var average = books.Average(x => x.Price);
            Console.WriteLine(average);
            Console.WriteLine();
        }

        // Find the total value
        public void ListSum()
        {
            // Total value of the list
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            Console.WriteLine();

            // Total value of prices for literary works
            var totalPrice = books.Sum(x => x.Price);
            Console.WriteLine(totalPrice);
            Console.WriteLine();
        }

        // Find the minimum value of the list
        public void minList()
        {
            var min = numbers.Where(n => n > 0).Min();
            Console.WriteLine(min);
            Console.WriteLine();
        }

        // Find the maximum number of pages in a literary work
        public void maxList()
        {
            var pages = books.Max(x => x.Pages);
            Console.WriteLine(pages);
            Console.WriteLine();
        }

        // Counting 7's and 12's
        public void ListCount()
        {
            var count = numbers.Count(n => n == 7 || n == 12);
            Console.WriteLine(count);
            Console.WriteLine();
        }

        // Literary works with the name "Izu" are counted.
        public void StoryCount()
        {
            var count = books.Count(x => x.Title.Contains("Izu"));
            Console.WriteLine(count);
            Console.WriteLine();
        }

        // Find out if there are multiples of six
        public void CheckSix()
        {
            bool exists = numbers.Any(n => n % 6 == 0);
            Console.WriteLine(exists);
            Console.WriteLine();
        }

        // Find out if there are literary works that cost more than ¥1000
        public void Check1000()
        {
            bool exists = books.Any(n => n.Price >= 1000);
            Console.WriteLine(exists);
            Console.WriteLine();
        }

        // Check if all numbers in the list are greater than zero
        public void CheckZero()
        {
            bool exists = numbers.All(n => n > 0);
            Console.WriteLine(exists);
            Console.WriteLine();
        }

        // Find out if all literary works are under ¥1000
        public void CheckPrice()
        {
            bool exists = books.All(x => x.Price <= 1000);
            Console.WriteLine(exists);
            Console.WriteLine();
        }

        // Find if two lists are equal
        public void ListEqual()
        {
            bool equal = numbers1.SequenceEqual(numbers2);
            Console.WriteLine(equal);
            Console.WriteLine();
        }

        // Display the first word with 3 letters found
        public void CheckThree()
        {
            var words = text.Split(' ');
            var word = words.FirstOrDefault(x => x.Length == 3);
            Console.WriteLine(word);
            Console.WriteLine();
        }

        // Get an index of 6 or more
        public void FindIndex()
        {
            var index = numbers.FindIndex(n => n > 6);
            Console.WriteLine(index);
            Console.WriteLine();
        }

        // Take out 6 numbers that are 7 or more
        public void TakeIndex()
        {
            var results = numbers.Where(n => n >= 7).Take(6);
            foreach (var item in results)
                Console.WriteLine(item);
                Console.WriteLine();
        }

        // Take out literary works only for less than ¥600
        public void TakeUnder600()
        {
            var selected = books.TakeWhile(x => x.Price < 600);
            foreach (var book in selected)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
            Console.WriteLine();
        }

        // Conversion to lowercase
        public void selectLower()
        {
            var lowers = words.Select(name => name.ToLower()).ToArray();
            lowers.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        // Create another collection
        public void makeCollection()
        {
            var titles = books.Select(x => x.Title);
            titles.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        // Eliminate duplicates
        public void outDuplicate()
        {
            var numbersOut = new List<int>
            {
                12, 7, 3, 2, 2, 4, 20, 7, 7, 8, 9, 9, 2,
            };
            var results = numbersOut.Distinct();
            results.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        // Sort by price
        public void orderBy()
        {
            var sortedBooks = books.OrderBy(x => x.Price);
            foreach (var book in sortedBooks)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
            Console.WriteLine();
        }
    }

    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }

    // Information on the book to be processed
    class Books {
        public static List<Book> GetBooks() {
            var books = new List<Book> {
               new Book { Title = "Kokoro", Price = 400, Pages = 378 },
               new Book { Title = "No Longer Human", Price = 281, Pages = 212 },
               new Book { Title = "The Izu Dancer ", Price = 389, Pages = 201 },
               new Book { Title = "Night of the Milky Way Railway", Price = 411, Pages = 276 },
               new Book { Title = "A Tale of Two Cities", Price = 961, Pages = 666 },
               new Book { Title = "New Tales of Tono", Price = 514, Pages = 268 },
            };
            return books;
        }
    }
}