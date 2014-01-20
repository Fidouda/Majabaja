using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace MajabajaGame
{
    class LifeBar
    {
        // Attributes
        int m_nbHearts;
        int m_heartLimit;
        bool m_isEmpty;

        SpriteBatch m_spriteBatch;
        Vector2 m_heartPosition;
        Texture2D m_liveHeart;
        Texture2D m_deadHeart;

        SoundEffectInstance soundEngineInstance;
        SoundEffect m_life;
        SoundEffect m_hurt;
        

        // Constructor
        public LifeBar(int p_heartLimit, SpriteBatch p_spriteBatch, Texture2D p_liveHeart,Texture2D p_deadHeart, SoundEffect p_life, SoundEffect p_hurt) 
        {
            m_isEmpty = false;
            m_heartLimit = p_heartLimit;
            m_nbHearts = p_heartLimit;

            // Hard Coded Lifebar location
            m_heartPosition = new Vector2(0, 20);

            // Attributes from definition
            m_spriteBatch = p_spriteBatch;
            m_liveHeart = p_liveHeart;
            m_deadHeart = p_deadHeart;

            //Load Sounds
            m_life = p_life;
            m_hurt = p_hurt;
        }

        // Action Methods

        // Refills lifeBar to limit
        public void replenish() 
        {
            m_nbHearts = m_heartLimit;
        }

        // Adds a living heart
        public void addHeart()
        {

            if (m_nbHearts < m_heartLimit)
            {
                m_nbHearts++;
                soundEngineInstance = m_life.CreateInstance();
                soundEngineInstance.Play();
            }
        }

        //  Removes a living heart
        public void removeHeart()
        {
            m_nbHearts--;
            soundEngineInstance = m_hurt.CreateInstance();
            soundEngineInstance.Play();
            if(m_nbHearts <= 0)
            {
                m_isEmpty = true;
            }
        }

        // is life bar empty ?
        public bool isEmpty() 
        {
            return m_isEmpty;
        }

        public void Draw() 
        {
            for (int i = 0; i < m_nbHearts; ++i) 
            {
                m_heartPosition.X += 50;
                m_spriteBatch.Draw(m_liveHeart, m_heartPosition, Color.White);
            }

            for (int j = 0; j < m_heartLimit - m_nbHearts; j++)
            {
                m_heartPosition.X += 50;
                m_spriteBatch.Draw(m_deadHeart, m_heartPosition, Color.White);
            }

            // Resets heart position
            m_heartPosition.X = 0;
            
        }






    }
}
