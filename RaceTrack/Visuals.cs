using Controller;
using Model;
using static Model.Section;

namespace RaceTrack;

public class Visuals
{
    private static int _posX = Console.WindowWidth / 2;
    private static int _posY = Console.WindowWidth / 2;
    private static Race _currentRace;
    private static Direction _currentDirection = Direction.E;
    private static Track _track;


    #region graphics

    // Startgrid
    // Track always starts horizontal pointing right (East)
    private static string[] _startGrid = { "════", " 1] ", " 2] ", "════" };

    // Finishgrid
    private static string[] _finishNorth = { "║  ║", "║▒▒║", "║12║", "║  ║" };
    private static string[] _finishEast = { "════", " 1▒ ", " 2▒ ", "════" };
    private static string[] _finishSouth = { "║1 ║", "║  ║", "║▒▒║", "║ 2║" };
    private static string[] _finishWest = { "════", " ▒1 ", " ▒2 ", "════" };

    // Straight
    private static string[] _straightHorizontal = { "════", " 1  ", " 2  ", "════" };
    private static string[] _straightdVertical = { "║  ║", "║12║", "║  ║", "║  ║" };

    // Corners
    private static string[] _cornerLeftTop = { "╔═══", "║1  ", "║  2", "║  ╔" };
    private static string[] _cornerLeftBottom = { "║  ╚", "║  2", "║1  ", "╚═══" };
    private static string[] _cornerRightTop = { "═══╗", "  1║", "2  ║", "╗  ║" };
    private static string[] _cornerRightBottom = { "╝  ║", "2  ║", "1  ║", "═══╝" };

    #endregion

    // Initialize the race
    public static void Initialize(Race race)
    {

        _currentRace = race;
        _track = race.Track;

        // Prepare the console for visualisation
        ConsoleInit();

        // Draw the Track for the current race
        DrawTrack(_track);
        _currentRace.DriversChanged += OnDriversChanged;
    }

    // Prepare the console and write race info
    private static void ConsoleInit()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
    }

    // Event handler when drivers change position
    public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
    {
        DrawTrack(e.track);
    }

     

    public static void OnNextRaceEvent(object sender, NextRaceEventArgs e)
    {
        Initialize(e.Race);
        _currentRace.DriversChanged += OnDriversChanged;
        DrawTrack(_currentRace.Track);
    }
    // Draw the Track by drawing every section
    private static void DrawTrack(Track track)
    {
        _posX = 50;
        _posY = 10;

        // Set cursor position before drawing
        Console.SetCursorPosition(_posX, _posY);

        // Print each Track section.
        foreach (Section section in track.Sections)
        {
            DrawSection(section);
        }
    }

    // Draw a single section
    private static void DrawSection(Section section)
    {
        // Fetch the right visual according to it's direction
        string[] sectionVisual = PlaceParticipantsOnSection(GetSectionVisual(section.SectionType, _currentDirection), _currentRace.GetSectionData(section));


        // Print each string in the array to form the visual
        int currentY = _posY;
        foreach (string s in sectionVisual)
        {
            try
            {
                Console.SetCursorPosition(_posX, currentY);
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
            Console.WriteLine(s);
            currentY++;
        }
        UpdateDirection(section.SectionType);
        UpdateCursor();
    }


    private static String[] PlaceParticipantsOnSection(String[] SectionVisual, SectionData sectionData)
    {
        String[] vs = new String[SectionVisual.Length];
        String left = " ";
        String right = " ";
        if (sectionData.Left != null)
        {
            left = sectionData.Left.Equipment.IsBroken ? "\u2620" : sectionData.Left.Name.Substring(0, 1);
        }
        if (sectionData.Right != null)
        {
            right = sectionData.Right.Name.Substring(0, 1);

        }
        for (int i = 0; i < SectionVisual.Length; i++)
        {
            vs[i] = SectionVisual[i].Replace("1", left).Replace("2", right);
        }
        return vs;
    }

    // Visualize the Participants on the Track section
    /*        private static string[] VisualizeParticipants(string[] sectionVisual, IParticipant leftParticipant, IParticipant rightParticipant)
            {
                // Create returnstring with updated section visual
                string[] updatedSectionVisual = new string[sectionVisual.Length];
                // Create the new visual for each participant
                string leftVisual = leftParticipant == null ? " " : leftParticipant.Equipment.IsBroken ? "X" : leftParticipant.Name.Substring(0, 1).ToUpper();
                string rightVisual = rightParticipant == null ? " " : rightParticipant.Equipment.IsBroken ? "X" : rightParticipant.Name.Substring(0, 1).ToUpper();
                // Update the static numbers to the new visuals
                for (int i = 0; i < updatedSectionVisual.Length; i++)
                {
                    updatedSectionVisual[i] = sectionVisual[i].Replace("1", leftVisual).Replace("2", rightVisual);
                }
                return updatedSectionVisual;
            }
    */        // Update the direction if corner is printed
    private static void UpdateDirection(SectionTypes type)
    {
        if (type == SectionTypes.RightCorner)
        {
            switch (_currentDirection)
            {
                case Direction.N:
                    _currentDirection = Direction.E;
                    break;
                case Direction.E:
                    _currentDirection = Direction.S;
                    break;
                case Direction.S:
                    _currentDirection = Direction.W;
                    break;
                case Direction.W:
                    _currentDirection = Direction.N;
                    break;
            }
        }
        else if (type == SectionTypes.LeftCorner)
        {
            switch (_currentDirection)
            {
                case Direction.N:
                    _currentDirection = Direction.W;
                    break;
                case Direction.E:
                    _currentDirection = Direction.N;
                    break;
                case Direction.S:
                    _currentDirection = Direction.E;
                    break;
                case Direction.W:
                    _currentDirection = Direction.S;
                    break;
            }
        }
    }

    // Update cursor to next position depending on direction
    // TODO: Use Section to get the length of the section and use that instead of static 4
    private static void UpdateCursor()
    {
        int size = 4;

        switch (_currentDirection)
        {
            case Direction.N:
                _posY -= size;
                break;

            case Direction.E:
                _posX += size;
                break;

            case Direction.S:
                _posY += size;
                break;

            case Direction.W:
                _posX -= size;
                break;
        }
    }

    // Get the correct section visual according to the direction
    private static string[] GetSectionVisual(SectionTypes sectionType, Direction direction)
    {
        return sectionType switch
        {
            SectionTypes.StartGrid => _startGrid,
            SectionTypes.Finish => direction switch
            {
                Direction.N => _finishNorth,
                Direction.E => _finishEast,
                Direction.S => _finishSouth,
                Direction.W => _finishWest,
                _ => throw new NotImplementedException()
            },
            SectionTypes.Straight => direction switch
            {
                Direction.N => _straightdVertical,
                Direction.E => _straightHorizontal,
                Direction.S => _straightdVertical,
                Direction.W => _straightHorizontal,
                _ => throw new NotImplementedException()
            },
            SectionTypes.RightCorner => direction switch
            {
                Direction.N => _cornerLeftTop,
                Direction.E => _cornerRightTop,
                Direction.S => _cornerRightBottom,
                Direction.W => _cornerLeftBottom,
                _ => throw new NotImplementedException()
            },
            SectionTypes.LeftCorner => direction switch
            {
                Direction.N => _cornerRightTop,
                Direction.E => _cornerRightBottom,
                Direction.S => _cornerLeftBottom,
                Direction.W => _cornerLeftTop,
                _ => throw new NotImplementedException()
            },
            _ => throw new NotImplementedException()
        };
    }

    // Define the Track directions
    public enum Direction
    {
        N,
        E,
        S,
        W
    }
}