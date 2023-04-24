namespace parivedaAnnya.Games
{
    public class RPS
    {
        int bet;  
        int credits;
        string winner = ""; 
        string houseChoice = "";
        string userChoice = "";
        public void SetCredits(int credits){
            this.credits = credits;
        }
        public void PlaceBet(){
            System.Console.WriteLine("Your best must be a minimum of 5 and a maximum of 20 credits");
            System.Console.WriteLine("Enter how many credits you wish to bet.");
            string input = Console.ReadLine();
            int x;

            if(int.TryParse(input, out x)){
                if (x < 5 || x > 20){
                    System.Console.WriteLine("\nThis is not within the valid range you may bet. Please try again\n");
                    PlaceBet();
                }
                else if (x > credits){
                    System.Console.WriteLine($"\nYou do not have {x} credits. Please bet an amount less than or equal to {credits}.\n");
                    PlaceBet();
                }
                else bet = x;
            }
            else {
                System.Console.WriteLine("This is not a valid input. Please try again\n");
                PlaceBet();
            }
        }
        public void RunRPS(){
            houseChoice = GetHouseChoiceRPS();
            userChoice = GetUserChoiceRPS();
            DetermineWinner();
        }
        private string GetUserChoiceRPS(){
            System.Console.WriteLine("\nEnter r for rock\nEnter p for paper\nEnter s for scissors");
            string userChoice = Console.ReadLine();

            if (userChoice == "r") return "rock";
            else if (userChoice == "p") return "paper";
            else if (userChoice == "s") return "scissors";
            else{
                System.Console.WriteLine( "This is not a valid choice. Please try again.");
                return GetUserChoiceRPS();
            } 
        }
        private string GetHouseChoiceRPS(){
            string[] options = {"rock", "paper", "scissors"};
            
            Random rnd = new Random();
            int houseChoice = rnd.Next(3);

            return options[houseChoice];
        }
        private void DetermineWinner(){
            if (userChoice == houseChoice){
                System.Console.WriteLine("Tie! Redo");
                RunRPS();
            }
            else if(userChoice == "rock"){
                if (houseChoice == "scissors") winner = "player";
                else winner = "house";
            }
            else if (userChoice == "paper"){
                if (houseChoice == "rock") winner = "player";
                else winner = "house";
            }
            else { // (userChoice == "scissors")
                if (houseChoice == "paper") winner = "player";
                else winner = "house";
            }
        }
        public int CreditChange(){
            if (winner == "player"){
                System.Console.WriteLine("Congragulations, you won!");
                return bet;
            }
            else { //winner == "house"
                System.Console.WriteLine("You lost. Better luck next time.");
                return bet*-1;
            }
        }
    }
}