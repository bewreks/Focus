using System;

namespace Focus
{
    public class FocusGame
    {
        private Deck _focusDeck;
        private Deck _mainDeck;
        private Deck[] _decks;

        public void Start()
        {
            _decks = new[] {new Deck(), new Deck(), new Deck()};
            _mainDeck = new Deck();
            _focusDeck = new Deck();
            
            FillMainDeck();

            while (true)
            {
                Console.Clear();
                
                _mainDeck.Shuffle();
                
                FillFocusDeck();

                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();
                    
                    FillDecks();
                    PrintDecks();
                    CombineDecks(DoChoise());
                }

                Console.Clear();
                
                Console.WriteLine("Твой выбор: " + _focusDeck[10]);
                _focusDeck.Clear();

                Console.WriteLine("Для продолжения нажми любую кнопку");
                Console.ReadKey(true);
            }
        }

        private static int DoChoise()
        {
            int result = 0;
            Console.WriteLine("Выбери столбец (1-3):");
            var readed = true;
            while (readed)
            {
                readed = false;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        result = 0;
                        break;
                    case ConsoleKey.D2:
                        result = 1;
                        break;
                    case ConsoleKey.D3:
                        result = 2;
                        break;
                    default:
                        readed = true;
                        break;
                }
            }

            return result;
        }

        private void CombineDecks(int result)
        {
            switch (result)
            {
                case 0:
                    _focusDeck.Push(_decks[2]);
                    _focusDeck.Push(_decks[0]);
                    _focusDeck.Push(_decks[1]);
                    break;
                case 1:
                    _focusDeck.Push(_decks[2]);
                    _focusDeck.Push(_decks[1]);
                    _focusDeck.Push(_decks[0]);
                    break;
                case 2:
                    _focusDeck.Push(_decks[0]);
                    _focusDeck.Push(_decks[2]);
                    _focusDeck.Push(_decks[1]);
                    break;
            }
            
            foreach (var pile in _decks)
            {
                pile.Clear();
            }
        }

        private void PrintDecks()
        {
            for (int i = 0; i < _decks[0].Length; i++)
            {
                _decks[0][i].Print();
                Console.Write("   ");
                _decks[1][i].Print();
                Console.Write("   ");
                _decks[2][i].Print();
                Console.Write("   ");
                Console.WriteLine();
            }
        }

        private void FillDecks()
        {
            for (int i = 0; i < _focusDeck.Length; i++)
            {
                var card = _focusDeck[i];
                var t = i % 3;
                _decks[t].Push(card);
            }

            _focusDeck.Clear();
        }

        private void FillFocusDeck()
        {
            for (int i = 0; i < 21; i++)
            {
                _focusDeck.Push(_mainDeck[i]);
            }
        }

        private void FillMainDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                var card = new Card((Card.CardSuit) (i % 4), (Card.CardNumbers)(i % 13));
                _mainDeck.Push(card);
            }
        }
    }
}