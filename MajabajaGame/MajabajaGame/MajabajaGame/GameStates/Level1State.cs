using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajabajaGame
{
    class Level1State : AbstractGameState
    {
        //private Square aSquare;
        //private Rectangle background;
        //private Song m_level1Music;

        SpriteBatch spriteBatch;
        TileMap level1 = new TileMap();
        int squaresAcross = 26;
        int squaresDown = 16;


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

            spriteBatch = new SpriteBatch(m_game.GraphicsDevice);
            Tile.TileSetTexture = m_game.Content.Load<Texture2D>("part1_tileset");
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //aSquare.Draw(gameTime);
            //background.Draw(gameTime);

            spriteBatch.Begin();

            Vector2 firstSquare = new Vector2(Camera.Location.X / 32, Camera.Location.Y / 32);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % 32, Camera.Location.Y % 32);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    spriteBatch.Draw(
                        Tile.TileSetTexture,
                        new Rectangle((x * 32) - offsetX, (y * 32) - offsetY, 32, 32),
                        Tile.GetSourceRectangle(level1.Rows[y + firstY].Columns[x + firstX].TileID),
                        Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this.HandleInputTouch(gameTime);

            Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0, (level1.MapWidth - squaresAcross) * 32);

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

        public override void HandleInputTouch(Microsoft.Xna.Framework.GameTime gameTime)
        {
            TouchCollection touches = TouchPanel.GetState();

            while (TouchPanel.IsGestureAvailable)
            {
                // read the next gesture from the queue
                GestureSample gesture = TouchPanel.ReadGesture();

                // we can use the type of gesture to determine our behavior
                switch (gesture.GestureType)
                {
                    /*
                    // on taps, we change the color of the selected sprite
                    case GestureType.Tap:
                    case GestureType.DoubleTap:
                        if (selectedSprite != null)
                        {
                            selectedSprite.ChangeColor();
                        }
                        break;

                    // on holds, if no sprite is selected, we add a new sprite at the
                    // hold position and make it our selected sprite. otherwise we
                    // remove our selected sprite.
                    case GestureType.Hold:
                        if (selectedSprite == null)
                        {
                            // create the new sprite
                            selectedSprite = new Sprite(cat);
                            selectedSprite.Center = gesture.Position;

                            // add it to our list
                            sprites.Add(selectedSprite);
                        }
                        else
                        {
                            sprites.Remove(selectedSprite);
                            selectedSprite = null;
                        }
                        break;
                    */
                    // on drags, we just want to move the selected sprite with the drag
                    case GestureType.FreeDrag:
                        //if (spriteBatch != null)
                        {
                            //Camera.Location.X += gesture.Delta.X;
                            //spritePosition1.Y += gesture.Delta.Y;
                        }
                        break;
                    /*
                    // on flicks, we want to update the selected sprite's velocity with
                    // the flick velocity, which is in pixels per second.
                    case GestureType.Flick:
                        if (selectedSprite != null)
                        {
                            selectedSprite.Velocity = gesture.Delta;
                        }
                        break;

                    // on pinches, we want to scale the selected sprite
                    case GestureType.Pinch:
                        if (selectedSprite != null)
                        {
                            // get the current and previous locations of the two fingers
                            Vector2 a = gesture.Position;
                            Vector2 aOld = gesture.Position - gesture.Delta;
                            Vector2 b = gesture.Position2;
                            Vector2 bOld = gesture.Position2 - gesture.Delta2;

                            // figure out the distance between the current and previous locations
                            float d = Vector2.Distance(a, b);
                            float dOld = Vector2.Distance(aOld, bOld);

                            // calculate the difference between the two and use that to alter the scale
                            float scaleChange = (d - dOld) * .01f;
                            selectedSprite.Scale += scaleChange;
                        }
                        break;
                     */
                }
            }
        }
    }
}
