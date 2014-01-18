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
    class MainMenuState : AbstractGameState
    {
        SpriteBatch spriteBatch;
        Vector2 m_backgroundPosition;
        Vector2 m_buttonPlayPosition;
        Vector2 m_buttonQuitPosition;
        Texture2D m_background;
        Texture2D m_playButton;
        Texture2D m_quitButton;

        Rectangle m_playButtonField;
        Rectangle m_quitButtonField;

        MouseState m_mouse;
        
        private Song m_backgroundMusic;


        public MainMenuState(Game1 p_game)
            : base(p_game)
        {
            LoadContent();
        }


        public override void LoadContent()
        {
            // New spriteBatch
            spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

            // Loads the image than positions buttons and set there active field
            // Load
            m_background = m_game.Content.Load<Texture2D>("background");
            m_playButton = m_game.Content.Load<Texture2D>("buttonPlay");
            m_quitButton = m_game.Content.Load<Texture2D>("buttonQuit"); // change value here

            // Positions
            m_backgroundPosition = new Vector2(0,0);

            m_buttonPlayPosition = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_playButton.Width / 2,
                m_game.GraphicsDevice.Viewport.Height / 3 - m_playButton.Height / 2);

            m_buttonQuitPosition = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_playButton.Width / 2,
                m_game.GraphicsDevice.Viewport.Height * 2 / 3 - m_playButton.Height / 2);
            
            // Fields
            m_playButtonField = new Rectangle((int)m_buttonPlayPosition.X, (int)m_buttonPlayPosition.Y, (int)m_playButton.Width, (int)m_playButton.Height);
            m_quitButtonField = new Rectangle((int)m_buttonQuitPosition.X, (int)m_buttonQuitPosition.Y, (int)m_quitButton.Width, (int)m_quitButton.Height);
           
            // Music load and starts
            m_backgroundMusic = m_game.Content.Load<Song>("mainBackground");
            MediaPlayer.Play(m_backgroundMusic);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            
            spriteBatch.Draw(m_playButton, m_buttonPlayPosition, Color.White);
            spriteBatch.Draw(m_quitButton, m_buttonQuitPosition, Color.White);
            spriteBatch.Draw(m_background, m_backgroundPosition, Color.White);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            m_mouse = Mouse.GetState();

            if (m_mouse.LeftButton == ButtonState.Released)
            {
                if (m_playButtonField.Contains(new Point(m_mouse.X, m_mouse.Y)))
                {
                    m_game.setGameState(new Level2State(m_game));
                    MediaPlayer.Stop();
                }

                if (m_quitButtonField.Contains(new Point(m_mouse.X, m_mouse.Y)))
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
