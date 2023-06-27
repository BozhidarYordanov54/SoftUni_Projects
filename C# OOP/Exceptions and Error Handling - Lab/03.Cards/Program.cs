namespace Cards
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] cards = Console.ReadLine().Split(", ");

            List<Card> cardList = new List<Card>();

            for (int i = 0; i < cards.Length; i++)
            {
                string[] currentCard = cards[i].Split(" ");
                try
                {
                    string face = currentCard[0].ToUpper();
                    string suit = currentCard[1].ToUpper();

                    Card card = new Card(face, suit);

                    cardList.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Card card in cardList)
            {
                Console.Write($"{card.ToString()} ");
            }
        }
    }
}