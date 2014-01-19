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
        //One and only one of the 3 next bool should be true at the time.
        static bool m_running = true;
        static bool m_jumping = false;
        static bool m_crouching = false;
        static bool unCrouch = false; //Must be initialised to false
        static int crouchWaiting = 2; //Number of states the character stays crouched before going up

        public static Rectangle getRectangle()
        {
            return m_position;
        }

        public static int getCharacterSize()
        {
            return m_characterSize;
        }

        public static void setCrouching()
        {
            if (m_jumping = false && m_running == true)
            {
                m_crouching = true;
                m_running = false;
            }
        }

        public static void setJumping()
        {
            if (m_crouching == false && m_running == true)
            {
                m_crouching = true;
                m_running = false;
            }
        }

        public static int characterMove(GameTime gameTime)
        {
            if (m_running)
            {
                return runningLoop(gameTime);
            }
            else if (m_jumping)
            {
                return jumpingLoop(gameTime);
            }
            else if (m_crouching)
            {
               return crouchingLoop(gameTime);
            }
            else // Should never happen.
            {
                m_running = true;
                m_jumping = false;
                m_crouching = false;
                return runningLoop(gameTime); 
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

                if (actualTileID < 11 && actualTileID >= 3)
                    return ++actualTileID;
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
            if (!m_jumping || actualTileID >=49 || actualTileID < 40) //Should not happen
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
                        m_position.Y -= m_characterSize / 3; //21 pixels pour un bonhomme de 128 pixels.
                    }
                    else if (actualTileID < 48 && actualTileID > 44)
                    {
                        m_position.Y += m_characterSize / 3; //21 pixels pour un bonhomme de 128 pixels.
                    }

                    return actualTileID++;
                }
                else //fin de saut
                {
                    m_position.Y = m_defaultYPosition;
                    actualTileID = 40;
                    m_jumping = false;
                    m_running = true;
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
            if (!m_crouching || actualTileID < 16 || actualTileID > 23)
            {
                actualTileID = 16;
                m_crouching = true;
            }

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                if (actualTileID < 23 && !unCrouch)
                {
                    
                    return ++actualTileID;
                }
                else if (actualTileID == 23 && crouchWaiting >0) //Stays crouched
                {
                    crouchWaiting--;
                    return 23;
                }
                else if (actualTileID == 23 && crouchWaiting == 0)//ready to go up
                {
                    unCrouch = true;
                    return --actualTileID;
                }
                else if (actualTileID > 16 && unCrouch)
                {
                    return --actualTileID;
                }
                else
                {
                    actualTileID = 16;
                    unCrouch = false;
                    m_crouching = false;
                    m_running = true;
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
