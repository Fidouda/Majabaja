using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MajabajaGame
{
    static class BackgroundTile
    {
        static public Texture2D BackgroundTileSetTexture;
        static public int TileWidth = 128;
        static public int TileHeight = 128;

        static public Vector2 originPoint = new Vector2(19, 39); //WHY??

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (BackgroundTileSetTexture.Width / TileWidth);
            int tileX = tileIndex % (BackgroundTileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }


}