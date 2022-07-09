using System.Collections;
using System.Collections.Generic;

namespace Mill
{
    public class MillGame
    {
        #region Variables

        private readonly Dictionary<int, int[,]> _millPossibilities = new Dictionary<int, int[,]>
        {
            { 1, new[,] { { 2, 3 }, { 10, 22 } } },
            { 2, new[,] { { 1, 3 }, { 5, 8 } } },
            { 3, new[,] { { 1, 2 }, { 15, 24 } } },
            { 4, new[,] { { 5, 6 }, { 11, 19 } } },
            { 5, new[,] { { 4, 6 }, { 2, 8 } } },
            { 6, new[,] { { 4, 5 }, { 14, 21 } } },
            { 7, new[,] { { 8, 9 }, { 12, 16 } } },
            { 8, new[,] { { 7, 9 }, { 2, 5 } } },
            { 9, new[,] { { 7, 8 }, { 13, 18 } } },
            { 10, new[,] { { 11, 12 }, { 1, 22 } } },
            { 11, new[,] { { 10, 12 }, { 4, 19 } } },
            { 12, new[,] { { 10, 11 }, { 7, 16 } } },
            { 13, new[,] { { 14, 15 }, { 9, 18 } } },
            { 14, new[,] { { 13, 15 }, { 6, 21 } } },
            { 15, new[,] { { 13, 14 }, { 3, 24 } } },
            { 16, new[,] { { 17, 18 }, { 7, 12 } } },
            { 17, new[,] { { 16, 18 }, { 20, 23 } } },
            { 18, new[,] { { 16, 17 }, { 9, 13 } } },
            { 19, new[,] { { 20, 21 }, { 4, 11 } } },
            { 20, new[,] { { 19, 21 }, { 17, 23 } } },
            { 21, new[,] { { 19, 20 }, { 6, 14 } } },
            { 22, new[,] { { 23, 24 }, { 1, 10 } } },
            { 23, new[,] { { 22, 24 }, { 17, 20 } } },
            { 24, new[,] { { 22, 23 }, { 3, 15 } } }
        };

        private readonly Dictionary<int, int[]> _movePossibilities = new Dictionary<int, int[]>
        {
            { 1, new[] { 2, 10 } },
            { 2, new[] { 1, 3, 5 } },
            { 3, new[] { 2, 15 } },
            { 4, new[] { 5, 11 } },
            { 5, new[] { 2, 4, 6, 8 } },
            { 6, new[] { 5, 14 } },
            { 7, new[] { 8, 12 } },
            { 8, new[] { 7, 9, 5 } },
            { 9, new[] { 8, 13 } },
            { 10, new[] { 1, 11, 22 } },
            { 11, new[] { 4, 10, 12, 19 } },
            { 12, new[] { 7, 11, 16 } },
            { 13, new[] { 9, 14, 18 } },
            { 14, new[] { 6, 13, 15, 21 } },
            { 15, new[] { 3, 14, 24 } },
            { 16, new[] { 12, 17 } },
            { 17, new[] { 16, 18, 20 } },
            { 18, new[] { 13, 17 } },
            { 19, new[] { 11, 20 } },
            { 20, new[] { 17, 19, 21, 23 } },
            { 21, new[] { 14, 20 } },
            { 22, new[] { 10, 23 } },
            { 23, new[] { 20, 22, 24 } },
            { 24, new[] { 15, 23 } }
        };

        #endregion Variables

        #region Properties

        public Dictionary<int, Player> Board { get; } = new Dictionary<int, Player>();
        public int Turn { get; private set; } = 1;
        public int Black { get; private set; }
        public int White { get; private set; }
        public int BlackWins { get; private set; }
        public int WhiteWins { get; private set; }
        public bool IsTaking { get; private set; }

        #endregion Properties

        #region Methods

        public MillGame()
        {
            for (var i = 1; i <= 24; i++) Board.Add(i, Player.Empty);
            //TODO: create new game id DB
        }

        //TODO whatever that is
        /*public IList<Moves> GetPossibleMoves()
        {
            List<Moves> possibleMoves = new List<Moves>();
            if(IsTaking)
            {
                if(Turn % 2 == 0)
                {
                    foreach(KeyValuePair<int,Player> p in Board)
                    {
                        if(p.Value == Player.White)
                        {
                            possibleMoves.Add(new Moves { Move = MoveType.take, Parameter1 = p.Key, Parameter2 = 0 });
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, Player> p in Board)
                    {
                        if (p.Value == Player.Black)
                        {
                            possibleMoves.Add(new Moves { Move = MoveType.take, Parameter1 = p.Key, Parameter2 = 0 });
                        }
                    }
                }
            } else if(Turn > 18)
            {
                if (Turn % 2 == 0)
                {
                    foreach (KeyValuePair<int, Player> p in Board)
                    {
                        if (p.Value == Player.Black)
                        {
                            possibleMoves.Add(new Moves { Move = MoveType.take, Parameter1 = p.Key, Parameter2 = 0 });
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, Player> p in Board)
                    {
                        if (p.Value == Player.White)
                        {
                            possibleMoves.Add(new Moves { Move = MoveType.take, Parameter1 = p.Key, Parameter2 = 0 });
                        }
                    }
                }
            }
        }*/

