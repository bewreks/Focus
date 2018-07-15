using System;
using System.Collections;
using System.Collections.Generic;

namespace Focus
{
    public class Deck : IEnumerable
    {
        private List<Card> _cards;

        public Card this[int i] => _cards[i];

        public Deck()
        {
            _cards = new List<Card>();
        }

        public int Length => _cards.Count;

        public void Push(Card card)
        {
            _cards.Add(card);
        }

        public void Push(Deck deck)
        {
            foreach (Card card in deck)
            {
                Push(card);
            }
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public void Shuffle()
        {
            var random = new Random();
            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                var j = random.Next(i);
                var card = _cards[j];
                _cards[j] = _cards[i];
                _cards[i] = card;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new DeckEnum(_cards);
        }
    }

    public class DeckEnum : IEnumerator
    {
        private List<Card> _cards;
        
        private int position = -1;

        public DeckEnum(List<Card> cards)
        {
            _cards = cards;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _cards.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current {
            get
            {
                try
                {
                    return _cards[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}