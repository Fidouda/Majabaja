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
            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(m_introMusic);
            }


            TouchCollection touches = TouchPanel.GetState();

            while(TouchPanel.IsGestureAvailable)
                {
                // read the next gesture from the queue
                GestureSample gesture = TouchPanel.ReadGesture();
            
                // we can use the type of gesture to determine our behavior
                switch (gesture.GestureType)
                {
                    case GestureType.DoubleTap:
                        {
                            m_game.setGameState(new Level1State(m_game));
                        }
                        break;
            
                    default:
                        break;
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
