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
        class DeathState : AbstractGameState
        {
            SpriteBatch spriteBatch;

            Vector2 m_backgroundPosition;
            Vector2 m_playButtonPosition;
            Vector2 m_quitButtontPosition;
            Texture2D m_backgroundImage;
            Texture2D m_playAgainButtonImage;
            Texture2D m_rageQuitButtonImage;

            Button m_playAgainButton;
            Button m_rageQuitButton;

            MouseState m_mouse;

            private Song m_deathMusic;


            public DeathState(Game1 p_game)
                : base(p_game)
            {
                LoadContent();
            }


            public override void LoadContent()
            {
                // New spriteBatch
                spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

                // Loads the image than positions buttons and set there active field
                m_backgroundImage = m_game.Content.Load<Texture2D>("deathScreen");
                m_playAgainButtonImage = m_game.Content.Load<Texture2D>("buttonPlayAgain");
                m_rageQuitButtonImage = m_game.Content.Load<Texture2D>("buttonRageQuit");

                // Positions
                m_backgroundPosition = new Vector2(0, 0);

                m_playButtonPosition = new Vector2(m_game.GraphicsDevice.Viewport.Width *3 / 5 - m_playAgainButtonImage.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 7 / 15 - m_playAgainButtonImage.Height / 2);

                m_quitButtontPosition = new Vector2(m_game.GraphicsDevice.Viewport.Width *3 / 5 - m_rageQuitButtonImage.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 12 / 15 - m_rageQuitButtonImage.Height / 2);

                // Create Button
                m_playAgainButton = new Button(spriteBatch, m_playAgainButtonImage, m_playButtonPosition);
                m_rageQuitButton = new Button(spriteBatch, m_rageQuitButtonImage, m_quitButtontPosition);

                // Music load and starts
                m_deathMusic = m_game.Content.Load<Song>("deathMusic");
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(m_deathMusic);
            }

            public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

                m_playAgainButton.Draw();
                m_rageQuitButton.Draw();
                spriteBatch.Draw(m_backgroundImage, m_backgroundPosition, Color.White);

                spriteBatch.End();
                base.Draw(gameTime);
            }

            public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
            {

                m_mouse = Mouse.GetState();

                if (m_mouse.LeftButton == ButtonState.Released)
                {
                    if (m_playAgainButton.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new Level1State(m_game));
                        MediaPlayer.Stop();
                    }

                    if (m_rageQuitButton.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.Exit();
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
