namespace parivedaAnnya.Games
{
    public class LuckyDice
    {
        int bet;  
        int credits;
        int roundsCompWon;
        int roundsUserWon;
        string winner = ""; 
        public void SetCredits(int credits){
            this.credits = credits;
        }
        public void PlaceBet(){
            System.Console.WriteLine("Your best must be a minimum of 20 and a maximum of 50 credits");
            System.Console.WriteLine("Enter how many credits you wish to bet.");
            string input = Console.ReadLine();
            int x;

            if(int.TryParse(input, out x)){
                if (x < 20 || x > 50){
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
        public void RunLuckyDice(){
            roundsCompWon = 0;
            roundsUserWon = 0;

            int computerSum = Roll6Dice();
            int userSum = Roll6Dice();
            
            while(roundsCompWon < 3 && roundsUserWon < 3){
                System.Console.WriteLine($"\nThe sum of your rolls is {userSum}; the sum of the computer dice rolls is {computerSum}.");
                
                if (computerSum >= userSum) {
                    System.Console.WriteLine("You lost this round. Better luck next time.");
                    roundsCompWon ++;
                }
                else {
                    System.Console.WriteLine("You won this round.");
                    roundsUserWon++;
                }
                
                computerSum = Roll6Dice();
                userSum = Roll6Dice();
            }
            DetermineWinner();
        }
        private int Roll6Dice(){
            Random rnd = new Random();
            int sum = 0;
            for (int i = 0; i < 6; i++){
                sum += rnd.Next(1,7);
            }
            return sum;
        }
        private void DetermineWinner(){
            if (roundsCompWon> roundsUserWon) 
                winner = "computer";
            else 
                winner = "player";
        }
        public int CreditChange(){
            if (winner == "player"){
                System.Console.WriteLine("\nCongragulations, you won!");
                return bet;
            }
            else { //winner == "house"
                System.Console.WriteLine("\nYou lost. Better luck next time.");
                return bet*-1;
            }
        }
    }
}