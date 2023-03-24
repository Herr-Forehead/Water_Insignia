using System;


public class Tile
{
    public enum TileType { Sea, Forest, Mountain };

    public TileType type;

    public Tile(TileType t)
    {
        type = t;

        if (t == TileType.Sea)
        {
            // 
        }
        else if (t == TileType.Forest)
        {
            // 
        }
        else if(t == TileType.Mountain)
        {
            // 
        }
    }
}