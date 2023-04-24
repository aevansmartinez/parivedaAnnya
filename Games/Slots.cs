namespace parivedaAnnya.Games
{
    public class Slots{
        Random random = new Random();

        int credits;
        int winnings;
        public void SetCredits(int credits){
            this.credits = credits;
        }
        
        public void RunSLots(){
            System.Console.WriteLine("Welcome to slots!");    
            System.Console.Write("Press enter");
            Console.ReadKey();
            
            int num1 = random.Next(4, 10);
            int num2 = random.Next(4, 10);
            int num3 = random.Next(4, 10);
            
            System.Console.WriteLine($"[{num1}] [{num2}] [{num3}]");
            
            if (num1 == num2 && num2 == num3){   
                DetermineWinnings(num1);
                Console.WriteLine($"Congratulations! You won {winnings} credits.");
            }
            else{
                Console.WriteLine("Sorry, no win this time.");
                winnings = -10;
            }    
        }
        private void DetermineWinnings(int num){
            if (num == 7) winnings = 200;
            else if (num == 8) winnings = 150;
            else if (num == 9) winnings = 125;
            else if (num == 10) winnings = 100;
            else winnings = 75;
        }
        public int CreditChange(){
            return winnings;
        }
        
    }
}