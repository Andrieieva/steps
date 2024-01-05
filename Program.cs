using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the number of stairs: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int distinctWays = ClimbStairs(n);
                Console.WriteLine($"There are {distinctWays} distinct ways to climb {n} stairs.");

                if (distinctWays > 0)
                {
                    Console.WriteLine("All possible ways:");

                    var allWays = GetAllWays(n);
                    for (int i = 0; i < allWays.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. Way {string.Join(" + ", allWays[i])} = {n}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-negative integer.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static int ClimbStairs(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }

    static int[][] GetAllWays(int n)
    {
        var result = new int[ClimbStairs(n)][];
        int count = 0;
        GetAllWaysHelper(n, new int[n], result, ref count, 0);
        return result;
    }

    static void GetAllWaysHelper(int n, int[] currentWay, int[][] result, ref int count, int index)
    {
        if (n == 0)
        {
            int[] way = new int[index];
            Array.Copy(currentWay, way, index);
            result[count++] = way;
            return;
        }

        if (n >= 1)
        {
            currentWay[index] = 1;
            GetAllWaysHelper(n - 1, currentWay, result, ref count, index + 1);
        }

        if (n >= 2)
        {
            currentWay[index] = 2;
            GetAllWaysHelper(n - 2, currentWay, result, ref count, index + 1);
        }
    }
}
