using Raylib_cs;

// Fire emblemesque game

// create tilesystem
// make it so that characters can only move through the tiles and only a certain amount of tiles
// add different kinds of tiles that restrict or affect movement like water or forrest tiles
// add more characters with different movement types
// add music

// if I get this far, try to add enemies and add turns
// different weapon types and character classes
// add weapon durability
// add stats and combat
// feebly attempt to make somewhat of an enemy AI

Raylib.InitWindow(600, 800, "Water Insignia");
Raylib.SetTargetFPS(60);
Raylib.InitAudioDevice();

Color selectorBlue = new Color(0, 102, 204, 127);

//Sprites, Images and Variables
Texture2D bkgImage = Raylib.LoadTexture("background.png");
Infantry i = new Infantry(Raylib.LoadTexture("gremory.png"), 0, 64);
Infantry i2 = new Infantry(Raylib.LoadTexture("stolencharacteravatar.png"), 64, 64);
Flyer i3 = new Flyer(Raylib.LoadTexture("Barbarossa.png"), 0, 768);
Rectangle AvatarRect;
Rectangle AvatarRect2;
Rectangle Enemyrect;
Rectangle Selector = new Rectangle(0, 0, 32, 32);
int tileSize = 32;
string currentScene = "start";
int characters = 2;

while (!Raylib.WindowShouldClose())
{
    // Logik

    if (currentScene == "start")
    {
        AvatarRect = i.rect;
        AvatarRect2 = i2.rect;
        Enemyrect = i3.rect;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "plrTurn";
        }
    }
    else if (currentScene == "plrTurn")
    {
        // movement
        if (Raylib.IsKeyReleased(KeyboardKey.KEY_RIGHT))
        {
            Selector.x += 32;
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.KEY_LEFT))
        {
            Selector.x -= 32;
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.KEY_UP))
        {
            Selector.y -= 32;
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.KEY_DOWN))
        {
            Selector.y += 32;
        }
        // moving characters

        // Give avatar characters movement and movement limits
        // Make it so they only move when in contact with selector
        if (Raylib.CheckCollisionRecs(Selector, i.rect) == true && Raylib.IsKeyDown(KeyboardKey.KEY_ENTER) || Raylib.CheckCollisionRecs(Selector, i.rect) == true && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            if (i.mov >= 0)
            {
                if (Raylib.IsKeyReleased(KeyboardKey.KEY_RIGHT))

                    i.startPos.x += 32;
                i.mov--;
            }
            else if (Raylib.IsKeyReleased(KeyboardKey.KEY_LEFT))
            {
                i.startPos.x -= 32;
                i.mov--;
            }
            else if (Raylib.IsKeyReleased(KeyboardKey.KEY_UP))
            {
                i.startPos.y -= 32;
                i.mov--;
            }
            else if (Raylib.IsKeyReleased(KeyboardKey.KEY_DOWN))
            {
                i.startPos.y += 32;
                i.mov--;
            }
        }
        else if (Raylib.CheckCollisionRecs(Selector, i2.rect) == true && Raylib.IsKeyDown(KeyboardKey.KEY_ENTER) || Raylib.CheckCollisionRecs(Selector, i2.rect) == true && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            if (i2.mov >= 0)
            {

                if (Raylib.IsKeyReleased(KeyboardKey.KEY_RIGHT))
                {
                    i2.rect.x += 32;
                    i2.mov--;
                }
                else if (Raylib.IsKeyReleased(KeyboardKey.KEY_LEFT))
                {
                    i2.rect.x -= 32;
                    i2.mov--;
                }
                else if (Raylib.IsKeyReleased(KeyboardKey.KEY_UP))
                {
                    i2.rect.y -= 32;
                    i2.mov--;
                }
                else if (Raylib.IsKeyReleased(KeyboardKey.KEY_DOWN))
                {
                    i2.rect.y += 32;
                    i2.mov--;
                }
            }
        }
        // death condition
        if (Raylib.CheckCollisionRecs(i.rect, i3.rect) || Raylib.CheckCollisionRecs(i2.rect, i3.rect))
        {
            currentScene = "death";
            characters -= 1;
        }
        // game over condition
        if (characters < 0 || characters == 0)
        {
            currentScene = "gameOver";
        }
        // enemy movement amount reset
        if (i.mov < 0 && i2.mov < 0)
        {
            currentScene = "nmyTurn";
            i3.mov = 5;
        }
    }
    else if (currentScene == "nmyTurn")
    {
        // enemny movement algorithm

        // Give enemy movement and movement limit
        // Make enemy movement based off of avatar position
        if (i.startPos.x > i3.rect.x)
        {
            i3.rect.x += 32;
            i3.mov--;
        }
        else if (i.startPos.x < i3.rect.x)
        {
            i3.rect.x -= 32;
            i3.mov--;
        }
        else if (i.startPos.y > i3.rect.y)
        {
            i3.rect.y += 32;
            i3.mov--;
        }
        else if (i.startPos.y < i3.rect.y)
        {
            i3.rect.y -= 32;
            i3.mov--;
        }
        // death condition
        if (Raylib.CheckCollisionRecs(i.rect, i3.rect) || Raylib.CheckCollisionRecs(i2.rect, i3.rect))
        {
            currentScene = "death";
        }
        // avatar movement reset
        if (i3.mov < 0 || i3.mov == 0)
        {
            currentScene = "plrTurn";
            i.Reset();
            i2.Reset();
        }
    }
    else if (currentScene == "death")
    {

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "start";
            // bugged
        }
    }
    else if (currentScene == "gameOver")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "start";
        }
    }
    else if (currentScene == "end")
    {
        // as of yet, not achievable
    }

    // Music

    Musik.PlayMusic(currentScene);

    // Grafik

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "start")
    {
        Raylib.DrawText("press Enter to start", 100, 300, 48, Color.DARKBLUE);
    }
    else if (currentScene == "plrTurn" || currentScene == "nmyTurn")
    {
        Raylib.DrawTexture(bkgImage, 0, 0, Color.WHITE);
        Raylib.DrawTexture(i.sprite, (int)i.startPos.x, (int)i.startPos.y, Color.WHITE);
        Raylib.DrawTexture(i2.sprite, (int)i2.rect.x, (int)i2.rect.y, Color.WHITE);
        Raylib.DrawTexture(i3.sprite, (int)i3.rect.x, (int)i3.rect.y, Color.WHITE);
        Raylib.DrawRectangleRec(Selector, selectorBlue);

        for (int x = 0; x < Raylib.GetScreenWidth() + 1 / tileSize; x++)
        {
            Raylib.DrawLine(x * tileSize, 0, x * tileSize, Raylib.GetScreenHeight(), Color.BLACK);
        }
        for (int y = 0; y < Raylib.GetScreenHeight() / tileSize; y++)
        {
            Raylib.DrawLine(Raylib.GetScreenWidth(), y * tileSize, 0, y * tileSize, Color.BLACK);
        }
    }
    else if (currentScene == "Death")
    {
        Raylib.ClearBackground(Color.WHITE);
    }
    else if (currentScene == "gameOver")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("crinch", 100, 300, 38, Color.RED);
    }
    else if (currentScene == "end")
    {
        Raylib.DrawText("impossible", 100, 300, 38, Color.DARKBLUE);
    }

    // hielo
    Raylib.EndDrawing();
}