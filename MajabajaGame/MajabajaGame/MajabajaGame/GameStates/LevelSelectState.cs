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
    class LevelSelectState :AbstractGameState
    {
            SpriteBatch spriteBatch;

            Vector2 m_backgroundPosition;
            Vector2 m_level1Position;
            Vector2 m_level2Position;
            Vector2 m_level3Position;
            Vector2 m_level4Position;
            Vector2 m_level5Position;
            Vector2 m_level6Position;

            Texture2D m_backgroundImage;
            Texture2D m_level1Image;
            Texture2D m_level2Image;
            Texture2D m_level3Image;
            Texture2D m_level4Image;
            Texture2D m_level5Image;
            Texture2D m_level6Image;

            Button m_level1Button;
            Button m_level2Button;
            Button m_level3Button;
            Button m_level4Button;
            Button m_level5Button;
            Button m_level6Button;

            MouseState m_mouse;

            private Song m_selectMusic;


            public LevelSelectState(Game1 p_game)
                : base(p_game)
            {
                LoadContent();
            }


            public override void LoadContent()
            {
                // New spriteBatch
                spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

                // Loads the image than positions buttons and set there active field
                m_backgroundImage = m_game.Content.Load<Texture2D>("levelSelectBackground");
                m_level1Image = m_game.Content.Load<Texture2D>("level1ImageSelect");
                m_level2Image = m_game.Content.Load<Texture2D>("level2ImageSelect");
                m_level3Image = m_game.Content.Load<Texture2D>("level3ImageSelect");
                m_level4Image = m_game.Content.Load<Texture2D>("level4ImageSelect");
                m_level5Image = m_game.Content.Load<Texture2D>("level5ImageSelect");
                m_level6Image = m_game.Content.Load<Texture2D>("level6ImageSelect");

                // Positions
                m_backgroundPosition = new Vector2(0, 0);

                m_level1Position = new Vector2(m_game.GraphicsDevice.Viewport.Width / 4 - m_level1Image.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 7 / 15 - m_level1Image.Height / 2);

                m_level2Position = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_level2Image.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 7 / 15 - m_level2Image.Height / 2);

                m_level3Position = new Vector2(m_game.GraphicsDevice.Viewport.Width * 3 / 4 - m_level3Image.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 7 / 15 - m_level3Image.Height / 2);

                m_level4Position = new Vector2(m_game.GraphicsDevice.Viewport.Width / 4 - m_level4Image.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 11 / 15 - m_level4Image.Height / 2);

                m_level5Position = new Vector2(m_game.GraphicsDevice.Viewport.Width / 2 - m_level5Image.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 11 / 15 - m_level5Image.Height / 2);

                m_level6Position = new Vector2(m_game.GraphicsDevice.Viewport.Width * 3 / 4 - m_level6Image.Width / 2,
                    m_game.GraphicsDevice.Viewport.Height * 11 / 15 - m_level6Image.Height / 2);


                // Create Button
                m_level1Button = new Button(spriteBatch, m_level1Image, m_level1Position);
                m_level2Button = new Button(spriteBatch, m_level2Image, m_level2Position);
                m_level3Button = new Button(spriteBatch, m_level3Image, m_level3Position);
                m_level4Button = new Button(spriteBatch, m_level4Image, m_level4Position);
                m_level5Button = new Button(spriteBatch, m_level5Image, m_level5Position);
                m_level6Button = new Button(spriteBatch, m_level6Image, m_level6Position);

                // Music load and starts
                m_selectMusic = m_game.Content.Load<Song>("levelSelectScreen");
            }

            public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
            {

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(m_backgroundImage, m_backgroundPosition, Color.White);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                m_level1Button.Draw();
                m_level2Button.Draw();
                m_level3Button.Draw();
                m_level4Button.Draw();
                m_level5Button.Draw();
                m_level6Button.Draw();
                spriteBatch.End();

                base.Draw(gameTime);
            }

            public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(m_selectMusic);
                }

                m_mouse = Mouse.GetState();

                if (m_mouse.LeftButton == ButtonState.Released)
                {
                    if (m_level1Button.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new IntroScreenState(m_game));
                        MediaPlayer.Stop();    
                    }

                    if (m_level2Button.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new Level2State(m_game));
                        MediaPlayer.Stop();
                    }

                    if (m_level3Button.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new Level1State(m_game));
                        MediaPlayer.Stop();
                    }

                    if (m_level4Button.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new Level1State(m_game));
                        MediaPlayer.Stop();
                    }

                    if (m_level5Button.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new Level1State(m_game));
                        MediaPlayer.Stop();
                    }

                    if (m_level6Button.getField().Contains(new Point(m_mouse.X, m_mouse.Y)))
                    {
                        m_game.setGameState(new Level1State(m_game));
                        MediaPlayer.Stop();
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
