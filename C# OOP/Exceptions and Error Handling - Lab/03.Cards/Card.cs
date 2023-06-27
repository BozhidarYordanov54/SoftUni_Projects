namespace Cards
{
    public class Card
    {
        private string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] validSuits = { "S", "H", "D", "C" };

        private string face;
        private string suits;
        private bool isValid = true;

        public Card(string face, string suits)
        {
            Face = face;
            Suit = suits;
        }

        protected string Face
        {
            get { return face; }
            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }

        protected string Suit
        {
            get { return suits; }
            private set
            {
                if (!validSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                CreateSymbol(value);
            }
        }
        public override string ToString() => $"[{Face}{Suit}]";

        private void CreateSymbol(string value)
        {
            if (value == "S")
            {
                suits = "\u2660";
            }
            else if (value == "H")
            {
                suits = "\u2665";
            }
            else if (value == "D")
            {
                suits = "\u2666";
            }
            else if (value == "C")
            {
                suits = "\u2663";
            }
        }

        
    }
}