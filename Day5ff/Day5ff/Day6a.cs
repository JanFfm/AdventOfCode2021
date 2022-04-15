using System;
using System.Collections.Generic;
using System.Linq;
class Day6a
{
    public void Start()
    {
        int steps = 256;
        List<long> input = new List<long> { 3, 1, 5, 4, 4, 4, 5, 3, 4, 4, 1, 4, 2, 3, 1, 3, 3, 2, 3, 2, 5, 1, 1, 4, 4, 3, 2, 4, 2, 4, 1, 5, 3, 3, 2, 2, 2, 5, 5, 1, 3, 4, 5, 1, 5, 5, 1, 1, 1, 4, 3, 2, 3, 3, 3, 4, 4, 4, 5, 5, 1, 3, 3, 5, 4, 5, 5, 5, 1, 1, 2, 4, 3, 4, 5, 4, 5, 2, 2, 3, 5, 2, 1, 2, 4, 3, 5, 1, 3, 1, 4, 4, 1, 3, 2, 3, 2, 4, 5, 2, 4, 1, 4, 3, 1, 3, 1, 5, 1, 3, 5, 4, 3, 1, 5, 3, 3, 5, 4, 2, 3, 4, 1, 2, 1, 1, 4, 4, 4, 3, 1, 1, 1, 1, 1, 4, 2, 5, 1, 1, 2, 1, 5, 3, 4, 1, 5, 4, 1, 3, 3, 1, 4, 4, 5, 3, 1, 1, 3, 3, 3, 1, 1, 5, 4, 2, 5, 1, 1, 5, 5, 1, 4, 2, 2, 5, 3, 1, 1, 3, 3, 5, 3, 3, 2, 4, 3, 2, 5, 2, 5, 4, 5, 4, 3, 2, 4, 3, 5, 1, 2, 2, 4, 3, 1, 5, 5, 1, 3, 1, 3, 2, 2, 4, 5, 4, 2, 3, 2, 3, 4, 1, 3, 4, 2, 5, 4, 4, 2, 2, 1, 4, 1, 5, 1, 5, 4, 3, 3, 3, 3, 3, 5, 2, 1, 5, 5, 3, 5, 2, 1, 1, 4, 2, 2, 5, 1, 4, 3, 3, 4, 4, 2, 3, 2, 1, 3, 1, 5, 2, 1, 5, 1, 3, 1, 4, 2, 4, 5, 1, 4, 5, 5, 3, 5, 1, 5, 4, 1, 3, 4, 1, 1, 4, 5, 5, 2, 1, 3, 3 };
        long[] fishes = new long[] { 0, 0, 0, 0, 0, 0, 0, 0,0 };
        int len = input.Count;
        for (int i = 0; i < len; i++)
        {
           fishes[input[i]]++;
        }


        for (int i = 0; i < steps; i++)
        {
            long[] newFishes = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int j = 8; j >= 1; j--)
            {
                newFishes[j - 1] = fishes[j];
            }
            newFishes[6] = newFishes[6] + fishes[0];
            newFishes[8] = fishes[0];
            fishes = newFishes;
        }

        fishes.ToList().ForEach(Console.WriteLine);

        double fishNumber = fishes.Sum();
        Console.WriteLine("total:" + fishNumber.ToString());



        /*
        for (int i = 0; i < steps; i++)
        {
            int actualLen = fishes.Count;
            int toAdd = 0;
            for (int j = 0; j < actualLen; j++)

            {
                if (fishes[j] == 0)
                {
                    toAdd++;
                    fishes[j] = 6;
                }
                else
                {
                    fishes[j] = fishes[j] - 1;
                }
               
            }
            for (int k = 0; k < toAdd; k++)
            {
                fishes.Add(8);
            }
            /*
            for (int n = 0; n < fishes.Count; n++)
            {
                Console.Write(fishes[n]);
                Console.Write(", ");
            }
            Console.Write("\n ");
            Console.WriteLine("Day: "+ (i+1).ToString());
            Console.WriteLine("total:" + fishes.Count.ToString());
            Console.Write("\n ");
            */
    }


}


