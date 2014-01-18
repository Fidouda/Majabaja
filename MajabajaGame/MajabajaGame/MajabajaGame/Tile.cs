using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MajabajaGame
{
    static class Tile
    {
        static public Texture2D TileSetTexture;

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            return new Rectangle(tileIndex * 128, 0, 128, 128);
        }


    }
}