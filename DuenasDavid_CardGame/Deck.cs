using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertedJSON
{

    class Deck
    {
        public static string[] faces;
        public static int[] points;

        private Card[] deck;
        private int currentCard;
        private const int NumberOfCards = 52;
        private Random randomNumber;

        public Deck()
        {
         string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
         int[] points = { 15, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 12, 12 };
         
        string[] suits = { "Hearts", "Clubs", "Spades", "Diamonds" };
         
       

            deck = new Card[NumberOfCards];
            currentCard = 0;
            randomNumber = new Random();
            string totalPoints;

            for (int counter = 0; counter < deck.Length; counter++)
                deck[counter] = new Card(faces[counter % 11], suits[counter / 13], points[counter % 11]);

            



            
          
        }
 

            public  void Shuffle()
            {
                currentCard = 0;
                for(int start = 0; start < deck.Length; start++)
                {
                    int end = randomNumber.Next(NumberOfCards);
                    Card temporary = deck[start];
                    deck[start] = deck[end];
                    deck[end] = temporary;
                }
            }

        public Card DealCard()
        {
            if (currentCard < deck.Length)
              
                return deck[currentCard++];

            
          
            
            else
                return null;
        }
        
       
        }
    }

