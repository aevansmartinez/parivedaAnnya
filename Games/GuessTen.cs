namespace parivedaAnnya.Games
{
    public class GuessTen
    {
        int bet;  
        int credits;
        string[] cards = new string[52];
        int[] cardsRank = new int[52];  
        int[] random11 = {};
        int numCorrect;
        public void SetCredits(int credits){
            this.credits = credits;
        }
        public void PlaceBet(){
            System.Console.WriteLine("Enter how many credits you wish to bet.");
            string input = Console.ReadLine();
            int x;
            if(int.TryParse(input, out x)){
                if (x > credits){
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
        public void RunGuessTen(){
            random11 = GetRandomIndexes(11);
            numCorrect = HigherOrLower();
        }
        public void FillDeck(){ 
            string[] suits = {"hearts", "diamonds", "club", "spades"};
            string[] values = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};      
            int k = 0;
            for (int i = 0; i < 13; i++){
                for (int j =0; j<4; j++){
                    cards[k] = values[i] + " of " + suits[j];
                    k++;
                }
            }
        }
        public void AssignCardValues(){
            string temp;
            for (int i = 0; i < cards.Length; i++){
                temp = cards[i].Substring(0, 1);

                if (temp == "A") cardsRank[i] = 1;
                else if (temp == "1") cardsRank[i] = 10;
                else if (temp == "J") cardsRank[i] = 11;
                else if (temp == "Q") cardsRank[i] = 12;      
                else if (temp == "K") cardsRank[i] = 13;
                else cardsRank[i] = Convert.ToInt16(temp);
            }
        }
        private int[] GetRandomIndexes(int numCards){
            Random rand = new Random();
            List<int> listNumbers = new List<int>();
            int number;

            for (int i = 0; i < numCards; i++){
                do {
                    number = rand.Next(52);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            int[] indexes = listNumbers.ToArray();
            
            return indexes;
        }
        private int HigherOrLower(){
            bool correct = true;
            int num = 0;
            while (correct == true && num < 10){     
                System.Console.WriteLine($"\nThe card is {cards[random11[num]]}. Do you think the next card is higher or lower?"); 
                correct = CheckIfCorrect(num);
                if (correct) num++;
                else System.Console.WriteLine("\nYou guessed wrong. Game over.");
            }
            
            System.Console.WriteLine($"You guessed correctly {num} times.");
            return num;
        }
        private bool CheckIfCorrect(int num){
            System.Console.WriteLine("Enter h for higher.\nEnter l for lower.");
            string userChoice = Console.ReadLine();
            
            if (userChoice == "h" && cardsRank[random11[num+1]] <= cardsRank[random11[num]]){
                return false;
            }
            else if (userChoice == "l" && cardsRank[random11[num+1]] >= cardsRank[random11[num]]){
                return false;
            }
            else if (userChoice != "h" && userChoice != "l"){
                System.Console.WriteLine("This is not a valid input. Please try again");
                return CheckIfCorrect (num);
            }
            else return true;
        }
        public int CreditChange(){
            if (numCorrect == 10) return bet*3;
            else if (numCorrect >= 7) return bet*2;
            else if (numCorrect >= 5) return 0;
            else return bet*-1;
        }
    }
}