using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace MajabajaGame
{
    /// <summary>
    /// Type principal pour votre jeu
    /// </summary>
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState currentKeyboardState, oldKeyboardState;
        AbstractGameState currentState;
        Texture2D test;

        public SpriteBatch getSpriteBatch()
        {
            return spriteBatch;
        }

        public KeyboardState getCurrentKeyboardState()
        {
            return currentKeyboardState;
        }

        public void setGameState(AbstractGameState p_newState)
        {
            currentState = p_newState;
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            TouchPanel.EnabledGestures =
                GestureType.Hold |
                GestureType.Tap |
                GestureType.DoubleTap |
                GestureType.FreeDrag |
                GestureType.Flick |
                GestureType.Pinch;

            currentKeyboardState = new KeyboardState();
            currentState = new MainMenuState(this);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            test = Content.Load<Texture2D>("phoneGameThumb");
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (currentKeyboardState.IsKeyDown(Keys.Escape) && oldKeyboardState.IsKeyUp(Keys.Escape))
                this.Exit();

            currentState.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            currentState.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
