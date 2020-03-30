using System;
using System.Collections;
using System.Numerics;
namespace CodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Following is the choice list of different coding problems:");
            Console.WriteLine("1 Climbing Leaderboard");
            Console.WriteLine("2 Foregone Solution - Divide number in a way that sum of two numbers is given number but both of them do not have 4 digit.");
            Console.WriteLine("3 Convert the crypted text to plaintext");
            Console.WriteLine("Enter your choice number.");

            try
            {
                int choice = Convert.ToInt16(Console.ReadLine());
                //char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z' };
                
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
                    case 2: Console.WriteLine("Enter number of test cases in one line and then followed by numbers in each line.");
                        foregoneSolution();
                        break;
                    case 3:
                        Console.WriteLine("Enter input as 'First line - no of cases, Second line - N(max prime number) L(length of list values in ciphertext, Third line - Space separated list of values)'");
                        plaintext();
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

        public static void foregoneSolution()
        {
                //Console.WriteLine('Provide input');
                int noOfCases = Convert.ToInt32(Console.ReadLine());
                //string[] testCases = new string[noOfCases];
                for (int i = 0; i < noOfCases; i++)
                {
                    //testCases[i] = Console.ReadLine();
                    char[] items = Console.ReadLine().ToCharArray();
                    string a = "";
                    string b = "";
                    bool flag = false;
                    foreach (char j in items)
                    {
                        if (j == '4')
                        {
                            a += "1";
                            b += "3";
                            flag = true;
                        }
                        else
                        {
                            if (flag)
                                a += "0";
                            b += j.ToString();
                        }
                    }

                    Console.WriteLine("Case #" + (i + 1) + ": " + a + " " + b);

                }


                //Console.WriteLine('Input taken');
                Console.Read();
            
    }

        public static void youCanGoYourOwnWay()
        {
            int totalCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= totalCases; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string path = Console.ReadLine();
                string temp = path.Replace("E", "T");
                string rev = temp.Replace("S", "E");
                string final = rev.Replace("T", "S");

                Console.WriteLine("Case #" + i + ": " + final);
            }
        }

        public static void plaintext()
        {
            int cases = Convert.ToInt32(Console.ReadLine());

            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };


            for (int i = 1; i <= cases; i++)
            {
                string plaintext = "";
                Hashtable refer = new Hashtable();
                string[] testLine1 = Console.ReadLine().Split(' ');
                string[] testLine2 = Console.ReadLine().Split(' ');
                BigInteger N = BigInteger.Parse(testLine1[0]);
                BigInteger[] deciphered = new BigInteger[Convert.ToInt32(testLine1[1]) + 1];

                //Calculate first and second primary number from first value of ciphertext
                BigInteger first = 0;
                BigInteger second = 0;
                for (BigInteger j = 2; j <= N; j++)
                {
                    BigInteger num = BigInteger.Parse(testLine2[0]);
                    BigInteger rem = BigInteger.Remainder(num, j);
                    if (BigInteger.Equals(rem, BigInteger.Parse("0")))
                    {
                        first = j;
                        second = BigInteger.Divide(num, j);
                        deciphered[0] = first;
                        deciphered[1] = second;
                        break;
                    }

                }

                //Consequently use second prime number to get further prime numbers as one prime number is common between two values
                for (int j = 1; j < Convert.ToInt32(testLine1[1]); j++)
                {
                    BigInteger num = BigInteger.Parse(testLine2[j]);
                    BigInteger next = BigInteger.Divide(num, second);
                    deciphered[j + 1] = next;
                    second = next;
                }

                //Sort the prime numbers and assign alphabets to them increasing order
                BigInteger[] temp = new BigInteger[deciphered.Length];
                Array.Copy(deciphered, temp, deciphered.Length);
                Array.Sort(temp);
                int count = 1;
                BigInteger prev = temp[0];
                refer.Add(temp[0], letters[0].ToString());
                foreach (BigInteger j in temp)
                {
                    if (!BigInteger.Equals(prev, j))
                    {
                        if (count <= 25)
                        {
                            refer.Add(j, letters[count].ToString());
                            count++;
                        }
                    }
                    prev = j;
                }

                //Finally decode the plaintext
                for (int j = 0; j < deciphered.Length; j++)
                {
                    plaintext += refer[deciphered[j]].ToString();
                }
                Console.WriteLine("Case #" + i + ": " + plaintext);
            }
        }
}
}
