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
        Vector2 m_playButtonPosition;
        Vector2 m_quitButtontPosition;
        Texture2D m_background;
        Texture2D m_playButtonImage;
        Texture2D m_quitButtonImage;

        Button m_playButton;
        Button m_quitButton;

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
            m_playButtonImage = m_game.Content.Load<Texture2D>("buttonPlay");
            m_quitButtonImage = m_game.Content.Load<Texture2D>("buttonQuit"); // change value here

            // Positions
            m_backgroundPosition = new Vector2(0,0);

            m_playButtonPosition = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_playButtonImage.Width / 2,
                m_game.GraphicsDevice.Viewport.Height / 3 - m_playButtonImage.Height / 2);

            m_quitButtontPosition = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_quitButtonImage.Width / 2,
                m_game.GraphicsDevice.Viewport.Height * 2 / 3 - m_quitButtonImage.Height / 2);
            
            // Create Button
            m_playButton = new Button(spriteBatch, m_playButtonImage, m_playButtonPosition);
            m_quitButton = new Button(spriteBatch, m_quitButtonImage, m_quitButtontPosition);

            // Music load and starts
            m_backgroundMusic = m_game.Content.Load<Song>("mainBackground");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(m_backgroundMusic);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            m_playButton.Draw();
            m_quitButton.Draw();
            spriteBatch.Draw(m_background, m_backgroundPosition, Color.White);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            m_mouse = Mouse.GetState();

            if (m_mouse.LeftButton == ButtonState.Released)
            {
                if (m_playButton.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                {
                    m_game.setGameState(new Level1State(m_game));
                    MediaPlayer.Stop();
                }

                if (m_quitButton.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
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
