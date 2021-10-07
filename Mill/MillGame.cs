using System.Collections.Generic;
using System.Linq;

namespace Mill
{
    public class MillGame
    {
        #region Variables

        private readonly Dictionary<int, int[,]> MillPossibilities = new Dictionary<int, int[,]>{
            {1, new int[,] { { 2, 3 }, { 10, 22 } }},
            {2, new int[,] { { 1, 3 }, { 5, 8 } }},
            {3, new int[,] { { 1, 2 }, { 15, 24 } }},
            {4, new int[,] { { 5, 6 }, { 11, 19 } }},
            {5, new int[,] { { 4, 6 }, { 2, 8 } }},
            {6, new int[,] { { 4, 5 }, { 14, 21 } }},
            {7, new int[,] { { 8, 9 }, { 12, 16 } }},
            {8, new int[,] { { 7, 9 }, { 2, 5 } }},
            {9, new int[,] { { 7, 8 }, { 13, 18 } }},
            {10,new int[,] { { 11, 12 }, { 1, 22 } }},
            {11,new int[,] { { 10, 12 }, { 4, 19 } }},
            {12,new int[,] { { 10, 11 }, { 7, 16 } }},
            {13,new int[,] { { 14, 15 }, { 9, 18 } }},
            {14,new int[,] { { 13, 15 }, { 6, 21 } }},
            {15,new int[,] { { 13, 14 }, { 3, 24 } }},
            {16,new int[,] { { 17, 18 }, { 7, 12 } }},
            {17,new int[,] { { 16, 18 }, { 20, 23 } }},
            {18,new int[,] { { 16, 17 }, { 9, 13 } }},
            {19,new int[,] { { 20, 21 }, { 4, 11 } }},
            {20,new int[,] { { 19, 21 }, { 17, 23 } }},
            {21,new int[,] { { 19, 20 }, { 6, 14 } }},
            {22,new int[,] { { 23, 24 }, { 1, 10 } }},
            {23,new int[,] { { 22, 24 }, { 17, 20 } }},
            {24,new int[,] { { 22, 23 }, { 3, 15 } }},
        };

        private readonly Dictionary<int, int[]> MovePossibilities = new Dictionary<int, int[]>{
            {1, new int[] { 2, 10 }},
            {2, new int[] { 1, 3, 5 }},
            {3, new int[] { 2, 15 }},
            {4, new int[] { 5, 11 }},
            {5, new int[] { 2, 4, 6, 8 }},
            {6, new int[] { 5, 14 }},
            {7, new int[] { 8, 12 }},
            {8, new int[] { 7, 9, 5 }},
            {9, new int[] { 8, 13 }},
            {10,new int[] { 1, 11, 22 }},
            {11,new int[] { 4, 10, 12, 19 }},
            {12,new int[] { 7, 11, 16 }},
            {13,new int[] { 9, 14, 18 }},
            {14,new int[] { 6, 13, 15, 21 }},
            {15,new int[] { 3, 14, 24 }},
            {16,new int[] { 12, 17 }},
            {17,new int[] { 16, 18, 20 }},
            {18,new int[] { 13, 17 }},
            {19,new int[] { 11, 20 }},
            {20,new int[] { 17, 19, 21, 23 }},
            {21,new int[] { 14, 20 }},
            {22,new int[] { 10, 23 }},
            {23,new int[] { 20, 22, 24 }},
            {24,new int[] { 15, 23 }},
        };

        #endregion Variables

        #region Properties

        public Dictionary<int, Color> Field { get; } = new Dictionary<int, Color>();
        public int Turn { get; private set; } = 1;
        public int Black { get; private set; } = 0;
        public int White { get; private set; } = 0;
        public int BlackWins { get; private set; } = 0;
        public int WhiteWins { get; private set; } = 0;
        public bool IsTaking { get; private set; } = false;

        #endregion Properties

        #region Methods

        public MillGame()
        {
            for (int i = 1; i <= 24; i++)
            {
                Field.Add(i, Color.empty);
            }
        }

        public Color Get(int position)
        {
            return Field[position];
        }

