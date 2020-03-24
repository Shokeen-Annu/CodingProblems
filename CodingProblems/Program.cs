using System;

namespace CodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Following is the choice list of different coding problems:");
            Console.WriteLine("1 Climbing Leaderboard");
            Console.WriteLine("Enter your choice number.");

            try
            {
                int choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter total number of scores, space seperated scores, total number of alice's scores, space separated alice's scores. Enter them in one by one.");
                        int scoresSize = Convert.ToInt32(Console.ReadLine());
                        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
                        int aliceSize = Convert.ToInt32(Console.ReadLine());
                        int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
                        int[] result = climbingLeaderboard(scores, alice);
                        Console.WriteLine("Resultant ranks:");
                        foreach (int item in result)
                        {
                            Console.WriteLine(item);
                        }

                        break;
                    default:
                        Console.WriteLine("Incorrect choice. Please restart.");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Incorrect input. Please read instructions carefully.");
            }

            Console.Read();
        }

        public static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int alicelen = alice.Length;
            int scoresLen = scores.Length;
            int[] result = new int[alicelen];
            int[] ranks = new int[scoresLen];

            int max = scores[0];
            int min = scores[0];
            int prev = scores[0];
            int currentscorerank = 1;
            for (int i = 0; i < scoresLen; i++)
            {
                int item = scores[i];
                if (max < item)
                    max = item;

                if (min > item)
                    min = item;

                if (prev > item)
                    currentscorerank += 1;
                prev = item;
                ranks[i] = currentscorerank;
            }

            for (int i = 0; i < alicelen; i++)
            {
                //Get each score of alice
                int alicerank = 0;
                int aliceItem = alice[i];


                if (aliceItem > max)
                    alicerank = 1;
                else if (aliceItem < min)
                    alicerank = ranks[scoresLen - 1] + 1;
                else
                {
                    int midIndex = (int)scoresLen / 2;
                    int middle = scores[midIndex];
                    if (aliceItem >= middle)
                    {
                        for (int j = 0; j <= midIndex; j++)
                        {

                            int item = scores[j];

                            if (aliceItem >= item)
                            {
                                alicerank = ranks[j];

                                //    flag = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = midIndex + 1; j < scoresLen; j++)
                        {

                            int item = scores[j];

                            if (aliceItem >= item)
                            {
                                alicerank = ranks[j];

                                //    flag = true;
                                break;
                            }
                        }
                    }
                }

                result[i] = alicerank;
            }
            return result;
        }
    }
}
