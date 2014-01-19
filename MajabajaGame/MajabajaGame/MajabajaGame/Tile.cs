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

    static class DecorationTile
    {
        static public Texture2D DecorationTileSetTexture;
        static public int TileWidth = 64;
        static public int TileHeight = 64;

        static public Vector2 originPoint = new Vector2(19, 39); //WHY??

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (DecorationTileSetTexture.Width / TileWidth);
            int tileX = tileIndex % (DecorationTileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }


    static class ObstacleTile
    {
        static public Texture2D ObstacleTileSetTexture;
        static public int TileWidth = 64;
        static public int TileHeight = 64;

        static public Vector2 originPoint = new Vector2(19, 39); //WHY??

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (ObstacleTileSetTexture.Width / TileWidth);
            int tileX = tileIndex % (ObstacleTileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }

        static public bool checkCollision(Rectangle p_characterposition, int p_tileIndex)
        {
            Rectangle tile = GetSourceRectangle(p_tileIndex);
            return tile.Intersects(p_characterposition);
        }
    }

}