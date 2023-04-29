using System.Dynamic;

namespace Phoggle
{




	using System;
	using System.Linq;
	using System.Threading;
	using System.Timers;

	class Phoggle
	{
		//to do
		//find words on board and add to _gameWordsToGuessList
		//define neighbors
		//
		static bool _isTheGameBeingPlayed = true;
		private static System.Timers.Timer aTimer;
		private static List<string> _playerInputList = new List<string>();
		private static List<string> _gameWordsToGuessList = new List<string> { "the guess", "WHAT", "CAT", "HAT" };
		private static List<string> _gameWordScoreList = new List<string>(_gameWordsToGuessList);
		private static int _playerScore = 0;
		private static List<string> _testDie = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static List<PhoggleDice> _bagOfDice = PhoggleDice.GetAllDice();




		static void Main(string[] args)
		{
			Random rnd = new Random();

			List<List<string>> theBoardFullOfDice = MakeABoard();

			//create the words to guess list
			for (var index = 0; index < _gameWordsToGuessList.Count; index++)
			{
				Console.WriteLine(_gameWordsToGuessList[index]);
			}

			//print the game board
			Console.WriteLine("write as many of these words as you can: ");
			Console.WriteLine("");
			Console.WriteLine("|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[0][0] + "-|-" + theBoardFullOfDice[0][1] + "-|-" + theBoardFullOfDice[0][2] + "-|-" + theBoardFullOfDice[0][3] + "-|");
			Console.WriteLine("|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[1][0] + "-|-" + theBoardFullOfDice[1][1] + "-|-" + theBoardFullOfDice[1][2] + "-|-" + theBoardFullOfDice[1][3] + "-|");
			Console.WriteLine("|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[2][0] + "-|-" + theBoardFullOfDice[2][1] + "-|-" + theBoardFullOfDice[2][2] + "-|-" + theBoardFullOfDice[2][3] + "-|");
			Console.WriteLine("|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[3][0] + "-|-" + theBoardFullOfDice[3][1] + "-|-" + theBoardFullOfDice[3][2] + "-|-" + theBoardFullOfDice[3][3] + "-|");
			Console.WriteLine("|---|---|---|---|");
			Console.WriteLine("");



			SetTimer();

			Console.WriteLine(" ");
			Console.WriteLine("Time has started");
			Console.WriteLine((aTimer.Interval / 1000) + " seconds remain");
			Console.WriteLine(" ");


			while (_isTheGameBeingPlayed) //is the game being played? yes, yes it is.
			{
				string thisString = Console.ReadLine();
				string thatString = thisString.ToUpper();
				_playerInputList.Add(thatString);
			}

		}

		private static PhoggleDice PullADieFromBag()
		{
			Random rnd = new Random();
			int randInt = rnd.Next(_bagOfDice.Count);
			
			var dieFromBag = _bagOfDice[randInt];
			_bagOfDice.Remove(dieFromBag);
			return dieFromBag;
		}

		private static List<string> MakeARowOfDice()
		{
			Random rnd = new Random();
			List<string> row = new List<string>();
			for (var index = 0; index < 4; index++)
			{
				PhoggleDice aDie = PullADieFromBag();
				row.Add(aDie.Roll());
			}

			return row;
		}

		private static List<List<string>> MakeABoard()
		{
			List<List<string>> board = new List<List<string>>();
			for (var index = 0; index < 4; index++)
			{
				board.Add(MakeARowOfDice());
			}

			return board;
		}

		private static void SetTimer()
		{
			// Create a timer with a two second interval.
			aTimer = new System.Timers.Timer(10000);
			// Hook up the Elapsed event for the timer. 
			aTimer.Elapsed += OnTimedEvent;
			aTimer.AutoReset = false;
			aTimer.Enabled = true;
		}

		private static void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			Console.WriteLine(" ");
			Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
			aTimer.Stop();
			aTimer.Dispose();
			Console.WriteLine("Timer has expired. Terminating the application...");
			_isTheGameBeingPlayed = false;

			Console.WriteLine("");
			Console.WriteLine("The words that you submitted were.");
			Console.WriteLine("");

			for (var index = 0; index < _playerInputList.Count; index++)
			{
				Console.WriteLine(_playerInputList[index]);
			}

			Console.WriteLine("");
			Console.WriteLine("Are the submitted words present in the guess list?");
			Console.WriteLine("");

			//for each item in the _playerInputList, check if the item is contained within the _gameWordsToGuessList
			foreach (var aGuess in _playerInputList)
			{
				var isTheGuessCorrect = _gameWordsToGuessList.Contains(aGuess).ToString();
				Console.WriteLine(isTheGuessCorrect);
			}

			Console.WriteLine("");
			Console.WriteLine("Does the submitted word receive a score?");
			Console.WriteLine("");

			foreach (var scorableGuess in _playerInputList)
			{

				var isTheGuessAScore = _gameWordScoreList.Contains(scorableGuess);
				if (isTheGuessAScore == true)
				{
					_gameWordScoreList.Remove(scorableGuess);
					_playerScore += 1;
				}

				Console.WriteLine(isTheGuessAScore);
			}

			Console.WriteLine("");
			Console.WriteLine("The player's score is " + _playerScore);
			Console.WriteLine("");
		}
	}

	class PhoggleDice
	{

		private List<string> thisDie;

		public PhoggleDice(int dicenumber)
		{
			switch (dicenumber)
			{
				case 1: thisDie = StandardDie1; break;
				case 2: thisDie = StandardDie2; break;
				case 3: thisDie = StandardDie3; break;
				case 4: thisDie = StandardDie4; break;
				case 5: thisDie = StandardDie5; break;
				case 6: thisDie = StandardDie6; break;
				case 7: thisDie = StandardDie7; break;
				case 8: thisDie = StandardDie8; break;
				case 9: thisDie = StandardDie9; break;
				case 10: thisDie = StandardDie10; break;
				case 11: thisDie = StandardDie11; break;
				case 12: thisDie = StandardDie12; break;
				case 13: thisDie = StandardDie13; break;
				case 14: thisDie = StandardDie14; break;
				case 15: thisDie = StandardDie15; break;
				case 16: thisDie = StandardDie16; break;
				default:
					throw new ArgumentOutOfRangeException(
						nameof(dicenumber), "You've selected a different PhoggleDice than even exists");
			}
		}

		Random rnd = new Random();
		
		public string Roll()
		{
			return thisDie[rnd.Next(6)];
		}

		private static readonly List<string> StandardDie1  = new List<string> { "R", "I", "F", "O", "B", "X" };
		private static readonly List<string> StandardDie2  = new List<string> { "I", "F", "E", "H", "E", "Y" };
		private static readonly List<string> StandardDie3  = new List<string> { "D", "E", "N", "O", "W", "S" };
		private static readonly List<string> StandardDie4  = new List<string> { "U", "T", "O", "K", "N", "D" };
		private static readonly List<string> StandardDie5  = new List<string> { "H", "M", "S", "R", "A", "O" };
		private static readonly List<string> StandardDie6  = new List<string> { "L", "U", "P", "E", "T", "S" };
		private static readonly List<string> StandardDie7  = new List<string> { "A", "C", "I", "T", "O", "A" };
		private static readonly List<string> StandardDie8  = new List<string> { "Y", "L", "G", "K", "U", "E" };
		private static readonly List<string> StandardDie9  = new List<string> { "Qu","B", "M", "J", "O", "A" };
		private static readonly List<string> StandardDie10 = new List<string> { "E", "H", "I", "S", "P", "M" };
		private static readonly List<string> StandardDie11 = new List<string> { "V", "E", "T", "I", "G", "N" };
		private static readonly List<string> StandardDie12 = new List<string> { "B", "A", "L", "I", "Y", "T" };
		private static readonly List<string> StandardDie13 = new List<string> { "E", "Z", "A", "V", "N", "D" };
		private static readonly List<string> StandardDie14 = new List<string> { "R", "A", "L", "E", "S", "C" };
		private static readonly List<string> StandardDie15 = new List<string> { "U", "W", "I", "L", "R", "G" };
		private static readonly List<string> StandardDie16 = new List<string> { "P", "A", "C", "E", "M", "D" };

		//use the dice below for testing
		/*
		private static readonly List<string> StandardDie1  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie2  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie3  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie4  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie5  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie6  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie7  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie8  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie9  = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie10 = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie11 = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie12 = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie13 = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie14 = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie15 = new List<string> { "E", "C", "T", "A", "H", "W" };
		private static readonly List<string> StandardDie16 = new List<string> { "E", "C", "T", "A", "H", "W" };
		*/

		public static List<PhoggleDice> GetAllDice()
		{
			var result = new List<PhoggleDice>();
			for (var i = 1; i < 17; i++)
			{
				result.Add(new PhoggleDice(i));
			}

			return result;

		}


	}

	class PhoggleBoard
	{

	}
}