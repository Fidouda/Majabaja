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
        Vector2 spritePosition1;
        Texture2D texture1;
        int sprite1Height;
        int sprite1Width;
        //private Song m_backgroundMusic;

        public MainMenuState(Game1 p_game)
            : base(p_game)
        {
            //m_instructions = new Rectangle(p_game, "PhoneGameThumb");
            LoadContent();
        }

        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

            texture1 = m_game.Content.Load<Texture2D>("PhoneGameThumb");

            spritePosition1.X = 0;
            spritePosition1.Y = 0;

            sprite1Height = texture1.Bounds.Height;
            sprite1Width = texture1.Bounds.Width;

            //m_instructions.setPosition(m_game.GraphicsDevice.Viewport.Width / 2 - m_instructions.getWidth() / 2,
            //    m_game.GraphicsDevice.Viewport.Height / 2 - m_instructions.getHeight() / 2);
            //m_backgroundMusic = m_game.Content.Load<Song>("accept");
            //MediaPlayer.Play(m_backgroundMusic);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Opaque);
            spriteBatch.Draw(texture1, spritePosition1, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            this.HandleInputTouch(gameTime);

            if (m_game.getCurrentKeyboardState().IsKeyDown(Keys.NumPad1))
            {
                m_game.setGameState(new Level1State(m_game));
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
                        if (spriteBatch != null)
                        {
                            spritePosition1.X += gesture.Delta.X;
                            spritePosition1.Y += gesture.Delta.Y;
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
