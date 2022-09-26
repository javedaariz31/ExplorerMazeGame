using static System.Console;

namespace Explorer.Maze.Console
{
    public class World
    {
        private string[,] _grid { get; set; }
        private int _rows { get; set; }
        private int _cols { get; set; }


        public World(string[,] grid)
        {
            _grid = grid;
            _rows = grid.GetLength(0);
            _cols = grid.GetLength(1);
        }

        //draw the maze world
        public void Draw()
        {
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _cols; c++)
                {
                    string element = _grid[r, c];
                    SetCursorPosition(c, r);
                    Write(element);
                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return _grid[y, x];
        }

        public bool IsWalkablePosition(int x, int y)
        {
            //check bounderies  
            if (x < 0 || y < 0 || x >= _rows || y >= _cols)
            {
                return false;
            }

            //if grid is walkable tile.
            return _grid[y, x] == " " || _grid[y, x] == "X";
        }
    }
}