        public bool Set(int position, Color color)
        {
            if (Turn > 18 || Field[position] != Color.empty || IsTaking)
            {
                return false;
            }
            if (color == Color.black && Turn % 2 == 0)
            {
                Field[position] = color;
                Black++;
                IsTaking = CheckMill(position, color);
                Turn++;
                if (Turn == 19)
                {
                    CanMove();
                }
                return true;
            }
            else if (color == Color.white && Turn % 2 == 1)
            {
                Field[position] = color;
                White++;
                IsTaking = CheckMill(position, color);
                Turn++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Set(int position, int color)
        {
            return Set(position, (Color)color);
        }

        public bool Move(int position, int target, Color color)
        {
            if (Turn <= 18 || Field[position] != color || IsTaking || Field[target] != Color.empty)
            {
                return false;
            }
            if (color == Color.black && Turn % 2 == 0)
            {
                if (Black > 4 && !MovePossibilities[position].Contains(target))
                {
                    return false;
                }
                Field[position] = Color.empty;
                Field[target] = color;
                IsTaking = CheckMill(target, color);
                Turn++;
                CanMove();
                return true;
            }
            else if (color == Color.white && Turn % 2 == 1)
            {
                if (White > 4 && !MovePossibilities[position].Contains(target))
                {
                    return false;
                }
                Field[position] = Color.empty;
                Field[target] = color;
                IsTaking = CheckMill(target, color);
                Turn++;
                CanMove();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Move(int position, int target, int color)
        {
            return Move(position, target, (Color)color);
        }

        public bool Take(int position, Color color)
        {
            if (Field[position] == Color.empty || !IsTaking)
            {
                return false;
            }
            bool onlyMills = true;
            if (Field[position] == Color.black && Turn % 2 == 0 && color == Color.white)
            {
                foreach (KeyValuePair<int, Color> field in Field)
                {
                    if (field.Value == Color.black && !CheckMill(field.Key, field.Value))
                    {
                        onlyMills = false;
                        break;
                    }
                }
                if (!CheckMill(position, Color.black) || onlyMills)
                {
                    Black--;
                    Field[position] = Color.empty;
                    IsTaking = false;
                    CanMove();
                    if (Black < 3 && Turn > 18)
                    {
                        Win(color);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Field[position] == Color.white && Turn % 2 == 1 && color == Color.black)
            {
                foreach (KeyValuePair<int, Color> field in Field)
                {
                    if (field.Value == Color.white && !CheckMill(field.Key, field.Value))
                    {
                        onlyMills = false;
                        break;
                    }
                }
                if (!CheckMill(position, Color.white) || onlyMills)
                {
                    White--;
                    Field[position] = Color.empty;
                    IsTaking = false;
                    CanMove();
                    if (White < 3 && Turn > 18)
                    {
                        Win(color);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Take(int position, int color)
        {
            return Take(position, (Color)color);
        }

        private void Win(Color color)
        {
            if (color == Color.white)
            {
                WhiteWins++;
            }
            else if (color == Color.black)
            {
                BlackWins++;
            }
            White = 0;
            Black = 0;
            Turn = 1;
            for (int i = 1; i <= 24; i++)
            {
                Field[i] = Color.empty;
            }
        }

        private bool CheckMill(int position, Color color)
        {
            return ((Field[MillPossibilities[position][0, 0]] == color && Field[MillPossibilities[position][0, 1]] == color) ||
                   (Field[MillPossibilities[position][1, 0]] == color && Field[MillPossibilities[position][1, 1]] == color)) &&
                   Field[position] == color;
        }

        private void CanMove()
        {
            Color color;
            if (Turn % 2 == 0)
            {
                color = Color.black;
            }
            else
            {
                color = Color.white;
            }
            if (IsTaking)
            {
                return;
            }
            foreach (KeyValuePair<int, Color> field in Field)
            {
                if (field.Value == color)
                {
                    foreach (int moves in MovePossibilities[field.Key])
                    {
                        if (Field[moves] == Color.empty)
                        {
                            return;
                        }
                    }
                }
            }
            if (Turn % 2 == 0)
            {
                Win(Color.white);
            }
            else
            {
                Win(Color.black);
            }
        }

        #endregion Methods
    }
}