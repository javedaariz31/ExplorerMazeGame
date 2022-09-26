using static System.Console;

namespace Explorer.Maze.Console
{
    public class Player
    {
        public int x { get; set; }
        public int y { get; set; }

        public string PlayerMarker;

        private ConsoleColor playerColor;

        public Player(int intialX, int initialY)
        {
            x = intialX;
            y = initialY;
            PlayerMarker = "O";
            playerColor = ConsoleColor.Blue;
        }

        public void Draw()
        {
            ForegroundColor = playerColor;
            SetCursorPosition(x, y);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}
