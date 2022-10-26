/*using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Model.Section;

namespace RaceTrack
{
    public static class VisualisationOud
    {

        private enum Direction
        {
            North,
            East,
            South,
            West
        }

        #region graphics


        private static string[] _straightN =
        {
             "|     |",
             "|     |",
             "|     |",
             "|     |",
             "|     |",
             "|     |",
             "|     |",
        };

        private static string[] _straightS =
        {
             "|     |",
             "|     |",
             "|     |",
             "|     |",
             "|     |",
             "|     |",
             "|     |",
        };
        private static string[] _straightE =
        {
             "       ",
             "-------",
             "       ",
             "       ",
             "       ",
             "-------",
             "       ",
        };
        private static string[] _straightW =
        {
             "       ",
             "-------",
             "       ",
             "       ",
             "       ",
             "-------",
             "       ",
        };

        private static string[] _startN =
        {
             "|     |",
             "|     |",
             "| _ _ |",
             "| _ _ |",
             "| _ _ |",
             "|     |",
             "|     |",
        };
        private static string[] _startS =
{
             "|     |",
             "|     |",
             "| _ _ |",
             "| _ _ |",
             "| _ _ |",
             "|     |",
             "|     |",
        };
        private static string[] _startE =
        {
             "       ",
             "-------",
             "  |||  ",
             "       ",
             "  |||  ",
             "-------",
             "       ",
        };
        private static string[] _startW =
        {
             "       ",
             "-------",
             "  |||  ",
             "       ",
             "  |||  ",
             "-------",
             "       ",
        };
        private static string[] _finishN =
        {
             "|     |",
             "|     |",
             "|#.#.#|",
             "|.#.#.|",
             "|#.#.#|",
             "|     |",
             "|     |",
        };
        private static string[] _finishS =
        {
             "|     |",
             "|     |",
             "|#.#.#|",
             "|.#.#.|",
             "|#.#.#|",
             "|     |",
             "|     |",
        };
        private static string[] _finishE =
        {
             "       ",
             "-------",
             "  .#.  ",
             "  #.#  ",
             "  .#.  ",
             "-------",
             "       ",
        };
        private static string[] _finishW =
        {
             "       ",
             "-------",
             "  .#.  ",
             "  #.#  ",
             "  .#.  ",
             "-------",
             "       ",
        };
        private static string[] _rightN =
        {
             "|      |",
            @"|     \",
            @"|      ",
             "|      ",
             "|      ",
            @"\------",
             "       ",
        };
        private static string[] _rightS =
        {
             "|     |",
             "/     |",
             "      |",
             "      |",
             "      |",
            @"------/",
             "       ",
        };
        private static string[] _rightE =
        {
             "       ",
            @"------\",
             "      |",
             "      |",
             "      |",
            @"\     |",
            @"|     |",
        };
        private static string[] _rightW =
        {
             "|     |",
            @"|     \",
             "|      ",
             "|      ",
            @"|      ",
            @" \-----",
            @"       ",
        };

        private static string[] _leftN =
        {
             "       ",
            @"-----\ ",
            @"      |",
             "      |",
             "      |",
            @"\     |",
             "|     |",
        };
        
        private static string[] _leftS =
        {
             "|     |",
            @"|     \",
            @"|      ",
             "|      ",
             "|      ",
            @"\------",
             "       ",
        };
        private static string[] _leftE =
        {
             "|     |",
            @"/     |",
             "      |",
             "      |",
             "      |",
            @"------/",
            @"       ",
        };
        private static string[] _leftW =
        {
             "      ",
            @"/------",
             "|      ",
             "|      ",
             "|      ",
            @"|     /",
            @"|     |",
        };


        #endregion
        private static Direction Compas = Direction.East;
        static int x = 30;
        static int y = 30;
        private static int _lastX = 40;
        private static int _lastY = 40;
        private static int _offsetX = 1;
        private static int _offsetY = 1;
        static int width = 7;
        static int height = 7;
        public static void Initialize()
        {
          Track zandvoort =  new Track("Zandvoort", new[] {
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.StartGrid,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Finish,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
            }
            );

            DrawTrack(zandvoort);
        }
        public static void DrawTrack(Track track)
        {
    

            foreach (var section in track.Sections)
            {
                GenerateGraphics(section);
                GenerateCoordinates(section);
                DrawSection(section);
            }
        }

       

*//*        public static void DrawSection(Section section)
        {

            int amountX = 0;
            int amountY = 0;

             string[] sectionString = FindCorrectString(section);
            foreach (var line in sectionString)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(line);
                if (Compas == Direction.East)
                { 
                    if(amountY >= 7)
                    {
                        amountY = 0;
                        y -= 7;
                        
                    }
                    else
                    {
                        amountY++;
                        y++;
                    }
                }
                else if (Compas == Direction.West)
                {
                    if (amountY >= 7)
                    {
                        amountY = 0;
                        y -= 7;

                    }
                    else
                    {
                        amountY++;
                        y++;
                    }
                }
*//*                else if(Compas == Direction)*//**//*
            }
            if(section.Equals( Section.SectionTypes.LeftCorner))
            {
                setCompass(0);
         
            }
            else if (section.Equals(Section.SectionTypes.RightCorner))
            {
                setCompass(1);
            }


            *//*  //Draw section code 
              int amountBlocks = 0;


              string[] sectionString = FindCorrectString(section);
              foreach (var line in sectionString)
              {
                  Console.SetCursorPosition(x, y);
                  Console.WriteLine(line);
                  amountBlocks ++;
                  if (Compas == Direction.South)
                  {
                      y = y - 1;
                  }
                  else if (Compas == Direction.North)
                  {
                      y = y + 1;
                  }
                  else if (Compas == Direction.East)
                  {
                      if(amountBlocks >= 7)
                      {
                          x = x + 7;
                          amountBlocks -= 7;
                      }
                      y = y + 1;
                  }
                  else { 

                  if (amountBlocks >= 7)
                  {
                      x = x - 7;
                      amountBlocks -= 7;
                  }

                      y = y + 1;
                  }
              }
              if (Compas == Direction.East || Compas == Direction.West)
              {

                  y = y - 7;
              }*//*

        }
        private static void setCompass(int way)
        {
            // 0 is left 1 is right
            switch (Compas)
            {
                case Direction.South:
                        if(way == 0)
                    {
                       
                        
                        Compas = Direction.East;
                    }
                    else if (way == 1)
                    {
                        Compas = Direction.West;
                    }
                        break;
                case Direction.North:
                    if (way == 0)
                    {
                        Compas = Direction.West;
                    }
                    else if (way == 1)
                    {
                        Compas = Direction.East;
                    }
                    break;
                case Direction.East:
                    if (way == 0)
                    {
                        y = y + 2;
                        Compas = Direction.North;
                    }
                    else if (way == 1)
                    {
                        y = y + 2;
                        Compas = Direction.South;
                    }
                    break;
                case Direction.West:
                    if(way == 0)
                    {
                        
                        Compas = Direction.South;
                    }
                    else if (way == 1)
                    {
                        Compas = Direction.North;
                    }
                    break;
                default:
                    break;
            }
        }
        public static string[] FindCorrectString(Section section)
        {
            //Method for finding wich string is with which section

            switch (section.SectionType)
            {
                case Section.SectionTypes.Straight:
                    if (Compas == Direction.East) {

                        return _straightE;
                    }
                    else if (Compas == Direction.West)
                    {
                        return _straightW;
                    }
                    else
                    {
                        return _straightN;
                    }
                    break;
                case Section.SectionTypes.LeftCorner:
                    
                    if (Compas == Direction.East)
                    {
                        Console.SetCursorPosition(x, y);
                        
                        return _leftE;
                    } else if (Compas == Direction.West) { 

                        Console.SetCursorPosition(x, y);
                        
                        return _leftW;

                    } else if (Compas == Direction.South)
                    {
                        Console.SetCursorPosition(x, y);
                        
                        return _leftS;
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                       
                        return _leftN;
                    }
                    break;
                case Section.SectionTypes.RightCorner:
                    setCompass(1);
                    if (Compas == Direction.East)
                    {
                        Console.SetCursorPosition(x, y);
                        
                        return _rightE;
                    }
                    else if (Compas == Direction.West)
                    {
                        Console.SetCursorPosition(x, y);
                        
                        return _rightW;
                    }
                    else if (Compas == Direction.South)
                    {
                        return _rightS;
                    }
                    else
                    {
                        return _rightN;
                    }
                    break;
                case Section.SectionTypes.StartGrid:
                    if (Compas == Direction.East || Compas == Direction.West)
                    {
                        return _startE;
                    }
                    else
                    {
                        return _startN;
                    }
                    break;
                case Section.SectionTypes.Finish:
                    if(Compas == Direction.East || Compas == Direction.West)
                    {
                        return _finishE;
                    }
                    else
                    {
                        return _finishN;
                    }
                    break;
                default:
                    break;
            }
            string[] valueTest = { "test" };
            return valueTest;
        }*//*

        //checkpoint

        private static string[] _startHorizontal = { "═════════", "      1] ", " 2]      ", "═════════" };
        private static string[] _finishHorizontal = { "════░════", "  1 ░    ", "  2 ░    ", "════░════" };
        private static string[] _straightHorizontal = { "═════════", "    1    ", "    2    ", "═════════" };
        private static string[] _straightVertical = { "║       ║", "║       ║", "║ 1   2 ║", "║       ║" };

        private static string[] _cornerNorthWest = { "╝       ║", "  1  2  ║", "        ║", "════════╝" };
        private static string[] _cornerNorthEast = { "║       ╚", "║  1  2  ", "║        ", "╚════════" };
        private static string[] _cornerSouthWest = { "════════╗", "        ║", " 1   2  ║", "╗       ║" };
        private static string[] _cornerSouthEast = { "╔════════", "║        ", "║  1  2  ", "║       ╔" };
        public static void DrawSection(Section section)
        {
            for (int i = 1; i < section.Graphic.Length + 1; i++)
            {
                Console.SetCursorPosition(section.x * width + _offsetX, section.y * height + _offsetY + i);
                Console.Write(section.Graphic[i]);
            }
        }
        private static void GenerateGraphics(Section section)
        {
            switch (section.SectionType)
            {
                case SectionTypes.StartGrid:
                    section.Graphic = _startHorizontal;
                    break;
                case SectionTypes.Finish:
                    section.Graphic = _finishHorizontal;
                    break;
                case SectionTypes.Straight:
                    if (Compas == Direction.North || Compas == Direction.South)
                        section.Graphic = _straightVertical;
                    else
                        section.Graphic = _straightHorizontal;
                    break;
                case SectionTypes.LeftCorner:
                    if (Compas == Direction.North)
                        section.Graphic = _cornerSouthWest;
                    if (Compas == Direction.East)
                        section.Graphic = _cornerNorthWest;
                    if (Compas == Direction.South)
                        section.Graphic = _cornerNorthEast;
                    if (Compas == Direction.West)
                        section.Graphic = _cornerSouthEast;

                    if (Compas - 1 < 0)
                        Compas = Direction.West;
                    else
                        Compas--;
                    break;
                case SectionTypes.RightCorner:
                    if (Compas == Direction.North)
                        section.Graphic = _cornerSouthEast;
                    if (Compas == Direction.East)
                        section.Graphic = _cornerSouthWest;
                    if (Compas == Direction.South)
                        section.Graphic = _cornerNorthWest;
                    if (Compas == Direction.West)
                        section.Graphic = _cornerNorthEast;

                    if ((int)Compas + 1 > 3)
                        Compas = Direction.North;
                    else
                        Compas++;
                    break;
            }
        }

        private static void GenerateCoordinates(Section section)
        {
            section.x = _lastX;
            section.y = _lastY;
            switch (Compas)
            {
                case Direction.North:
                    _lastY--;
                    break;
                case Direction.East:
                    _lastX++;
                    break;
                case Direction.South:
                    _lastY++;
                    break;
                case Direction.West:
                    _lastX--;
                    break;
            }

            if (_lastX * width < _offsetX)
                _offsetX = _lastX * width;
            if (_lastY * height < _offsetY)
                _offsetY = _lastY * height;
        }


    }
}

*/