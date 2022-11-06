using System;
using System.Collections.Generic;
using System.Linq;

namespace task03_Cards
{
    class Card
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        private string face;
        private string suit;
        public Card(string dace, string suit)
        {
            Face = dace;
            Suit = suit;
        }
        public string Face {
            get {return face;}
            set
            {
                if (value != "2" && value != "3" && value != "4" && value != "5" && value != "6"
                    && value != "7" && value != "8" && value != "9" && value != "10" && value != "J"
                    && value != "Q" && value != "K" && value != "A")
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }

        }
        public string Suit {
            get { return suit;}
            set
            {
                switch (value)
                {
                    case "S":
                        suit = '\u2660'.ToString();
                        break;
                    case "H":
                        suit = '\u2665'.ToString();
                        break;
                    case "D":
                        suit = '\u2666'.ToString();
                        break;
                    case "C":
                        suit = '\u2663'.ToString();
                        break;
                    default:
                        throw new ArgumentException("Invalid card!");
                }
            }
        }
        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string[] cardsInput = Console.ReadLine().Split(", ");
            List<Card> cards = new List<Card>();
            for (int i = 0; i < cardsInput.Length; i++)
            {
                string[] token = cardsInput[i].Split();
                try
                {
                    Card card = new Card(token[0], token[1]);
                    cards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }
        
    }
    
}
