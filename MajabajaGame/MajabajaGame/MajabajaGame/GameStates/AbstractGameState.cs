using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajabajaGame
{
    public abstract class AbstractGameState
    {
        // Attributs
        protected Game1 m_game;

        // Méthodes
        protected AbstractGameState(Game1 p_game)
        {
            this.m_game = p_game;
        }

        public virtual void LoadContent()
        {
            // Load abstract state content here
        }

        public virtual void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Update code common to every state
        }

        public virtual void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Draw code common to every state
        }
    }
}
