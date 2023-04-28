namespace Phoggle
{




	using System;
	using System.Threading;
	using System.Timers;

	class Phoggle
	{
		// See https://aka.ms/new-console-template for more information

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
		private static List<string> _aDie = new List<string> { "E", "C", "T", "A", "H", "W" };

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
			Console.WriteLine("|---|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[0][0] + "-|-" + theBoardFullOfDice[1][0] + "-|-" +
			                  theBoardFullOfDice[2][0] + "-|-" + theBoardFullOfDice[3][0] + "-|-" +
			                  theBoardFullOfDice[4][0] + "-|");
			Console.WriteLine("|---|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[0][1] + "-|-" + theBoardFullOfDice[1][1] + "-|-" +
			                  theBoardFullOfDice[2][1] + "-|-" + theBoardFullOfDice[3][1] + "-|-" +
			                  theBoardFullOfDice[4][1] + "-|");
			Console.WriteLine("|---|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[0][2] + "-|-" + theBoardFullOfDice[1][2] + "-|-" +
			                  theBoardFullOfDice[2][2] + "-|-" + theBoardFullOfDice[3][2] + "-|-" +
			                  theBoardFullOfDice[4][2] + "-|");
			Console.WriteLine("|---|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[0][3] + "-|-" + theBoardFullOfDice[1][3] + "-|-" +
			                  theBoardFullOfDice[2][3] + "-|-" + theBoardFullOfDice[3][3] + "-|-" +
			                  theBoardFullOfDice[4][3] + "-|");
			Console.WriteLine("|---|---|---|---|---|");
			Console.WriteLine("|-" + theBoardFullOfDice[0][4] + "-|-" + theBoardFullOfDice[1][4] + "-|-" +
			                  theBoardFullOfDice[2][4] + "-|-" + theBoardFullOfDice[3][4] + "-|-" +
			                  theBoardFullOfDice[4][4] + "-|");
			Console.WriteLine("|---|---|---|---|---|");
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

		private static List<string> MakeARowOfDice()
		{
			Random rnd = new Random();

			List<string> row = new List<string>();
			for (var index = 0; index < 5; index++)
			{
				row.Add(_aDie[rnd.Next(6)]);
			}

			return row;
		}

		private static List<List<string>> MakeABoard()
		{
			Random rnd = new Random();

			List<List<string>> board = new List<List<string>>();
			for (var index = 0; index < 5; index++)
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

		private static void CheckTheNeighbors()
		{
			//current cell?
			//a neighbor is plus or minus 1 x and/or 1 y
			//keep track of checked cells
			//
		}
	}
}