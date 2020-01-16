namespace TicTacToe.Models
{
    public class GameMap
    {
        public int Size { get; set; } = 3;
        public string Name { get; set; } = "3x3";
        public Tile[][] Tiles { get; set; }

        public GameMap()
        {
            GenerateMap();
        }

        public void GenerateMap()
        {
            Tiles = new Tile[Size][];
            for (int i = 0; i < Size; i++)
            {
                Tiles[i] = new Tile[Size];
                for(int x = 0; x < Size; x++)
                {
                    Tiles[i][x] = new Tile();
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
