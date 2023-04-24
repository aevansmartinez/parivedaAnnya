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
            
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            int num3 = random.Next(1, 10);
            
            System.Console.WriteLine($"[{num1}] [{num2}] [{num3}]");
            
            if (num1 == num2 && num2 == num3){   
                DetermineWinnings(num1);
                Console.WriteLine($"Congratulations! You won {winnings} credits.");
            }
            else{
                Console.WriteLine("Sorry, no win this time.");
                winnings = 0;
            }    
        }
        private void DetermineWinnings(int reel){
            if (reel == 7) winnings = 400;
            else if (reel == 8) winnings = 350;
            else if (reel == 9) winnings = 325;
            else if (reel == 10) winnings = 300;
            else winnings = 250;
        }
        public int CreditChange(){
            return winnings;
        }
        
    }
}