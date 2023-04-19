
using System;
using System.Threading;
using System.Timers;

class Phoggle
{
	// See https://aka.ms/new-console-template for more information



	//h c a t w e
	//pre populate a list of acceptable words
	//give the user a time limit to enter as many words as they can
	//compare the results

	//collections
	//collection of acceptable words (pass logic filter)
	//collection of user words
	//timers and time limits
	static bool isTheGameBeingPlayed = true;
	private static System.Timers.Timer aTimer;
	private static List<string> playerInputList = new List<string>();
	private static List<string> gameWordsToGuessList = new List<string> { "the guess", "WHAT", "CAT", "HAT" };
	private static List<string> gameWordScoreList = new List<string>(gameWordsToGuessList);
	private static int playerScore = 0;
	private static List<string> aDie = new List<string> { "E", "C", "T", "A", "H", "W" };
	private static List<string> theBoardARowOfDice;// = new List<string> { aDieResult, aDieResult, aDieResult, aDieResult, aDieResult };
	private static List<List<string>> theBoardFullOfDice;// = new List<List<string>> { theBoardARowOfDice, theBoardARowOfDice, theBoardARowOfDice, theBoardARowOfDice, theBoardARowOfDice};

	
	static void Main(string[] args)
	{
		Random rnd = new Random();

		string die51=  aDie[rnd.Next(6)];
		string die52=  aDie[rnd.Next(6)];
		string die53 = aDie[rnd.Next(6)];
		string die54 = aDie[rnd.Next(6)];
		string die55 = aDie[rnd.Next(6)];
		string die11 = aDie[rnd.Next(6)];
		string die12 = aDie[rnd.Next(6)];
		string die13 = aDie[rnd.Next(6)];
		string die14 = aDie[rnd.Next(6)];
		string die15 = aDie[rnd.Next(6)];
		string die21 = aDie[rnd.Next(6)];
		string die22 = aDie[rnd.Next(6)];
		string die23 = aDie[rnd.Next(6)];
		string die24 = aDie[rnd.Next(6)];
		string die25 = aDie[rnd.Next(6)];
		string die31 = aDie[rnd.Next(6)];
		string die32 = aDie[rnd.Next(6)];
		string die33 = aDie[rnd.Next(6)];
		string die34 = aDie[rnd.Next(6)];
		string die35 = aDie[rnd.Next(6)];
		string die41 = aDie[rnd.Next(6)];
		string die42 = aDie[rnd.Next(6)];
		string die43 = aDie[rnd.Next(6)];
		string die44 = aDie[rnd.Next(6)];
		string die45 = aDie[rnd.Next(6)];


		List<string> row1 = new List<string> { die51, die52, die53, die54, die55 };
		List<string> row2 = new List<string> { die11, die12, die13, die14, die15 };
		List<string> row3 = new List<string> { die21, die22, die23, die24, die25 };
		List<string> row4 = new List<string> { die31, die32, die33, die34, die35 };
		List<string> row5 = new List<string> { die41, die42, die43, die44, die45 };

		theBoardFullOfDice = new List<List<string>> { row1, row2, row3, row4, row5 };



		//create the words to guess list
		for (var index = 0; index < gameWordsToGuessList.Count; index++)
		{
			Console.WriteLine(gameWordsToGuessList[index]);
		}
		
		//print the game board
		Console.WriteLine("write as many of these words as you can: ");
		Console.WriteLine("");
		Console.WriteLine("|---|---|---|---|---|");
		Console.WriteLine("|-" + theBoardFullOfDice[0][0]  + "-|-" + theBoardFullOfDice[1][0]  + "-|-" + theBoardFullOfDice[2][0]  + "-|-" + theBoardFullOfDice[3][0]  + "-|-" + theBoardFullOfDice[4][0]  + "-|");
		Console.WriteLine("|---|---|---|---|---|");																											
		Console.WriteLine("|-" + theBoardFullOfDice[0][1]  + "-|-" + theBoardFullOfDice[1][1]  + "-|-" + theBoardFullOfDice[2][1]  + "-|-" + theBoardFullOfDice[3][1]  + "-|-" + theBoardFullOfDice[4][1]  + "-|");
		Console.WriteLine("|---|---|---|---|---|");																										
		Console.WriteLine("|-" + theBoardFullOfDice[0][2]  + "-|-" + theBoardFullOfDice[1][2]  + "-|-" + theBoardFullOfDice[2][2]  + "-|-" + theBoardFullOfDice[3][2]  + "-|-" + theBoardFullOfDice[4][2]  + "-|");
		Console.WriteLine("|---|---|---|---|---|");																													
		Console.WriteLine("|-" + theBoardFullOfDice[0][3]  + "-|-" + theBoardFullOfDice[1][3]  + "-|-" + theBoardFullOfDice[2][3]  + "-|-" + theBoardFullOfDice[3][3]  + "-|-" + theBoardFullOfDice[4][3]  + "-|");
		Console.WriteLine("|---|---|---|---|---|");																																		
		Console.WriteLine("|-" + theBoardFullOfDice[0][4]  + "-|-" + theBoardFullOfDice[1][4]  + "-|-" + theBoardFullOfDice[2][4]  + "-|-" + theBoardFullOfDice[3][4]  + "-|-" + theBoardFullOfDice[4][4]  + "-|");
		Console.WriteLine("|---|---|---|---|---|");
		Console.WriteLine("");
		


		SetTimer();

		Console.WriteLine(" ");
		Console.WriteLine("Time has started");
		Console.WriteLine((aTimer.Interval / 1000) + " seconds remain");
		Console.WriteLine(" ");


		while (isTheGameBeingPlayed) //is the game being played? yes, yes it is.
		{
			string thisString = Console.ReadLine();
			string thatString = thisString.ToUpper();
			playerInputList.Add(thatString);
		}

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
		isTheGameBeingPlayed = false;

		Console.WriteLine("");
		Console.WriteLine("The words that you submitted were.");
		Console.WriteLine("");

		for (var index = 0; index < playerInputList.Count; index++)
		{
			Console.WriteLine(playerInputList[index]);
		}

		Console.WriteLine("");
		Console.WriteLine("Are the submitted words present in the guess list?");
		Console.WriteLine("");

		//for each item in the playerInputList, check if the item is contained within the gameWordsToGuessList
		foreach (var VARIABLE in playerInputList)
		{
			var theGuess = gameWordsToGuessList.Contains(VARIABLE).ToString();
			Console.WriteLine(theGuess);
		}

		Console.WriteLine("");
		Console.WriteLine("Does the submitted word receive a score?");
		Console.WriteLine("");

		foreach (var VARIABLE in playerInputList)
		{
			
			var theGuess = gameWordScoreList.Contains(VARIABLE).ToString();
			Console.WriteLine(theGuess);
			gameWordScoreList.Remove(VARIABLE);
		}
		foreach (var VARIABLE in gameWordScoreList)
		{
			playerScore += 1;

		}
		Console.WriteLine("");
		Console.WriteLine("The player's score is " + playerScore);
		Console.WriteLine("");
	}


