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
        static int millisecondsPerFrame = 75;
        static Rectangle m_position = new Rectangle(5 * 32, 12 * 32, 64, 64);
        static bool m_running = false;
        static bool m_jumping = false;
        static bool m_crouching = false;
        public static Rectangle getRectangle() 
        {
            return m_position;
        }


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
                        m_position.Y -= 20;
                    }
                    else if (actualTileID > 45)
                    {
                        m_position.Y += 20;
                    }
                    else
                    {
                        
                    }

                    
                    return actualTileID++;
                }
                else
                {
                    m_position.Y = 12 * 32;
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
