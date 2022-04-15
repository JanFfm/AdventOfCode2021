using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

class day5a
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
        VentMap ventMap = new VentMap(maxX, maxY);
        //draw vents
        ventMap.DrawVents(vents);
        int result = ventMap.PrintMap();
        //print number of intersections
        Console.WriteLine(result);
    }
}


public class Vent
{
    public int x1;
    public int y1;
    public int x2;
    public int y2;
    public Vent(int ix1, int iy1, int ix2, int iy2)
    {
        x1 = ix1;
        x2 = ix2;

        y1 = iy1;
        y2 = iy2;
        
    }

    public void ShowPoints()
    {
        Console.Write(x1 + "," + y1);
        Console.Write(" ");
        Console.Write(x2 + "," + y2);
        Console.Write("\n");



    }
}
public class VentMap {
    int[,] map;
    int maxX;
    int maxY;
    public VentMap(int imaxX, int imaxY) {
        

        map = new int[imaxX, imaxY];
        maxX = imaxX;
        maxY = imaxY;
        //self.map = np.array([[0 for i in range(10)] for j in range(10)])
        // print(self.map)
    }
    public void DrawVents(List<Vent> ventList)
    {
        foreach (Vent v in ventList)
        {
            //skip diagonal  lines :
            if (!(v.x1 != v.x2 && v.y1 != v.y2))
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
        return moreVents;
    }
     
}

public class FileReader
{
    public FileReader()
    {

    }
    public string[] ReadFile()
    {
       
        string filePath = "..\\..\\..\\input5.txt";
        string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            // Use a tab to indent each line of the file.
            Console.WriteLine("\t" + line);
        }


        return lines;

    }

}