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
        static int m_defaultYPosition = 9 * 32;
        static int m_XPosition = 5 * 32;
        static int m_YPosition = 9 * 32;
        static Rectangle m_position = new Rectangle(m_defaultXPosition, m_defaultYPosition, m_characterSize, m_characterSize);
        //One and only one of the 3 next bool should be true at the time.
        static bool m_running = true;
        static bool m_jumping = false;
        static bool m_crouching = false;
        static bool unCrouch = false; //Must be initialised to false
        static int crouchWaiting = 2; //Number of states the character stays crouched before going up
        static int jumpingWaiting = 2;  //Number of states the character stays high before go down

        public static TileMap levelObstacle;
        public static Vector2 camera;

        public static void resetCharacter()
        {
           actualTileID = 0;
           timeSinceLastFrame = 0;
           millisecondsPerFrame = 65;
           m_characterSize = 128;
           m_defaultXPosition = 5 * 32;
           m_defaultYPosition = 9 * 32;
           m_XPosition = 5 * 32;
           m_YPosition = 9 * 32;
           m_position = new Rectangle(m_defaultXPosition, m_defaultYPosition, m_characterSize, m_characterSize);
           //One and only one of the 3 next bool should be true at the time.
           m_running = true;
           m_jumping = false;
           m_crouching = false;
           unCrouch = false; //Must be initialised to false
           crouchWaiting = 2; //Number of states the character stays crouched before going up
           jumpingWaiting = 2;  //Number of states the character stays high before go down

           levelObstacle = null;
           camera = Vector2.Zero;
        }

        public static Rectangle getRectangle()
        {
            return m_position;
        }

        public static Rectangle getRectangleCollision()
        {
            if (m_crouching)
            {
                return new Rectangle(m_defaultXPosition, m_defaultYPosition + 64, m_characterSize, m_characterSize / 2);
            }
            return m_position;
        }             

        public static int getCharacterSize()
        {
            return m_characterSize;
        }

        public static float getPositionX()
        {
            return m_position.X;
        }

        public static void setPositionY(int p_Y) 
        {
            m_YPosition = p_Y;
        }

        public static bool isJumping() 
        {
            return m_jumping;
        }

        public static void setCrouching()
        {
            if (m_jumping == false && m_running == true)
            {
                m_crouching = true;
                m_running = false;
            }
        }

        public static void setJumping()
        {
            if (m_crouching == false && m_running == true)
            {
                m_jumping = true;
                m_running = false;
            }
        }

        public static int characterMove(GameTime gameTime)
        {
            if (m_running)
            {
                if (levelObstacle != null && levelObstacle.Rows[34 - ((480 - Character.m_position.Y) / 64)].Columns[((int)camera.X + Character.m_position.X) / 64].TileID == '0' || m_YPosition - m_position.Y != 0)
                {
                    if (m_YPosition - m_position.Y == 0)
                    {
                        m_YPosition += 64;
                    }
                    
                    if ( m_YPosition - m_position.Y > m_characterSize / 3)
                        {
                            m_position.Y += m_characterSize / 3; //21 pixels pour un bonhomme de 128 pixels.
                        }
                        else if (m_YPosition - m_position.Y < m_characterSize / 3) 
                        {
                            m_position.Y = m_YPosition;
                        }
                }
                return runningLoop(gameTime);
            }
            else if (m_jumping)
            {
                return jumpingLoop(gameTime);
            }
            else if (m_crouching)
            {
                if (levelObstacle != null && levelObstacle.Rows[34 - ((480 - Character.m_position.Y) / 64)].Columns[((int)camera.X + Character.m_position.X) / 64].TileID == '0')
                {
                    if (m_YPosition - m_position.Y == 0)
                    {
                        m_YPosition += 64;
                    }

                    if (m_YPosition - m_position.Y > m_characterSize / 3)
                    {
                        m_position.Y += m_characterSize / 3; //21 pixels pour un bonhomme de 128 pixels.
                    }
                    else if (m_YPosition - m_position.Y < m_characterSize / 3)
                    {
                        m_position.Y = m_YPosition;
                    }
                }
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
                    // Raise
                    if (actualTileID < 43)
                    {
                        m_position.Y -= m_characterSize / 3; //21 pixels pour un bonhomme de 128 pixels.
                    } 
                    // Stay up
                    else if (actualTileID == 44 && jumpingWaiting > 0)
                    {
                        jumpingWaiting--;
                        return actualTileID;
                    }
                    // Go Down
                    else if (actualTileID < 48 && actualTileID > 43)
                    {
                        if ( m_YPosition - m_position.Y > m_characterSize / 3)
                        {
                            m_position.Y += m_characterSize / 3; //21 pixels pour un bonhomme de 128 pixels.
                        }
                        else if (m_YPosition - m_position.Y < m_characterSize / 3) 
                        {
                            m_position.Y = m_YPosition;
                        }
                        jumpingWaiting = 2; //Re-initialising the value
                    }

                    return actualTileID++;
                }
                else //fin de saut
                {
                    // Stops on new surface of height m_YPosition
                    m_position.Y = m_YPosition;
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
                    crouchWaiting = 2;
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
