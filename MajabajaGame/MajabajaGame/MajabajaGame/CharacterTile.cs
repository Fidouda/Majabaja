using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MajabajaGame
{
    static class CharacterTile
    {
        static public Texture2D TileSetTexture;

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            return new Rectangle(tileIndex % 8 * 128,
                 tileIndex / 8 * 128,
                 128,
                 128);
        }
    }
}
