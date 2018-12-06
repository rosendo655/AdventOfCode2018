using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day6
    {
        static string regexLine = ".*\n";
        static string regexNumber = @"\d+";
        static Regex regex = new Regex(regexLine);
        static Regex regexNum = new Regex(regexNumber);

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public char? letter { get; set; }
            private List<Point> puntos;
            public List<Point> Puntos { get; set; }


            public int Distance(Point p)
            {
                int xDifference = this.X - p.X;
                int yDifference = this.Y - p.Y;


                return Math.Abs(xDifference) + Math.Abs(yDifference);

            }
        }

        public class Area
        {
            public int MinX { get; set; }
            public int MinY { get; set; }
            public int MaxX { get; set; }
            public int MaxY { get; set; }

            public List<char> PuntosInfinitos(List<Point> puntos)
            {
                return puntos.Where(w => w.X == MinX || w.X == MaxX || w.Y == MinY || w.Y == MaxY).Select(e => e.letter.Value).Distinct().ToList();
            }
        }

        public static void Part1()
        {
            List<Point> puntos = new List<Point>();
            int charselection = 0;
            foreach (Match matchLine in regex.Matches(input))
            {
                var numberMatches = regexNum.Matches(matchLine.Value);
                puntos.Add(new Point
                {
                    X = int.Parse(numberMatches[0].Value.Trim()),
                    Y = int.Parse(numberMatches[1].Value.Trim()),
                    letter = letters[charselection++]

                });


            }
            int offset = 500;
            Area area = new Area();
            area.MinX = puntos.Select(o => o.X).Min() - offset;
            area.MaxX = puntos.Select(o => o.X).Max() + offset;
            area.MinY = puntos.Select(o => o.Y).Min() - offset;
            area.MaxY = puntos.Select(o => o.Y).Max() + offset;

            List<Point> todosPuntos = new List<Point>();
            for(int x = area.MinX; x < area.MaxX; x++)
            {
                for (int y = area.MinY; y < area.MaxY; y++)
                {
                    Dictionary<Point, int> distances = new Dictionary<Point, int>();
                    Point actualPoint = new Point { X = x, Y = y };

                    foreach (Point p in puntos)
                    {
                        distances.Add(p, p.Distance(actualPoint));
                    }

                    if(puntos.Count == distances.Select(kvp => kvp.Value).GroupBy(g => g).Count())
                    {
                        actualPoint.letter = '.';
                    }
                    else
                    {
                        actualPoint.letter = distances.OrderBy(o => o.Value).First().Key.letter;
                    }
                    todosPuntos.Add(actualPoint);
                }
            }

            var infinitos = area.PuntosInfinitos(todosPuntos);
            var diccionario = new Dictionary<char, int>();
            foreach(var group in todosPuntos.GroupBy(g=>g.letter))
            {
                if (!infinitos.Contains(group.Key.Value))
                {
                    diccionario.Add(group.Key.Value,group.Count());
                }
            }

            foreach(var kvp in diccionario.OrderBy(o=>o.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
            for (int x = area.MinX; x < area.MaxX; x++)
            {
                for (int y = area.MinY; y < area.MaxY; y++)
                {
                    try
                    {
                        Console.Write(todosPuntos.Where(w => w.X == x && w.Y == y).First().letter);
                    }
                    catch (Exception)
                    {
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            //foreach (Point p in puntos)
            //{
            //    Console.WriteLine($"{p.X},{p.Y}:{p.letter}");
            //}
            //Console.ReadKey();
        }

        static string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789?¡[]{}!#$%&/()";

        static string input = @"192, 220
91, 338
65, 319
143, 310
243, 205
237, 135
342, 197
114, 56
189, 168
194, 174
55, 331
181, 162
272, 111
201, 121
73, 88
276, 274
324, 323
201, 146
125, 301
190, 185
247, 307
157, 65
217, 181
62, 222
319, 202
86, 342
333, 339
181, 240
263, 198
200, 296
306, 228
55, 50
154, 356
54, 70
91, 91
265, 182
272, 267
118, 296
75, 140
319, 272
357, 341
193, 342
102, 334
246, 123
328, 139
229, 284
199, 309
151, 243
295, 229
201, 277
";
    }
}