        public Player Get(int position)
        {
            return Board[position];
        }

        public bool Set(int position, Player color)
        {
            if (Turn > 18 || Board[position] != Player.Empty || IsTaking) return false;
            if (color == Player.Black && Turn % 2 == 0)
            {
                Board[position] = color;
                Black++;
                IsTaking = CheckMill(position, color);
                Turn++;
                if (!IsTaking) SaveBoard();

                if (Turn == 19) CanMove();
                return true;
            }

            if (color == Player.White && Turn % 2 == 1)
            {
                Board[position] = color;
                White++;
                IsTaking = CheckMill(position, color);
                Turn++;
                if (!IsTaking) SaveBoard();

                return true;
            }

            return false;
        }

        public bool Set(int position, int color)
        {
            return Set(position, (Player)color);
        }

        public bool Move(int position, int target, Player color)
        {
            if (Turn <= 18 || Board[position] != color || IsTaking || Board[target] != Player.Empty) return false;
            if (color == Player.Black && Turn % 2 == 0)
            {
                if (Black > 4 && !((IList)_movePossibilities[position]).Contains(target)) return false;
                Board[position] = Player.Empty;
                Board[target] = color;
                IsTaking = CheckMill(target, color);
                Turn++;
                CanMove();
                if (!IsTaking) SaveBoard();

                return true;
            }

            if (color == Player.White && Turn % 2 == 1)
            {
                if (White > 4 && !((IList)_movePossibilities[position]).Contains(target)) return false;
                Board[position] = Player.Empty;
                Board[target] = color;
                IsTaking = CheckMill(target, color);
                Turn++;
                CanMove();
                if (!IsTaking) SaveBoard();

                return true;
            }

            return false;
        }

        public bool Move(int position, int target, int color)
        {
            return Move(position, target, (Player)color);
        }

        public bool Take(int position, Player color)
        {
            if (Board[position] == Player.Empty || !IsTaking) return false;
            var onlyMills = true;
            if (Board[position] == Player.Black && Turn % 2 == 0 && color == Player.White)
            {
                foreach (var field in Board)
                    if (field.Value == Player.Black && !CheckMill(field.Key, field.Value))
                    {
                        onlyMills = false;
                        break;
                    }

                if (!CheckMill(position, Player.Black) || onlyMills)
                {
                    Black--;
                    Board[position] = Player.Empty;
                    IsTaking = false;
                    CanMove();
                    SaveBoard();
                    if (Black < 3 && Turn > 18) Win(color);
                    return true;
                }

                return false;
            }

            if (Board[position] == Player.White && Turn % 2 == 1 && color == Player.Black)
            {
                foreach (var field in Board)
                    if (field.Value == Player.White && !CheckMill(field.Key, field.Value))
                    {
                        onlyMills = false;
                        break;
                    }

                if (!CheckMill(position, Player.White) || onlyMills)
                {
                    White--;
                    Board[position] = Player.Empty;
                    IsTaking = false;
                    CanMove();
                    SaveBoard();
                    if (White < 3 && Turn > 18) Win(color);
                    return true;
                }

                return false;
            }

            return false;
        }

        public bool Take(int position, int color)
        {
            return Take(position, (Player)color);
        }

        private void Win(Player color)
        {
            if (Turn > 100)
            {
                //no win
                //only saves the remaining pieces
            }
            else if (color == Player.White)
            {
                WhiteWins++;
            }
            else if (color == Player.Black)
            {
                BlackWins++;
            }

            //TODO: update game in DB to include winner
            White = 0;
            Black = 0;
            Turn = 1;
            //TODO: create new game and get the id that was auto incremented, save an Empty field with position 0
            for (var i = 1; i <= 24; i++) Board[i] = Player.Empty;
        }

        private bool CheckMill(int position, Player color)
        {
            return ((Board[_millPossibilities[position][0, 0]] == color &&
                     Board[_millPossibilities[position][0, 1]] == color) ||
                    (Board[_millPossibilities[position][1, 0]] == color &&
                     Board[_millPossibilities[position][1, 1]] == color)) &&
                   Board[position] == color;
        }

        private void SaveBoard()
        {
            /*foreach (var position in Board)
            {
                //TODO save Board to database
            }*/
        }

        private void CanMove()
        {
            var color = Turn % 2 == 0 ? Player.Black : Player.White;
            if (IsTaking) return;
            foreach (var field in Board)
                if (field.Value == color)
                    foreach (var moves in _movePossibilities[field.Key])
                        if (Board[moves] == Player.Empty)
                            return;
            Win(Turn % 2 == 0 ? Player.White : Player.Black);
        }

        #endregion Methods
    }
}