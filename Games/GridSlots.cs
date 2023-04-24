namespace parivedaAnnya.Games
{
    public class GridSlots
    {
        Random random = new Random();
        int credits;
        int winnings;
        int[,] nums = new int[3,3];
        public void SetCredits(int credits){
            this.credits = credits;
        }
        public void RunGridSLots(){    
            System.Console.WriteLine("Welcome to Grid Slots!\nIt's like Bingo and Slots put together");    
            System.Console.Write("Press enter");
            Console.ReadKey();
            
            for (int row = 0; row < 3; row++){
                for (int col = 0; col < 3; col++){
                    nums[row, col] = random.Next(1, 4);
                }
            }
            Console.WriteLine($"[{nums[0,0]}] [{nums[0,1]}] [{nums[0,2]}]");
            Console.WriteLine($"[{nums[1,0]}] [{nums[1,1]}] [{nums[1,2]}]");
            Console.WriteLine($"[{nums[2,0]}] [{nums[2,1]}] [{nums[2,2]}]");

            CheckIfWon();
        }
        private void CheckIfWon(){
            if (nums[0,0] == nums[0,1] && nums[0,1] == nums[0,2]){
                winnings = nums[0,0] * 16;
                Console.WriteLine($"Lucky duck! You won {winnings} credits.");
            }
            else if (nums[1,0] == nums[1,1] && nums[1,1] == nums[1,2]){
                winnings = nums[1,0] * 16;
                Console.WriteLine($"Lucky duck! You won {winnings} credits.");
            }
            else if (nums[2,0] == nums[2,1] && nums[2,1] == nums[2,2]){
                winnings = nums[2,0] * 16;
                Console.WriteLine($"Lucky duck! You won {winnings} credits.");
            }
            else if (nums[0,0] == nums[1,1] && nums[1,1] == nums[2,2]){
                winnings = nums[0,0] * 16;
                Console.WriteLine($"Lucky duck! You won {winnings} credits.");
            }
            else if (nums[2,0] == nums[1,1] && nums[1,1] == nums[0,2]){
                winnings = nums[2,0] * 16;
                Console.WriteLine($"Luck duck! You won {winnings} credits.");
            }
            else{
                Console.WriteLine("Sorry, you didn't win.");
                winnings = -10;
            }
        }

        public int CreditChange(){
            return winnings;
        }
    }
}