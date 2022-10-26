/*using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using System.Xml.Xsl;
using static Model.Section;

namespace RaceTrack
{
    public class Visualisation
    {
        #region graphics
        private static string[] _straightN =
       {
             "|     |",
             "|     |",
             "| 1   |",
             "|   2 |",
             "|     |",
             "|     |",
             "|     |",
        };

        private static string[] _straightS =
        {
             "|     |",
             "|     |",
             "|   2 |",
             "| 1   |",
             "|     |",
             "|     |",
             "|     |",
        };
        private static string[] _straightE =
        {
             "       ",
             "-------",
             "   1   ",
             "       ",
             "   2   ",
             "-------",
             "       ",
        };
        private static string[] _straightW =
        {
             "       ",
             "-------",
             "   1   ",
             "       ",
             "   2   ",
             "-------",
             "       ",
        };

        private static string[] _startN =
        {
             "|     |",
             "|     |",
             "| _   |",
             "| 1 - |",
             "|   2 |",
             "|     |",
             "|     |",
        };
        private static string[] _startS =
{
             "|     |",
             "|   2 |",
             "| 1 - |",
             "| -   |",
             "|     |",
             "|     |",
             "|     |",
        };
        private static string[] _startE =
        {
             "       ",
             "-------",
             "   1|  ",
             "       ",
             "  2|   ",
             "-------",
             "       ",
        };
        private static string[] _startW =
        {
             "       ",
             "-------",
             "   |1  ",
             "       ",
             "    |2 ",
             "-------",
             "       ",
        };
        private static string[] _finishN =
        {
             "|     |",
             "|     |",
             "|#.#.#|",
             "|.1.2.|",
             "|#.#.#|",
             "|     |",
             "|     |",
        };
        private static string[] _finishS =
        {
             "|     |",
             "|     |",
             "|#.#.#|",
             "|.2.1.|",
             "|#.#.#|",
             "|     |",
             "|     |",
        };
        private static string[] _finishE =
        {
             "       ",
             "-------",
             "  .1.  ",
             "  #.#  ",
             "  .2.  ",
             "-------",
             "       ",
        };
        private static string[] _finishW =
        {
             "       ",
             "-------",
             "  .1.  ",
             "  #.#  ",
             "  .2.  ",
             "-------",
             "       ",
        };
        private static string[] _rightN =
        {
             "       ",
            @"/------",
             "|      ",
             "|  1   ",
             "|   2  ",
            @"|     /",
            @"|     |",
        };
        private static string[] _rightS =
        {
             "|     |",
             "/     |",
             "  2   |",
             "      |",
             "  1   |",
            @"------/",
             "       ",
        };
        private static string[] _rightE =
        {
             "       ",
            @"------\",
             "      |",
             "  1   |",
             "  2   |",
            @"\     |",
            @"|     |",
        };
        private static string[] _rightW =
        {
             "|     |",
            @"|     \",
             "|  1   ",
             "|      ",
            @"|  2   ",
            @" \-----",
            @"       ",
        };

        private static string[] _leftN =
        {
             "       ",
            @"-----\ ",
            @"      |",
             "   1  |",
             "   2  |",
            @"\     |",
             "|     |",
        };

        private static string[] _leftS =
        {
             "|     |",
            @"|     \",
            @"|  1   ",
             "|      ",
             "|  2   ",
            @"\------",
             "       ",
        };
        private static string[] _leftE =
        {
             "|     |",
            @"/     |",
             "   1  |",
             "      |",
             "   2  |",
            @"------/",
            @"       ",
        };
        private static string[] _leftW =
        {
             "       ",
            @"/------",
             "|      ",
             "|  1   ",
             "|      ",
            @"|  2  /",
            @"|     |",
        };
        #endregion
        public enum Direction
        {
            North,
            East,
            South,
            West
        }
        public const int xStartCord = 15;
        public const int yStartCord = 15;
        public static Direction Compas = Direction.East;
        public static int xCord;
        public static int yCord;
        public static Race _currentRace;


        *//*

                     foreach (Section section in track.Sections)
                    {
                        SectionData sData = _currentRace.GetSectionData(section);
                        if(section.SectionType == Section.SectionTypes.StartGrid)
                        {
                            Console.WriteLine(sData.Left.Name);
                        }
                    }
         *//*
        public static void Initialize(Race currentRace)
        {
            Track zandvoort = new Track("Zandvoort", new[] {
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.StartGrid,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Finish,
            }
              );
            _currentRace = currentRace;

            _currentRace.DriversChanged += OnDriversChanged;

            DrawTrack(_currentRace.Track);
            
        }

        public static void DrawTrack(Track track)
        {
                 xCord = xStartCord;
                 yCord = yStartCord;
          
            
            foreach (Section section in track.Sections)
            {
               

                
                    


                DrawSection(section);

            }
        }
        public static void DrawSection(Section section)
        {
            *//*            int amountPrinted = 0;
                        Console.SetCursorPosition(xCord, yCord);
            *//*
            setGraphics(section);
            SectionData sData = _currentRace.GetSectionData(section);
     *//*       replacePlaceholder(section, sData.Left, sData.Right);*//*
            int tempY = yCord;
            //Drawing
            foreach (string line in section.Graphic)
            {
                Console.SetCursorPosition(xCord, tempY);
                Console.WriteLine(line);
                tempY++;
                *//*if (amountPrinted < 6)
                {
                    Console.WriteLine(line);
                    amountPrinted++;
                    yCord++;

                }
                else if (amountPrinted >= 6)
                {
                    yCord -= 6;

                }*/
                /*Console.SetCursorPosition(xCord, yCord);*//*

            }
            *//*SetNewCords(section);*//*
            updateDirection(section.SectionType);
            ChangeCursorToNextPosition();
        }

        public static void updateDirection(Section.SectionTypes type)
        {
            if (type == SectionTypes.RightCorner)
            {
                switch (Compas)
                {
                    case Direction.North:
                        Compas = Direction.East;
                        break;
                    case Direction.East:
                        Compas = Direction.South;
                        break;
                    case Direction.South:
                        Compas = Direction.West;
                        break;
                    case Direction.West:
                        Compas = Direction.North;
                        break;
                }
            }
            else if (type == SectionTypes.LeftCorner)
            {
                switch (Compas)
                {
                    case Direction.North:
                        Compas = Direction.West; 
                        break;
                    case Direction.East:
                        Compas = Direction.North;
                        break;
                    case Direction.South:
                        Compas = Direction.East;
                        break;
                    case Direction.West:
                        Compas = Direction.South;
                        break;
                }
            }
        }
        public static void setGraphics(Section section)
        {
            switch (section.SectionType)
            {
                case Section.SectionTypes.Straight:
                    if (Compas == Direction.East)
                    {
                        section.Graphic = _straightE;
                    }
                    else if (Compas == Direction.West)
                    {
                        section.Graphic = _straightW;
                    }
                    else if (Compas == Direction.South)
                    {
                        section.Graphic = _straightS;
                    }
                    else if (Compas == Direction.North)
                    {
                        section.Graphic = _straightN;
                    }
                    break;
                case Section.SectionTypes.LeftCorner:
                    if (Compas == Direction.East)
                    {
                        section.Graphic = _leftE;
                    }
                    else if (Compas == Direction.West)
                    {
                        section.Graphic = _leftW;
                    }
                    else if (Compas == Direction.South)
                    {
                        section.Graphic = _leftS;
                    }
                    else if (Compas == Direction.North)
                    {
                        section.Graphic = _leftN;
                    }
                    break;
                case Section.SectionTypes.RightCorner:
                    if (Compas == Direction.North)
                    {
                        section.Graphic = _rightN;
                    }
                    else if (Compas == Direction.South)
                    {
                        section.Graphic = _rightS;
                    }
                    else if (Compas == Direction.East)
                    {
                        section.Graphic = _rightE;
                    }
                    else if (Compas == Direction.West)
                    {
                        section.Graphic = _rightW;
                    }

                    break;
                case Section.SectionTypes.StartGrid:
                    if (Compas == Direction.East)
                    {
                        section.Graphic = _startE;
                    }
                    else if (Compas == Direction.West)
                    {
                        section.Graphic = _startW;
                    }
                    else if (Compas == Direction.South)
                    {
                        section.Graphic = _startS;
                    }
                    else if (Compas == Direction.North)
                    {
                        section.Graphic = _startN;
                    }
                    break;
                case Section.SectionTypes.Finish:
                    if (Compas == Direction.East)
                    {
                        section.Graphic = _finishE;
                    }
                    else if (Compas == Direction.West)
                    {
                        section.Graphic = _finishW;
                    }
                    else if (Compas == Direction.South)
                    {
                        section.Graphic = _finishS;
                    }
                    else if (Compas == Direction.North)
                    {
                        section.Graphic = _finishN;
                    }
                    break;
                default:
                    break;
            }
        }
        private static void ChangeCursorToNextPosition()
        {
            switch (Compas)
            {
                case Direction.North:
                    yCord -= 7;
                    break;

                case Direction.East:
                    xCord += 7;
                    break;

                case Direction.South:
                    yCord += 7;
                    break;

                case Direction.West:
                    xCord -= 7;
                    break;

             }
        }
                    public static void SetNewCords(Section section)
        {
            switch (section.SectionType)
            {
                case Section.SectionTypes.Straight:
                    if (Compas == Direction.East)
                    {
                        xCord += 7;
                    }
                    else if (Compas == Direction.West)
                    {
                        xCord -= 7;
                    }
                    else if (Compas == Direction.South)
                    {
                        yCord += 7;
                    }
                    else if (Compas == Direction.North)
                    {
                        yCord -= 7;
                    }
                    break;
                case Section.SectionTypes.LeftCorner:
                    if (Compas == Direction.North)
                    {
                        Compas = Direction.West;
                        xCord -= 7;
                    }
                    else if (Compas == Direction.South)
                    {
                        Compas = Direction.East;
                        xCord += 7;
                    }
                    else if (Compas == Direction.East)
                    {
                        Compas = Direction.North;
                        yCord -= 7;
                    }
                    else if (Compas == Direction.West)
                    {
                        Compas = Direction.South;
                        yCord += 7;
                    }
                    break;
                case Section.SectionTypes.RightCorner:
                    if (Compas == Direction.North)
                    {
                        Compas = Direction.East;
                        xCord += 7;
                    }
                    else if (Compas == Direction.South)
                    {
                        Compas = Direction.West;
                        xCord -= 7;
                    }
                    else if (Compas == Direction.East)
                    {
                        Compas = Direction.South;
                        yCord += 7;
                    }
                    else if (Compas == Direction.West)
                    {
                        Compas = Direction.North;
                        yCord -= 7;
                    }

                    break;
                case Section.SectionTypes.StartGrid:
                    if (Compas == Direction.East)
                    {
                        xCord += 7;
                    }
                    else if (Compas == Direction.West)
                    {
                        xCord -= 7;
                    }
                    else if (Compas == Direction.South)
                    {
                        yCord += 7;
                    }
                    else if (Compas == Direction.North)
                    {
                        yCord -= 7;
                    }
                    break;
                case Section.SectionTypes.Finish:
                    if (Compas == Direction.East)
                    {
                        xCord += 7;
                    }
                    else if (Compas == Direction.West)
                    {
                        xCord -= 7;
                    }
                    else if (Compas == Direction.South)
                    {
                        yCord += 7;
                    }
                    else if (Compas == Direction.North)
                    {
                        yCord -= 7;
                    }
                    break;
                default:
                    break;
            }
        }

        private static string[] replacePlaceholder(Section section, IParticipants participantLeft,
            IParticipants participantRight)
        {

            string[] inputS = section.Graphic;
            if (participantLeft != null)
            {

                string firstLetter = participantLeft.Name.Substring(0, 1);
                int counter = 0;
                string[] newString = inputS;
                foreach (string line in inputS)
                {
                    if (line.Contains("1"))
                    { 
                        newString[counter] = line.Replace("1", firstLetter);
                    }
                    else if (line.Contains("2"))
                    {
                        if (participantRight != null)
                        {
                            newString[counter] = line.Replace("2", participantRight.Name.Substring(0, 1));
                        }
                    }
                    else
                    {
                        newString[counter] = line;

                    }
                    counter++;
                }
                inputS = newString;
            }
            else 
            {
                int counter = 0;
                string[] newString = inputS;
                foreach (string line in inputS)
                {

                    if (line.Contains("1"))
                    {

                        newString[counter] = line.Replace("1", " ");
                    }
                    else
                    {
                        newString[counter] = line;

                    }
                    counter++;
                }
                inputS = newString;
            }
             if (participantRight != null)
            {
                string firstLetter = participantRight.Name.Substring(0, 1);
                int counter = 0;
                string[] newString = inputS;
                foreach (string line in inputS)
                {

                    if (line.Contains("2"))
                    {

                        newString[counter] = line.Replace("2", firstLetter);
                    }
                    else
                    {
                        newString[counter] = line;

                    }
                    counter++;
                }

                inputS = newString;
            }
            else
            {
                int counter = 0;
                string[] newString = inputS;
                foreach (string line in inputS)
                {

                    if (line.Contains("2"))
                    {

                        newString[counter] = line.Replace("2", " ");
                    }
                    else
                    {
                        newString[counter] = line;

                    }
                    counter++;
                }
                inputS = newString;
            }

            return inputS;
        }
        public static void OnDriversChanged(object source, DriversChangedEventArgs args)
        {
            
            
                
                DrawTrack(args.track);
            
               
        }


       }
}*/