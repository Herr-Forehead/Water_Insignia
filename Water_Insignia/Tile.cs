using System;
using Raylib_cs;


public class Tile
{
    public enum TileType { Sea, Forest, Mountain, Regular, };

    public TileType type;
    public Rectangle rect;

    

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
        else if (t == TileType.Regular)
        {
            // 
        }
    }
}