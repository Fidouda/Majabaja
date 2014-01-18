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
    class PauseState : AbstractGameState
    {
        SpriteBatch spriteBatch;
        Vector2 m_buttonResumePosition;
        Texture2D m_resumeButton;
        Rectangle m_resumeButtonField;
        MouseState m_mouse;



        public PauseState(Game1 p_game)
            : base(p_game)
        {
            LoadContent();
        }


        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

            // Loads the image than positions buttons and set there active field
            // Load
            m_resumeButton = m_game.Content.Load<Texture2D>("buttonResume");

            // Positions

            m_buttonResumePosition = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_resumeButton.Width / 2,
                m_game.GraphicsDevice.Viewport.Height / 2 - m_resumeButton.Height / 2);

            // Fields
            m_resumeButtonField = new Rectangle((int)m_buttonResumePosition.X, (int)m_buttonResumePosition.Y, (int)m_resumeButton.Width, (int)m_resumeButton.Height);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(m_resumeButton, m_buttonResumePosition, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            m_mouse = Mouse.GetState();

            if (m_mouse.LeftButton == ButtonState.Released)
            {
                if (m_resumeButtonField.Contains(new Point(m_mouse.X, m_mouse.Y)))
                {
                    m_game.setGameState(new Level1State(m_game));
                }
            }

            MediaPlayer.Volume = 0.10f;

            this.HandleInputTouch(gameTime);

            base.Update(gameTime);
        }

        public override void HandleInputTouch(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }
    }
}
