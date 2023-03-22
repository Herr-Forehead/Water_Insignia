using System;
using Raylib_cs;

public class Armored
{
     public Texture2D sprite;
     public Rectangle rect;
     public (int x, int y) startPos;
     public Stats stats = new Stats();
     public int mov = 2;
      public int maxMov = 2;

    public void Reset()
    {
        mov = maxMov;
    }

    public Armored(Texture2D s, int startX, int startY)
    {

        startPos = (startX, startY);
        sprite = s;
        rect = new Rectangle(startPos.x, startPos.y, sprite.width, sprite.height);

    }
}
