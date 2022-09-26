using static System.Console;

namespace Explorer.Maze.Console
{
    public class Game
    {
        private World _world;
        private Player _player;

        public void Start()
        {

            string[,] grid =
            {
                {"+","+","+","+","+","+","+"},
                {" "," ","+","+"," "," ","X"},
                {"+"," ","+","+"," ","+","+"},
                {"+"," ","+","+"," "," "," "},
                {"+"," "," "," "," ","+","+"},
                {"+","+","+","+","+","+","+"},
            };


            _world = new World(grid);
            _player = new Player(0, 1);

            RunGameLoop();
        }


        private void DrawFrame()
        {
            Clear();
            _world.Draw();
            _player.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (_world.IsWalkablePosition(_player.x - 1, _player.y))
                        _player.x -= 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (_world.IsWalkablePosition(_player.x, _player.y - 1))
                        _player.y -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (_world.IsWalkablePosition(_player.x + 1, _player.y))
                        _player.x += 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (_world.IsWalkablePosition(_player.x, _player.y + 1))
                        _player.y += 1;
                    break;
                default:
                    break;
            }
        }

        public void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                //Draw World 
                DrawFrame();

                //Check  the input for player
                HandlePlayerInput();

                //Check if we have end the game. 
                string elementPlayerPass = _world.GetElementAt(_player.x, _player.y);
                if (elementPlayerPass == "X")
                {
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();

        }


        public void DisplayIntro()
        {
            WriteLine("Welcome to the Maze Game");
            WriteLine("\n Instructions ");
            WriteLine(" > Use Arrow Keys to Move.");
            Write(" > Try to reach to the goal which looks like this : ");
            ForegroundColor = ConsoleColor.Green;
            ResetColor();
            WriteLine("X");
            WriteLine("Press Any Key to start ");
            ReadKey(true);
        }

        public void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped !");
            WriteLine("Thank you...");
            WriteLine("Press any key to exit....");
            ReadKey(true);
        }
    }
}
