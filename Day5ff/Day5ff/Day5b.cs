using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

class day5b
{
    public void start()
    {
        FileReader reader = new FileReader();
        string[] file = reader.ReadFile();

        List<Vent> vents = new List<Vent>();
        //size of coordinate-system:
        int maxX = 1000;
        int maxY = 1000;
        //read all vents from file and create vent class
        foreach (string line in file){
            string[] points = line.Split(" -> ");
            string[] p1 = points.GetValue(0).ToString().Split(',');
            string[] p2 = points.GetValue(1).ToString().Split(',');
            int x1 = Int32.Parse(p1.GetValue(0).ToString());
            int y1 = Int32.Parse(p1.GetValue(1).ToString());
            int x2 = Int32.Parse(p2.GetValue(0).ToString());
            int y2 = Int32.Parse(p2.GetValue(1).ToString());
           
            Vent v = new Vent(x1, y1, x2, y2);
            vents.Add(v);
          
            //v.ShowPoints();
        }
        //create empty map:
        VentMapDiag ventMap = new VentMapDiag(maxX, maxY);
        //draw vents
        ventMap.DrawVents(vents);
        int result = ventMap.PrintMap();
        //print number of intersections
        Console.WriteLine(result);
    }
}


public class VentMapDiag {
    int[,] map;
    int maxX;
    int maxY;
    public VentMapDiag(int imaxX, int imaxY) {
        

        map = new int[imaxX, imaxY];
        maxX = imaxX;
        maxY = imaxY;
        //self.map = np.array([[0 for i in range(10)] for j in range(10)])
        // print(self.map)
    }
    public void DrawVents(List<Vent> ventList)
    {
        foreach (Vent v in ventList)
        {   // for diagonal lines:

            if (v.x1 != v.x2 && v.y1 != v.y2)
            {
                v.ShowPoints();
                int xMod = 1;
                int yMod = 1;

                if (v.x1 > v.x2)
                {
                    xMod = -1;
                }
                if (v.y1 > v.y2)
                {
                    yMod = -1;
                }

                int x1 = v.x1;
                int y1 = v.y1;
                while (true)
                {
                    map[y1, x1] = map[y1, x1] + 1;
                    if (y1 == v.y2 && x1 == v.x2)
                    {
                        break;
                    }

                    
                    y1 = y1 + yMod;
                    x1 = x1 + xMod;

                }
            }
            else if (v.x1 == v.x2 && v.y1 == v.y2)
            {
                v.ShowPoints();
                map[v.y1, v.x1] = map[v.y1, v.x1] + 1;
            }

            else
            {
                v.ShowPoints();
                //paint start point
                map[v.y1, v.x1] = map[v.y1, v.x1] + 1;
                int step = 1;
                //search vertical lines;
                if (v.x1 == v.x2)
                {
                    if (v.y1 > v.y2) { step = -1; }
                    int y1 = v.y1;
                    int y2 = v.y2;

                    while (y1 != y2)
                    {
                        y1 = y1 + step;
                        map[y1, v.x1] = map[y1, v.x1] + 1;

                    }


                }
                //or horizontal
                else
                {
                    if (v.x1 > v.x2) { step = -1; }
                    int x1 = v.x1;
                    int x2 = v.x2;

                    while (x1 != x2)
                    {
                        x1 = x1 + step;
                        map[v.y1, x1] = map[v.y1, x1] + 1;

                    }
                }
            }

        //PrintMap();
        }
            
    }
 


    
    public int PrintMap()
    {
        int moreVents = 0;  //counter for intersections
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                //map[i, j] = 0;
                Console.Write(map[i, j]);
                if (map[i, j] > 1)
                {
                    moreVents++;
                }
            }
            Console.Write("\n");
       
        }
        Console.Write("\n");
        Console.Write("\n");
        return moreVents;
        }
     
}