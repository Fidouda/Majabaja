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
    class Level2State : AbstractGameState
    {
        // Objects to appear
        private LifeBar m_lifeBar;
        Texture2D m_liveHeart;
        Texture2D m_deadHeart;

        //private Rectangle background;
        //private Song m_level2Music;

        SpriteBatch m_spriteBatch;
        //TileMap level1 = new TileMap();
        int squaresAcross = 26;
        int squaresDown = 16;


        public Level2State(Game1 p_game)
            : base(p_game)
        {
            LoadContent();
        }

        public override void LoadContent()
        {
            //background.LoadContent();
            //aSquare.LoadContent();
            //m_level1Music = m_game.Content.Load<Song>("drumBeat");
            //MediaPlayer.Play(m_levelwMusic);

            // New SpriteBatch
            m_spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

            // Loads the image than positions buttons and set there active field
            // Load
            Tile.TileSetTexture = m_game.Content.Load<Texture2D>("part1_tileset");
            m_liveHeart = m_game.Content.Load<Texture2D>("heart_full");
            m_deadHeart = m_game.Content.Load<Texture2D>("heart_empty");

            // Making objects
            m_lifeBar = new LifeBar(/*Put player attribute here*/ 4, m_spriteBatch,
                m_liveHeart, m_deadHeart);
            

            // Music load and starts
            //m_level2Music = m_game.Content.Load<Song>("level2");
            //MediaPlayer.Play(m_backgroundMusic);

        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Draw tiles
            m_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
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
                    /*
                    m_spriteBatch.Draw(
                        Tile.TileSetTexture,
                        new Rectangle((x * 32) - offsetX, (y * 32) - offsetY, 32, 32),
                        Tile.GetSourceRectangle(level1.Rows[y + firstY].Columns[x + firstX].TileID),
                        Color.White);
                     * */
                }
            }

            m_spriteBatch.End();

            // Draw objects
            m_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            m_lifeBar.Draw();
            m_spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this.HandleInputTouch(gameTime);

            //Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0, (level1.MapWidth - squaresAcross) * 32);
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
