using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajabajaGame
{
    class MainMenuState : AbstractGameState
    {
        //private Rectangle m_instructions;
        //private Song m_backgroundMusic;

        public MainMenuState(Game1 p_game)
            : base(p_game)
        {
            //m_instructions = new Rectangle(p_game, "instructions");
            LoadContent();
        }

        public override void LoadContent()
        {
            //m_instructions.LoadContent();
            //m_instructions.setPosition(m_game.GraphicsDevice.Viewport.Width / 2 - m_instructions.getWidth() / 2,
            //    m_game.GraphicsDevice.Viewport.Height / 2 - m_instructions.getHeight() / 2);
            //m_backgroundMusic = m_game.Content.Load<Song>("accept");
            //MediaPlayer.Play(m_backgroundMusic);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //m_instructions.Draw(gameTime);
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.NumPad1))
            {
                m_game.setGameState(new Level1State(m_game));
            }
            base.Update(gameTime);
        }
    }
}
