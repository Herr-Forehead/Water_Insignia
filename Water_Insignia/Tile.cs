using System;
using Raylib_cs;
// create system for different types of tiles
// create a variable with enum
// use to create subtypes
// use if and else to create conditions for the different tiles
// use loop to make rectangles 


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