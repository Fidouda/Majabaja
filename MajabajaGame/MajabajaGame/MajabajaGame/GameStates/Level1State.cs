using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajabajaGame
{
    class Level1State : AbstractState
    {
        //private Square aSquare;
        //private Rectangle background;
        //private Song m_level1Music;

        public Level1State(Game1 p_game)
            : base(p_game)
        {
            //aSquare = new Square(p_game, "square");
            //background = new Rectangle(p_game, "b_daisy");
            LoadContent();
        }

        public override void LoadContent()
        {
            //background.LoadContent();
            //aSquare.LoadContent();
            //m_level1Music = m_game.Content.Load<Song>("drumBeat");
            //MediaPlayer.Play(m_level1Music);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //aSquare.Draw(gameTime);
            //background.Draw(gameTime);
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.M))
            {
                // stop the music
                //MediaPlayer.Stop();

                // change state to menu
                m_game.setGameState(new MainMenuState(m_game));
            }

            // Player Square control
            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.Left))
            {
                //aSquare.addX(-m_game.GraphicsDevice.Viewport.Width / 100);
            }

            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.Right))
            {
                //aSquare.addX(m_game.GraphicsDevice.Viewport.Width / 100);
            }

            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.Down))
            {
                //aSquare.addY(m_game.GraphicsDevice.Viewport.Width / 100);
            }

            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.Up))
            {
                //aSquare.addY(-m_game.GraphicsDevice.Viewport.Width / 100);
            }

            base.Update(gameTime);
        }
    }
}
