using System;
using Raylib_cs;

public class Armored
{
     public Texture2D sprite;
     public Rectangle rect;
     public (int x, int y) startPos;
     public Stats stats = new Stats();
     public int mov = 5;

    public Armored(Texture2D s, int startX, int startY)
    {

        startPos = (startX, startY);
        sprite = s;
        rect = new Rectangle(startPos.x, startPos.y, sprite.width, sprite.height);

    }
}
