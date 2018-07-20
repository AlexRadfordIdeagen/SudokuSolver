using System;

namespace SudokuSolving
{
    class Program
    {
        static void Main()
        {
            int[,] puzzle = {
    { 0, 0, 0, 0, 0, 2, 1, 0, 0 },
    { 0, 0, 4, 0, 0, 8, 7, 0, 0 },
    { 0, 2, 0, 3, 0, 0, 9, 0, 0 },
    { 6, 0, 2, 0, 0, 3, 0, 4, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 5, 0, 6, 0, 0, 3, 0, 1 },
    { 0, 0, 3, 0, 0, 5, 0, 8, 0 },
    { 0, 0, 8, 2, 0, 0, 5, 0, 0 },
    { 0, 0, 9, 7, 0, 0, 0, 0, 0 }
};


            Console.WriteLine("Your puzzle is:");
            PrintSudoku(puzzle);
            Console.ReadLine();

            if (SolveSudoku(puzzle, 0, 0))
                PrintSudoku(puzzle);

            Console.ReadLine();
        }
        public static void PrintSudoku(int[,] puzzle)
        {

            for (int i = 1; i < 10; ++i)
            {
                for (int j = 1; j < 10; ++j)
                    Console.Write("|{0}", puzzle[i - 1, j - 1]);

                Console.WriteLine("|");
                if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+");
            }
        }

        public static bool SolveSudoku(int[,] puzzle, int row, int col)
        {   
            if (row < 9 && col < 9)
            {
                if (puzzle[row, col] != 0)
                {
                    if ((col + 1) < 9) return SolveSudoku(puzzle, row, col + 1);
                    else if ((row + 1) < 9) return SolveSudoku(puzzle, row + 1, 0);
                    else return true;
                }
                else
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (IsAvailable(puzzle, row, col, i + 1))
                        {
                            puzzle[row, col] = i + 1;

                            if ((col + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row, col + 1)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row + 1, 0)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }

                return false;
            }
            else return true;
        }

        private static bool IsAvailable(int[,] puzzle, int row, int col, int num)
        {
            int rowStart = (row / 3) * 3;
            int colStart = (col / 3) * 3;

            for (int i = 0; i < 9; ++i)
            {
                if (puzzle[row, i] == num) return false;
                if (puzzle[i, col] == num) return false;
                if (puzzle[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
            }
            return true;
        }
    }
}
