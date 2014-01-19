using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MajabajaGame
{
    static class Character
    {

        //On mettra ici la barre de vie

        static int actualTileID = 0;
        static int timeSinceLastFrame = 0;
        static int millisecondsPerFrame = 65;
        static int m_characterSize = 128;
        static int m_defaultXPosition = 5 * 32;
        static int m_defaultYPosition = 10 * 32;
        static Rectangle m_position = new Rectangle(m_defaultXPosition, m_defaultYPosition, m_characterSize, m_characterSize);
        static bool m_running = false;
        static bool m_jumping = false;
        static bool m_crouching = false;

        public static Rectangle getRectangle()
        {
            return m_position;
        }

        public static int getCharacterSize()
        {
            return m_characterSize;
        }

        // Ne devrait plus servir (lis toutes les tiles du bonhomme)
        public static int nextTileID()
        {
            if (actualTileID < 64)
                return ++actualTileID;
            else
            {
                actualTileID = 0;
                return actualTileID;
            }
        }

        public static int runningLoop(GameTime gameTime)
        {
            if (!m_running)
            {
                actualTileID = 4;
                m_running = true;
            }

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                if (actualTileID < 11)
                    return actualTileID++;
                else
                {
                    actualTileID = 4;
                    return actualTileID;
                }

            }
            else
            {
                return actualTileID;
            }
        }



        public static int jumpingLoop(GameTime gameTime)
        {
            if (!m_jumping)
            {
                actualTileID = 40;
                m_jumping = true;
            }

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                if (actualTileID < 48)
                {
                    if (actualTileID < 43)
                    {
                        m_position.Y -= m_characterSize / 6; //21 pixels pour un bonhomme de 128 pixels.
                    }
                    else if (actualTileID > 45)
                    {
                        m_position.Y += m_characterSize / 6; //21 pixels pour un bonhomme de 128 pixels.
                    }

                    return actualTileID++;
                }
                else
                {
                    m_position.Y = m_defaultYPosition;
                    actualTileID = 40;
                    return actualTileID;
                }

            }
            else
            {
                return actualTileID;
            }
        }



        public static int crouchingLoop(GameTime gameTime)
        {
            if (!m_crouching)
            {
                actualTileID = 40;
                m_crouching = true;
            }

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                if (actualTileID < 23)
                {
                    return actualTileID++;
                }
                else
                {
                    actualTileID = 16;
                    return actualTileID;
                }

            }
            else
            {
                return actualTileID;
            }
        }




    }
}
