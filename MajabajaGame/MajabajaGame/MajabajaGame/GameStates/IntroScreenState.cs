using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;

namespace MajabajaGame
{
    class IntroScreenState : AbstractGameState
    {
        SpriteBatch spriteBatch;

        Vector2 m_backgroundPosition;
        Texture2D m_backgroundImage;
        private Song m_introMusic;
        MouseState m_mouse;

        //Anti bounce
        int timeSinceLastFrame = 0;
        static int millisecondsPerFrame = 4000;


        public IntroScreenState(Game1 p_game)
            : base(p_game)
        {
            LoadContent();
        }


        public override void LoadContent()
        {
            // New spriteBatch
            spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

            // Loads the image than positions buttons and set there active field
            m_backgroundImage = m_game.Content.Load<Texture2D>("introBackground");

            // Positions
            m_backgroundPosition = new Vector2(0, 0);

            // Music load and starts
            m_introMusic = m_game.Content.Load<Song>("Brirfing_theme_0");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(m_introMusic);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(m_backgroundImage, m_backgroundPosition, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            m_mouse = Mouse.GetState();

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {

                if (m_mouse.LeftButton == ButtonState.Released)
                {
                    m_game.setGameState(new Level1State(m_game));
                }
            }

            this.HandleInputTouch(gameTime);

            base.Update(gameTime);
        }

        public override void HandleInputTouch(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }
    }
}
