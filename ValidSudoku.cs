//https://leetcode.com/problems/valid-sudoku/description/

using NUnit.Framework;

namespace LeetCode
{
    public class ValidSudoku
    {
        private bool IsValidSudoku(char[][] board)
        {
            return CheckRows(board) && CheckColumns(board) && CheckCells(board);
        }

        private bool CheckRows(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var rowSet = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    var value = board[i][j];
                    if (value == '.') continue;
                    if (!rowSet.Add(value)) return false;
                }
            }

            return true;
        }

        private bool CheckColumns(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var columnSet = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    var value = board[j][i];
                    if (value == '.') continue;
                    if (!columnSet.Add(value)) return false;
                }
            }

            return true;
        }

        private bool CheckCells(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var topLeftCornerVert = i / 3 * 3;
                var topLeftCornerHor = i % 3 * 3;
                var cellsSet = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    var vertical = topLeftCornerVert + j / 3;
                    var horizontal = topLeftCornerHor + j % 3;
                    var value = board[vertical][horizontal];
                    if (value == '.') continue;
                    if (!cellsSet.Add(value)) return false;
                }
            }

            return true;
        }

        [Test]
        public void ValidSudoku_Test1()
        {
            char[][] board =
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            Assert.IsTrue(IsValidSudoku(board));
        }

        [Test]
        public void ValidSudoku_Test2()
        {
            char[][] board =
            {
                new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            Assert.IsFalse(IsValidSudoku(board));
        }

        [Test]
        public void ValidSudoku_Test3()
        {
            char[][] board =
            {
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' }
            };
            Assert.IsTrue(IsValidSudoku(board));
        }

        [Test]
        public void ValidSudoku_Test4()
        {
            char[][] board =
            {
                new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
                new char[] { '4', '5', '6', '7', '8', '9', '1', '2', '3' },
                new char[] { '7', '8', '9', '1', '2', '3', '4', '5', '6' },
                new char[] { '2', '1', '4', '3', '6', '5', '8', '9', '7' },
                new char[] { '3', '6', '5', '2', '1', '4', '9', '7', '8' },
                new char[] { '8', '9', '7', '6', '4', '2', '3', '1', '5' },
                new char[] { '9', '7', '8', '5', '3', '1', '2', '4', '6' },
                new char[] { '5', '4', '2', '8', '9', '6', '1', '3', '7' },
                new char[] { '6', '3', '1', '9', '7', '8', '5', '2', '4' }
            };
            Assert.IsFalse(IsValidSudoku(board));
        }

        [Test]
        public void ValidSudoku_Test5()
        {
            char[][] board =
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '9' },
                new char[] { '6', '.', '4', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '5', '.', '.', '6', '.' },
                new char[] { '8', '5', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '8', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            Assert.IsFalse(IsValidSudoku(board));
        }

        [Test]
        public void ValidSudoku_Test6()
        {
            char[][] board =
            {
                new char[] { '1', '2', '3', '.', '.', '.', '.', '.', '.' },
                new char[] { '4', '5', '6', '.', '.', '.', '.', '.', '.' },
                new char[] { '7', '8', '9', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '1', '2', '3', '.', '.', '.' },
                new char[] { '.', '.', '.', '4', '5', '6', '.', '.', '.' },
                new char[] { '.', '.', '.', '7', '8', '9', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '1', '2', '3' },
                new char[] { '.', '.', '.', '.', '.', '.', '4', '5', '6' },
                new char[] { '.', '.', '.', '.', '.', '.', '7', '8', '9' }
            };
            Assert.IsTrue(IsValidSudoku(board));
        }
    }
}