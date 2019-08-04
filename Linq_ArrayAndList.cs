using System;
using System.Linq;
using System.Collections.Generic;

// This Code is need a mono.

namespace Linq_ArrayAndList
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var AandL = new ArrayAndList();

			AandL.ListRepeat();

			AandL.ArrayRepeat();

			AandL.ArrayRange();

			AandL.numAverage();

			AandL.numAverage2();

			AandL.ListSum();

			AandL.minList();

			AandL.maxList();

			AandL.ListCount();

			AandL.StoryCount();

			AandL.CheckSix();

			AandL.Check1000();

			AandL.CheckZero();

			AandL.CheckPrice();

			AandL.ListEqual();

			AandL.CheckThree();

			AandL.FindIndex();

			AandL.TakeIndex();

			AandL.TakeUnder600();

			AandL.selectLower();

			AandL.makeCollection();

			AandL.outDuplicate();

			AandL.orderBy();
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

		string text = "This is a pen That is a dog It is a cup";

		List<string> words = new List<string>
		{
			"Microsoft", "Apple", "Google", "Facebook", "Amazon", 
		};

		// -1を20個リストに格納する
		public void ListRepeat()
		{
			var numbers = Enumerable.Repeat(-1, 20).ToList();
			foreach (var num in numbers)
				Console.Write("{0} ", num);
			Console.WriteLine();
		}

		// unknownを12個、配列に入れる
		public void ArrayRepeat()
		{
			var strings = Enumerable.Repeat("unknown", 12).ToArray();
			foreach (var s in strings)
				Console.Write("{0} ", s);
			Console.WriteLine();
		}

		// 配列に連続した値を入れる
		public void ArrayRange()
		{
			var array = Enumerable.Range(1, 20).ToArray();
			foreach (var num in array)
				Console.Write("{0} ", num);
			Console.WriteLine();
		}

		// リストの平均値を求める
		public void numAverage()
		{
			var average = numbers.Average();
			Console.WriteLine(average);
			Console.WriteLine();
		}

		// 文学作品の平均価格を求める
		public void numAverage2()
		{
			var average = books.Average(x => x.Price);
			Console.WriteLine(average);
			Console.WriteLine();
		}

		// 合計値を求める
		public void ListSum()
		{
			// リストの合計値
			var sum = numbers.Sum();
			Console.WriteLine(sum);
			Console.WriteLine();

			// 文学作品の価格の合計値
			var totalPrice = books.Sum(x => x.Price);
			Console.WriteLine(totalPrice);
			Console.WriteLine();
		}

		// リストの最小値を求める
		public void minList()
		{
			var min = numbers.Where(n => n > 0).Min();
			Console.WriteLine(min);
			Console.WriteLine();
		}

		// 文学作品の最大ページ数を求める
		public void maxList()
		{
			var pages = books.Max(x => x.Pages);
			Console.WriteLine(pages);
			Console.WriteLine();
		}

		// 7と12の数をカウント
		public void ListCount()
		{
			var count = numbers.Count(n => n == 7 || n == 12);
			Console.WriteLine(count);
			Console.WriteLine();
		}

		// 物語という名前が入っている文学作品をカウント
		public void StoryCount()
		{
			var count = books.Count(x => x.Title.Contains("物語"));
			Console.WriteLine(count);
			Console.WriteLine();
		}

		// 6の倍数があるかを調べる
		public void CheckSix()
		{
			bool exists = numbers.Any(n => n % 6 == 0);
			Console.WriteLine(exists);
			Console.WriteLine();
		}

		// 1000円よりも高い文学作品があるかどうかを調べる
		public void Check1000()
		{
			bool exists = books.Any(n => n.Price >= 1000);
			Console.WriteLine(exists);
			Console.WriteLine();
		}

		// リスト内は全て0より大きい数か調べる
		public void CheckZero()
		{
			bool exists = numbers.All(n => n > 0);
			Console.WriteLine(exists);
			Console.WriteLine();
		}

		// 全ての文学作品が1000円以下かを調べる
		public void CheckPrice()
		{
			bool exists = books.All(x => x.Price <= 1000);
			Console.WriteLine(exists);
			Console.WriteLine();
		}

		// 2つのリストが等しいかを求める
		public void ListEqual()
		{
			bool equal = numbers1.SequenceEqual(numbers2);
			Console.WriteLine(equal);
			Console.WriteLine();
		}

		// 最初に見つかった文字数3の単語を表示
		public void CheckThree()
		{
            var words = text.Split(' ');
            var word = words.FirstOrDefault(x => x.Length == 3);
            Console.WriteLine(word);
            Console.WriteLine();
		}

		// 6以上のインデックスを取得
		public void FindIndex()
		{
			var index = numbers.FindIndex(n => n > 6);
			Console.WriteLine(index);
			Console.WriteLine();
		}

		// 7以上の数を6個取り出す
		public void TakeIndex()
		{
			var results = numbers.Where(n => n >= 7).Take(6);
			foreach (var item in results)
				Console.WriteLine(item);
				Console.WriteLine();
		}

		// 600円未満の間だけ文学作品を取り出す
		public void TakeUnder600()
		{
			var selected = books.TakeWhile(x => x.Price < 600);
			foreach (var book in selected)
				Console.WriteLine("{0} {1}", book.Title, book.Price);
			Console.WriteLine();
		}

		// 小文字への変換
		public void selectLower()
		{
			var lowers = words.Select(name => name.ToLower()).ToArray();
			lowers.ToList().ForEach(Console.WriteLine);
			Console.WriteLine();
		}

		// 別のコレクションを作成する
		public void makeCollection()
		{
			var titles = books.Select(x => x.Title);
			titles.ToList().ForEach(Console.WriteLine);
			Console.WriteLine();
		}

		// 重複を排除する
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

		// 価格順に並べ替える
		public void orderBy()
		{
			var sortedBooks = books.OrderBy(x => x.Price);
			foreach (var book in sortedBooks)
				Console.WriteLine("{0} {1}", book.Title, book.Price);
			Console.WriteLine();
		}
	}

	// -------------------------------------------------------------

	// 処理対象の情報
	
	class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }

    class Books {
        public static List<Book> GetBooks() {
            var books = new List<Book> {
               new Book { Title = "こころ", Price = 400, Pages = 378 },
               new Book { Title = "人間失格", Price = 281, Pages = 212 },
               new Book { Title = "伊豆の踊子", Price = 389, Pages = 201 },
               new Book { Title = "若草物語", Price = 637, Pages = 464 },
               new Book { Title = "銀河鉄道の夜", Price = 411, Pages = 276 },
               new Book { Title = "二都物語", Price = 961, Pages = 666 },
               new Book { Title = "遠野物語", Price = 514, Pages = 268 },
            };
            return books;
        }
    }
}

























