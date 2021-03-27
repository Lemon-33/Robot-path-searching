using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public static class ListHelper
    {
        public static bool Exists(this List<Point> points, Point point)
        {

            foreach (Point a in points)
            {
                if (a.X == point.X && a.Y == point.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class Map
    {
        public int rows, columns;
        public int Move = 10;//横着走
        public   int startvalue = 0, startx = 0, starty = 0;
        public  int endvalue = 0, endx = 0, endy = 0;
        public Point start;
        public Point end;
        public int[,] sign;
        public List<Point> openlist;
        public List<Point> closelist;
        public List<Point> Path;
        public List<string> Movement;
        public List<int> Orientation;
        public int sur = 0;
        public int k;

        public Map(int r, int c)//新建一个地图实例
        {
            rows = r;
            columns = c;
            startvalue = 0;startx = 0;starty = 0;
            endvalue = 0;endx = 0;endy = 0;
            sign = new int[r,c ];
            openlist = new List<Point>();
            closelist = new List<Point>();
            Path = new List<Point>();
            Movement = new List<string>();
            Movement.Add("Advance");
            Orientation = new List<int>();
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    sign[i, j] = 0;
                }
            }
        }

        public int ToF(Point a)
        {
            a.H = a.ParentPoint.H + Move;
            a.G = distance(a, end);
            return a.G + a.H;
        }
        public int distance(Point a, Point b)
        {
            int q = System.Math.Abs(a.X*10 - b.X*10) + System.Math.Abs(a.Y*10 - b.Y*10);
            int ans = q;
            return ans;
        }

        public void FindPath()//路径规划算法
        {
            closelist.Add(start);
            AddPoint(start);
            int n = 0;
            int m = 0;
            for (int j = 0;j<rows*columns-2; j++)
            {
                n = openlist.Count;
                for(int i=0;i<n;i++)
                {
                    closelist.Add(openlist[0]);
                    AddPoint(openlist[0]);
                    openlist.RemoveAt(0);
                }
                if (openlist.Exists(end)) break;
                if (openlist.Count == 0) break;
             }
            m = openlist.Count;
            if (m != 0)
            {
                for (int i = 0; i < m; i++)
                {
                    if (openlist[i].G == 0)
                    {
                        k = i;
                        break;
                    }
                }
                Path.Add(openlist[k]);
                Point target = openlist[k];
                for (int a = 0; ; a++)
                {
                    target = target.ParentPoint;
                    Path.Add(target);
                    if (target.X == startx && target.Y == starty)
                        break;
                }
            }

        }

        public void AddPoint(Point a)//遍历一个点周围的四个点
        {
            Point[] surround = new Point[4];
            int i=0;
            int j, k;
            {
                j = a.X - 1;
                k = a.Y;
                if (j >= 0)
                {
                    if (sign[j, k] == 0||sign[j,k] == 6)
                    { 
                        surround[i] = new Point(j, k);
                        surround[i].ParentPoint = a;
                        openlist.Add(surround[0]);
                        surround[i].F = ToF(surround[i]);
                        i++;
                        if(sign[j,k]==0)
                        sign[j, k] = 2;
                        
                    }
                }
            }

            {
                j = a.X +1;
                k = a.Y;
                if (j < rows)
                {
                    if (sign[j, k] == 0 || sign[j, k] == 6)
                    {
                        surround[i] = new Point(j, k);
                        surround[i].ParentPoint = a;
                        openlist.Add(surround[i]);
                        surround[i].F = ToF(surround[i]);
                        i++;
                        if (sign[j, k] == 0)
                            sign[j, k] = 2;
                    }
                }
            }
            {
                j = a.X ;
                k = a.Y - 1;
                if (k >= 0)
                {
                    if (sign[j, k] == 0 || sign[j, k] == 6)
                    {
                        surround[i] = new Point(j, k);
                        surround[i].ParentPoint = a;
                        openlist.Add(surround[i]);
                        surround[i].F = ToF(surround[i]);
                        i++;
                        if (sign[j, k] == 0)
                            sign[j, k] = 2;
                    }
                }
            }
            {
                j = a.X;
                k = a.Y + 1;
                if (j >= 0 && j < rows && k >= 0 && k < columns)
                {
                    if (sign[j, k] == 0 || sign[j, k] == 6)
                    {
                        surround[i] = new Point(j, k);
                        surround[i].ParentPoint = a;
                        openlist.Add(surround[i]);
                        surround[i].F = ToF(surround[i]);
                        i++;
                        if (sign[j, k] == 0)
                            sign[j, k] = 2;
                    }
                }
            }
        }

    }
}
