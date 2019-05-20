using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleScore
{
    public class Word : IWord
    {
        public char[] Letters { get; set; }
        public string WrittenWord { get; set; }
        public Word(string word)
        {
            WrittenWord = word;
            Letters = word.ToCharArray();
        }
        public int CalculateScore()
        {
            int CurrentScore = 0;
            CurrentScore += GetLetterPoints();
            CurrentScore *= GetMultiplier();
            if (BonusPoints() == true)
            {
                CurrentScore += 3;
            }
            return CurrentScore;
        }

        private bool BonusPoints()
        {
            for (int i = 1; i < Letters.Length; i++)
                if (i != 0)
                {
                    if (Letters[i - 1] == Letters[i])
                        return true;
                }
            return false;
        }

        private int GetMultiplier()
        {
            int multiplier = 1;

            if (Letters.Length != 0)
            {
                if (Letters.Length <= 4)
                {
                    return multiplier;
                }
                else if (Letters.Length <= 6)
                {
                    return 2;
                }
                else if (Letters.Length <= 9)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
            return multiplier;
        }

        private int GetLetterPoints()
        {
            int score = 0;
            foreach (char letter in Letters)
            {
                switch (letter)
                {
                    case 'a':
                    case 'e':
                    case 'o':
                    case 's':
                        score += 1;
                        break;
                    case 'c':
                    case 'f':
                    case 'g':
                    case 'i':
                    case 'l':
                    case 'r':
                    case 't':
                    case 'u':
                    case 'd':
                        score += 2;
                        break;
                    case 'h':
                    case 'k':
                    case 'm':
                    case 'n':
                        score += 3;
                        break;
                    case 'j':
                    case 'p':
                    case 'w':
                    case 'y':
                        score += 5;
                        break;
                    case 'q':
                        score += 7;
                        break;
                    case 'v':
                    case 'z':
                        score += 8;
                        break;
                }
            }
            return score;
        }
    }
}
