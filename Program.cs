using parivedaAnnya.Games;

//DisplayInstructions();
Console.Clear();
System.Console.WriteLine("Welcome to mini games! Please select an option from below.");
int userChoice = GetUserChoice();
int credits = 50;
bool gameOver = false;

while (userChoice != 8){   
    Route(userChoice, ref credits);
    gameOver= IsGameOver(credits);
    
    if (gameOver) {
        userChoice = 6;
    }
    else {
        PauseAction();
        Console.Clear();
        userChoice = GetUserChoice();
    }
}
//end main

static int GetUserChoice(){
    DisplayMenu();
    string userChoice = Console.ReadLine();
    int choice;
    if (IsValidChoice(userChoice)){
        choice = int.Parse(userChoice);
        return choice;
    }
    else {
       System.Console.WriteLine( "This is not a valid choice. Please try again.");
       PauseAction();
       return GetUserChoice();
    }
}

static void DisplayInstructions(){
    Console.Clear();
    StreamReader inFile = new StreamReader("instructions.txt");
    string line = inFile.ReadLine();
    while (line != null){
        System.Console.WriteLine(line);
        line = inFile.ReadLine();
    }
    inFile.Close();
}

static void DisplayMenu(){
    //Console.Clear();
    StreamReader inFile = new StreamReader("menu.txt");
    string line = inFile.ReadLine();
    while (line != null){
        System.Console.WriteLine(line);
        line = inFile.ReadLine();
    }
    inFile.Close();
}

static bool IsGameOver(int credits){
    if (credits <=0){
        System.Console.WriteLine("You have lost all your money. Time to go home.");
        return true;
    }
    else if (credits >= 300){
        System.Console.WriteLine("You have won the game.");
        return true;
    }
    else return false;
}

static bool IsValidChoice(string userChoice){
    if (userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4") return true;
    else if (userChoice =="5" || userChoice == "6" || userChoice == "7" || userChoice == "8") return true;
    else return false;
}

static void PauseAction(){
    System.Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
}

static void Route(int userChoice, ref int credits){
    if (userChoice == 1){
       PlayGuessTen(ref credits);
    }
    else if (userChoice == 2){
        if (credits >= 20)PlayLuckyDice(ref credits);
        else   System.Console.WriteLine("You do not have enough credits to play Lucky Dice. Please select another option");
    }
    else if (userChoice == 3){
        if (credits >=5) PlayRPS(ref credits);
        else System.Console.WriteLine("You do not have enough credits to play Lucky Dice. Please select another option");
    }
    else if (userChoice == 4){
        if (credits >= 10) PlaySlots(ref credits);
        else System.Console.WriteLine("You do not have enough credits to play Slots. Please select another option");  
    }
    else if (userChoice == 5){
        if (credits >= 10) PlayGridSlots(ref credits);
        else System.Console.WriteLine("You do not have enough credits to play Slots. Please select another option");  
    }
    else if (userChoice == 6){
        DisplayInstructions();
    }
    else{
        ScoreBoard(credits);
    }
}

static void PlayGuessTen(ref int credits){
    Console.Clear();
    GuessTen g10Game = new GuessTen();

    g10Game.SetCredits(credits);
    g10Game.PlaceBet();
    g10Game.FillDeck();
    g10Game.AssignCardValues();
    g10Game.RunGuessTen();

    int creditChange = g10Game.CreditChange();
    credits += creditChange;
    
    bool again = PlayAgain(credits);
    if (again) PlayGuessTen(ref credits);
}

static void PlayLuckyDice(ref int credits){
    Console.Clear();
    
    LuckyDice ldGame = new LuckyDice();
    ldGame.SetCredits(credits);
    ldGame.PlaceBet();
    ldGame.RunLuckyDice();

    int creditChange = ldGame.CreditChange();
    credits += creditChange;

    if (credits >= 20){
        bool again = PlayAgain(credits);
        if (again) PlayLuckyDice(ref credits);
    }
    else System.Console.WriteLine("You do not have enough credits to play this game again. Routing to main menu");

}

static void PlayRPS(ref int credits){
    Console.Clear();
    
    RPS rpsGame = new RPS();
    rpsGame.SetCredits(credits);
    rpsGame.PlaceBet();
    rpsGame.RunRPS();

    int creditChange = rpsGame.CreditChange();
    credits += creditChange;

    if (credits >= 5){
        bool again = PlayAgain(credits);
        if (again) PlayRPS(ref credits);
    }
    else System.Console.WriteLine("You do not have enough credits to play this game again. Routing to main menu");
}

static void PlaySlots(ref int credits){
    Console.Clear();

    Slots slotsGame = new Slots();
    slotsGame.SetCredits(credits);
    slotsGame.RunSLots();

    credits += slotsGame.CreditChange();

    if (credits >= 10){
        bool again = PlayAgain(credits);
        if (again) PlaySlots(ref credits);
    }
    else System.Console.WriteLine("You do not have enough credits to play this game again. Routing to main menu");
}

static void PlayGridSlots(ref int credits){
    Console.Clear();

    GridSlots slotsGame = new GridSlots();
    slotsGame.SetCredits(credits);
    slotsGame.RunGridSLots();

    credits += slotsGame.CreditChange();
    if (credits >= 10){
        bool again = PlayAgain(credits);
        if (again) PlaySlots(ref credits);
    }
    else System.Console.WriteLine("You do not have enough credits to play this game again. Routing to main menu");

}

static bool PlayAgain(int credits){
    if (credits <= 0){
        System.Console.WriteLine("\nYou are out of credits.");
        return false;
    }
    if (credits >= 300){
        System.Console.WriteLine("\nYou have reached the goal of 300 credits!");
        return false;
    }

    System.Console.WriteLine("\nWould you like to play again?");
    System.Console.WriteLine("Enter y for yes.\nEnter n for no.");
    string input = Console.ReadLine();
    if (input == "y") return true;
    else if (input == "n") return false;
    else {
        System.Console.WriteLine("This is not a valid input. Please try again");
        return PlayAgain(credits);
    }
}

static void ScoreBoard(int credits){
    Console.Clear();
    System.Console.WriteLine($"You currently have {credits} credits");
    System.Console.WriteLine($"You need {300-credits} more credits to win");
}