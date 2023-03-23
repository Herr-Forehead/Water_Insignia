using System;


public class Tile
{
    public enum TileType { Sea, Forest, Mountain };

    public TileType type;

    public Tile(TileType t)
    {
        type = t;
    }
}