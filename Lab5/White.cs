using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            double k = 0;
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        k += 1;
                    }

                }
            }
            average = sum / k;
            // end
            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;
            int min = matrix[0, 0];            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end
            return (row, col);
        }
        public void Task3(int[,] mass, int k) // k - столбец
        {

            // code here
            if (k < mass.GetLength(1)) {
                int num_s = 0;
                int max = mass[0, k];
                for (int i = 0; i < mass.GetLength(0); i++)
                {
                    if (mass[i, k] > max)
                    {
                        max = mass[i, k];
                        num_s = i;
                    }
                }
                ;
                for (int i = 0; i < mass.GetLength(1); i++)
                {
                    (mass[0, i], mass[num_s, i]) = (mass[num_s, i], mass[0, i]);
                }
                // end
            }
        }
        public int[,] Task4(int[,] mass)
        {

            // code here
            if (mass.GetLength(0) == 0)
            {
                return new int[0, 0];
            }
            int[,] answer = new int[mass.GetLength(0) - 1, mass.GetLength(1)];
            int min = mass[0, 0];
            int ind = 0;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                if (mass[i, 0] < min)
                {
                    min = mass[i, 0];
                    ind = i;
                }
            }
            ;
            for (int i = 0; i < ind; i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    answer[i, j] = mass[i, j];
                }
            }
            for (int i = ind + 1; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                { answer[i - 1, j] = mass[i, j]; }
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, i];
            // end
            return sum;
        }
        public void Task6(int[,] mass)
        {

            // code here
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                int otr = -1, ind_otr = -1;
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] < 0)
                    {
                        ind_otr = j;
                        break;
                    }
                }
             ;
                if (ind_otr == -1)
                    continue;

                if (ind_otr > 0)
                {
                    int max = mass[i, 0], ind_max = 0;
                    for (int j = 0; j < ind_otr; j++)
                    {

                        if (mass[i, j] > max)
                        {
                            max = mass[i, j];
                            ind_max = j;
                        }
                    }
                    int pp = -1;
                    for (int j = mass.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (mass[i, j] < 0)
                        {
                            pp = j;
                            break;
                        }
                    }
             ;
                    if (pp != -1)
                        (mass[i, ind_max], mass[i, pp]) = (mass[i, pp], mass[i, ind_max]);
                }
            }
            // end

        }
        public int[] Task7(int[,] mass)
        {

            // code here
            int neg = -1;
            int k = 0;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] < 0)
                    {
                        k++;
                    }
                }
            }
            if (k == 0) return null;

            int[] new_mass = new int[k];
            int c = 0;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] < 0)
                    {
                        new_mass[c++] = mass[i, j];
                    }
                }
            }

            // end

            return new_mass;
        }
        public void Task8(int[,] mass)
        {

            // code here
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                int max = mass[i, 0];
                int jj = 0;
                for (int j = 0; j < mass.GetLength(1); j++)
                    if (mass[i, j] > max)
                    {
                        max = mass[i, j];
                        jj = j;
                    }
                if (mass.GetLength(1) == 1) continue;
                if (jj == 0) mass[i, 1] *= 2;
                else if (mass[i, mass.GetLength(1) - 1] == max) mass[i, mass.GetLength(1) - 2] *= 2;
                else if (mass[i, jj - 1] > mass[i, jj + 1]) mass[i, jj + 1] *= 2;
                else if (mass[i, jj - 1] <= mass[i, jj + 1]) mass[i, jj - 1] *= 2;
            }
            // end

        }
        public void Task9(int[,] mass)
        {

            // code here
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                int[] row = new int[mass.GetLength(1)];
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    row[j] = mass[i, mass.GetLength(1)  - j - 1];
                }

                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = row[j];
                }
            }
            // end

        }
        public void Task10(int[,] mass)
        {

            // code here

            if (mass.GetLength(0) == mass.GetLength(1))
            {
                for (int i = mass.GetLength(0) / 2; i < mass.GetLength(0); i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        mass[i, j] = 1;
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        k++;
                        break;
                    }
                }
            }

            if (k == matrix.GetLength(0))
            {
                return new int[0, matrix.GetLength(1)];
            }

            answer = new int[matrix.GetLength(0) - k, matrix.GetLength(1)];
            int newRowIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool hasZero = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (!hasZero)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        answer[newRowIndex, j] = matrix[i, j];
                    }
                    newRowIndex++;
                }
            }

            return answer;
        }
        public void Task12(int[][] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int sum1 = 0;
                    int sum2 = 0;

                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sum1 += array[j][k];
                    }

                    for (int k = 0; k < array[j + 1].Length; k++)
                    {
                        sum2 += array[j + 1][k];
                    }

                    if (sum1 > sum2)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
        // end

    }