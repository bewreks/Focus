using System;

namespace Focus
{
    public class Card
    {
        public enum CardSuit
        {
            Diamonds, Spades, Hearts, Clubs 
        }

        public enum CardNumbers
        {
            Ace, 
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        public CardSuit Suit;
        public CardNumbers Number;

        public Card()
        {
            Suit = CardSuit.Diamonds;
            Number = CardNumbers.Ace;
        }

        public Card(CardSuit suit, CardNumbers number)
        {
            Suit = suit;
            Number = number;
        }

        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(this);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            var result = String.Empty;
            
            switch (Suit)
            {
                case CardSuit.Diamonds:
                    result += "♦";
                    break;
                case CardSuit.Clubs:
                    result += '♣';
                    break;
                case CardSuit.Spades:
                    result += "♠";
                    break;
                case CardSuit.Hearts:
                    result += "♥";
                    break;
            }
            
            switch (Number)
            {
                case CardNumbers.Ace:
                    result += "A ";
                    break;
                case CardNumbers.Two:
                    result += "2 ";
                    break;
                case CardNumbers.Three:
                    result += "3 ";
                    break;
                case CardNumbers.Four:
                    result += "4 ";
                    break;
                case CardNumbers.Five:
                    result += "5 ";
                    break;
                case CardNumbers.Six:
                    result += "6 ";
                    break;
                case CardNumbers.Seven:
                    result += "7 ";
                    break;
                case CardNumbers.Eight:
                    result += "8 ";
                    break;
                case CardNumbers.Nine:
                    result += "9 ";
                    break;
                case CardNumbers.Ten:
                    result += "10";
                    break;
                case CardNumbers.Jack:
                    result += "J ";
                    break;
                case CardNumbers.Queen:
                    result += "Q ";
                    break;
                case CardNumbers.King:
                    result += "K ";
                    break;
            }
            
            
            return result;
        }
    }
}