	private static void PrintAssignmentByValueVsByReferenceExample()
	{
		// assignment by value
		Console.WriteLine("Begin assignment by value example");
		var baseString = "bla";
		Console.WriteLine($"baseString is {baseString}");

		var stringAssignment = baseString;
		Console.WriteLine($"stringAssignment is {stringAssignment}");
		Console.WriteLine($"baseString is {baseString}");

		stringAssignment = "doot";
		Console.WriteLine($"reassigned to doot, stringAssignment is now {stringAssignment}");
		Console.WriteLine($"baseString is {baseString}");
		Console.WriteLine("End assignment by value example");
		// end assignment by value

		// assignment by reference
		Console.WriteLine("Begin assignment by reference example");
		var baseList = new List<string> { "bla" };
		Console.WriteLine($"baseList is {string.Join(" ", baseList)}");

		var listAssignment = baseList;
		Console.WriteLine($"listAssignment is {string.Join(" ", listAssignment)}");
		Console.WriteLine($"baseList is {string.Join(" ", baseList)}");

		listAssignment.Remove("bla");
		Console.WriteLine($"removed bla listAssignment is {string.Join(" ", listAssignment)}");
		Console.WriteLine($"baseList is {string.Join(" ", baseList)}");
		baseList.Add("doot");
		Console.WriteLine($"added doot listAssignment is {string.Join(" ", listAssignment)}");
		Console.WriteLine($"added doot baseList is {string.Join(" ", baseList)}");
		Console.WriteLine("End assignment by reference example");
		// end assignment by reference
	}
		
}
