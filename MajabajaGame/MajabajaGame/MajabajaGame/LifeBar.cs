using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajabajaGame
{
    class LifeBar
    {
        // Attributes
        int m_nbHearts;
        int m_heartLimit;
        bool m_isEmpty;

        // Constructor
        public LifeBar(int p_heartLimit) 
        {
            m_isEmpty = false;
            m_heartLimit = p_heartLimit;
            m_nbHearts = p_heartLimit;
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
            
            if (m_nbHearts > m_heartLimit)
            {
                m_nbHearts++;
            }
        }

        //  Removes a living heart
        public void removeHeart()
        {
            m_nbHearts--;
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
    }
}
