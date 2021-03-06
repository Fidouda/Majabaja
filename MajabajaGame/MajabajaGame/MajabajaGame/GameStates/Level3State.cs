using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace MajabajaGame
{

    class Level3State : AbstractGameState
    {
        // Music
        private Song m_level1Music;
        SoundEffectInstance soundEngineInstance;
        SoundEffect magic;
        SoundEffect m_life;
        SoundEffect m_hurt;

        // Lifebar
        private LifeBar m_lifeBar;
        Texture2D m_liveHeart;
        Texture2D m_deadHeart;

        // Tiles
        SpriteBatch m_spriteBatch;
        TileMap level3Background;
        TileMap level3Decoration;
        TileMap level3Obstacle;
        int squaresAcross = 8;
        int squaresDown = 4;
        int DecoAcross = 16;
        int DecoDown = 8;
        int ObstAcross = 16;
        int ObstDown = 14;

        //Collision table
        Rectangle tilePos;
        Rectangle m_tileActionPos;
        int m_collisionAction = 0;

        int timeFromImpact = 0;
        int invincibleTime = 290;
        int timeFromHeart = 0;
        int HeartTime = 290;

        public Level3State(Game1 p_game)
            : base(p_game)
        {
            resetLevel();
            LoadContent();
        }

        public TileMap getObstacleMap()
        {
            return level3Obstacle;
        }

        public void resetLevel()
        {
            Camera.Location.Y = (16 * 128) - 480;
            Camera.Location.X = 0;
            Character.resetCharacter();
        }

        public override void LoadContent()
        {
            // Load Music
            m_level1Music = m_game.Content.Load<Song>("level1");
            MediaPlayer.Play(m_level1Music);

            //Load Sounds
            magic = m_game.Content.Load<SoundEffect>("spell2");
            m_life = m_game.Content.Load<SoundEffect>("Life");
            m_hurt = m_game.Content.Load<SoundEffect>("Hit_Hurt");
            
            // Load Player
            CharacterTile.TileSetTexture = m_game.Content.Load<Texture2D>("character");

            // Load Tiles
            using (var stream = TitleContainer.OpenStream("level3.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    int length = Convert.ToInt16(reader.ReadLine());
                    int height = Convert.ToInt16(reader.ReadLine());

                    level3Background = new TileMap(length, height);

                    while (!reader.EndOfStream)
                    {          
                        for (int i = 0; i < height; ++i)
                        {
                            string buffer = Convert.ToString((reader.ReadLine()));
                            for (int j = 0; j < length; ++j)
                            {
                                level3Background.Rows[i].Columns[j].TileID = Convert.ToInt16(buffer[j])-48;
                            }
                        }

                    }
                    reader.Dispose();
                }
            }

            using (var stream = TitleContainer.OpenStream("level3decoration.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    int length = Convert.ToInt16(reader.ReadLine());
                    int height = Convert.ToInt16(reader.ReadLine());

                    level3Decoration = new TileMap(length, height);

                    while (!reader.EndOfStream)
                    {
                        for (int i = 0; i < height; ++i)
                        {
                            string buffer = Convert.ToString((reader.ReadLine()));
                            for (int j = 0; j < length; ++j)
                            {
                                level3Decoration.Rows[i].Columns[j].TileID = Convert.ToInt16(buffer[j]);
                            }
                        }

                    }
                    reader.Dispose();
                }
            }

            using (var stream = TitleContainer.OpenStream("level3obstacle.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    int length = Convert.ToInt16(reader.ReadLine());
                    int height = Convert.ToInt16(reader.ReadLine());

                    level3Obstacle = new TileMap(length, height);

                    while (!reader.EndOfStream)
                    {
                        for (int i = 0; i < height; ++i)
                        {
                            string buffer = Convert.ToString((reader.ReadLine()));
                            for (int j = 0; j < length; ++j)
                            {
                                level3Obstacle.Rows[i].Columns[j].TileID = Convert.ToInt16(buffer[j]);
                            }
                        }

                    }
                    reader.Dispose();
                }
            }

            Character.levelObstacle = level3Obstacle;

            m_spriteBatch = new SpriteBatch(m_game.GraphicsDevice);

            m_liveHeart = m_game.Content.Load<Texture2D>("heart_full");
            m_deadHeart = m_game.Content.Load<Texture2D>("heart_empty");


            m_lifeBar = new LifeBar(/*Put player attribute here*/ 4, m_spriteBatch, m_liveHeart, m_deadHeart, m_life, m_hurt);

            BackgroundTile.BackgroundTileSetTexture = m_game.Content.Load<Texture2D>("TileSetBackground");
            DecorationTile.DecorationTileSetTexture = m_game.Content.Load<Texture2D>("DecorationTiles");
            ObstacleTile.ObstacleTileSetTexture = m_game.Content.Load<Texture2D>("ObstacleTiles");

            Camera.Location.Y = ((level3Background.MapHeight) * 128) - 480;
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //Background Tiles
            m_spriteBatch.Begin();
                Vector2 firstSquare = new Vector2(Camera.Location.X / 128, Camera.Location.Y / 128);
                int firstX = (int)firstSquare.X;
                int firstY = (int)firstSquare.Y;

                Vector2 squareOffset = new Vector2(Camera.Location.X % 128, Camera.Location.Y % 128);
                int offsetX = (int)squareOffset.X;
                int offsetY = (int)squareOffset.Y;

                for (int y = 0; y < squaresDown; y++)
                {
                    for (int x = 0; x < squaresAcross; x++)
                    {
                        m_spriteBatch.Draw(
                            BackgroundTile.BackgroundTileSetTexture,
                            new Rectangle((x * 128) - offsetX, (y * 128) - offsetY, 128, 128),
                            BackgroundTile.GetSourceRectangle(level3Background.Rows[y + firstY].Columns[x + firstX].TileID),
                            Color.White);
                    }
                }
            m_spriteBatch.End();

			
            //Decoration Tiles
            m_spriteBatch.Begin();
                Vector2 firstSquare1 = new Vector2(Camera.Location.X / 64, Camera.Location.Y / 64);
                int firstX1 = (int)firstSquare1.X;
                int firstY1 = (int)firstSquare1.Y;

                Vector2 squareOffset1 = new Vector2(Camera.Location.X % 64, Camera.Location.Y % 64);
                int offsetX1 = (int)squareOffset1.X;
                int offsetY1 = (int)squareOffset1.Y;

                int tempValue = 0;

                for (int y = 0; y < DecoDown; y++)
                {
                    for (int x = 0; x < DecoAcross; x++)
                    {

                        if (level3Decoration.Rows[y + firstY1].Columns[x + firstX1].TileID >= 48 && level3Decoration.Rows[y + firstY1].Columns[x + firstX1].TileID < 58)
                        {
                            tempValue = level3Decoration.Rows[y + firstY1].Columns[x + firstX1].TileID - 48;
                        }
                        else
                        {
                            tempValue = level3Decoration.Rows[y + firstY1].Columns[x + firstX1].TileID - 55;
                        }
                        

                        m_spriteBatch.Draw(
                            DecorationTile.DecorationTileSetTexture,
                            new Rectangle((x * 64) - offsetX1, (y * 64) - offsetY1, 64, 64),
                            DecorationTile.GetSourceRectangle(tempValue),
                            Color.White);
                    }
                }
            m_spriteBatch.End();


            //Obstacle Tiles

            //Reset of collision action
            m_collisionAction = 0;

            m_spriteBatch.Begin();
                Vector2 firstSquare2 = new Vector2(Camera.Location.X / 64, Camera.Location.Y / 64);
                int firstX2 = (int)firstSquare2.X;
                int firstY2 = (int)firstSquare2.Y;

                Vector2 squareOffset2 = new Vector2(Camera.Location.X % 64, Camera.Location.Y % 64);
                int offsetX2 = (int)squareOffset2.X;
                int offsetY2 = (int)squareOffset2.Y;

                int tempValue1 = 0;

                for (int y = 0; y < ObstDown; y++)
                {
                    for (int x = 0; x < ObstAcross; x++)
                    {

                        if (level3Obstacle.Rows[y + firstY2].Columns[x + firstX2].TileID >= 48 && level3Obstacle.Rows[y + firstY2].Columns[x + firstX2].TileID < 58)
                        {
                            tempValue1 = level3Obstacle.Rows[y + firstY2].Columns[x + firstX2].TileID - 48;
                        }
                        else
                        {
                            tempValue1 = level3Obstacle.Rows[y + firstY2].Columns[x + firstX2].TileID - 55;
                        }

                        tilePos = new Rectangle((x * 64) - offsetX2, (y * 64) - offsetY2, 64, 64);

                        m_spriteBatch.Draw(
                            ObstacleTile.ObstacleTileSetTexture,
                            tilePos,
                            ObstacleTile.GetSourceRectangle(tempValue1),
                            Color.White);

                        // If tile is an obstacle
                        if (tempValue1 != 0 && m_collisionAction == 0) 
                        {
                            if (tilePos.Intersects(Character.getRectangleCollision()))
                            {
                                m_collisionAction = tempValue1;
                                m_tileActionPos = tilePos;
                            }
                        }
                    }
                }
            m_spriteBatch.End();


            m_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                // LifeBar
                m_lifeBar.Draw();
                // Character
                m_spriteBatch.Draw(CharacterTile.TileSetTexture, Character.getRectangle(),
                CharacterTile.GetSourceRectangle(Character.characterMove(gameTime)), Color.White /* FLIP THAT SHIT OUT OF HIM , 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0*/);

            m_spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this.HandleInputTouch(gameTime);

            Character.camera = Camera.Location;
            Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 6, 0, (level3Background.MapWidth - squaresAcross) * 128);

            // Loops song
            if(MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(m_level1Music);
            }

            if (m_lifeBar.isEmpty())
            {
                m_game.setGameState(new DeathState(m_game));
            }
            
  
            switch (m_collisionAction)
            {
                case (int)obstacleTiles.NOTHING:
                    // DO NOTHING
                    break;

                case (int)obstacleTiles.INVISIBLEFLOORING:
                case (int)obstacleTiles.FLOORING:
                case (int)obstacleTiles.LEFTFLOOR:
                case (int)obstacleTiles.RIGHTFLOOR:
                    if(Character.isJumping() &&
                        Character.getRectangle().Y + Character.getCharacterSize() <= tilePos.Y)
                    {
                        Character.setPositionY(m_tileActionPos.Y - Character.getCharacterSize());
                    }
                    break;

                case (int)obstacleTiles.BARREL:
                case (int)obstacleTiles.CRATE:
                        timeFromImpact += gameTime.ElapsedGameTime.Milliseconds;
                        if (timeFromImpact > invincibleTime)
                        {
                            timeFromImpact = 0;
                            m_lifeBar.removeHeart();
                        }
                    break;

                case (int)obstacleTiles.HEART:
                    timeFromHeart += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeFromHeart > HeartTime)
                    {
                        timeFromHeart = 0;
                        m_lifeBar.addHeart();
                    }
                    break;

                case (int)obstacleTiles.SPIKE:
                case (int)obstacleTiles.TRAP:
                    m_game.setGameState(new DeathState(m_game));
                    break;

                case (int)obstacleTiles.WIN:
                    m_game.setGameState(new Level4State(m_game));
                    break;

                default:
                    //Nothing;
                    break;
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
                    
                    // on taps, we change the color of the selected sprite
                    //case GestureType.Tap:
                    case GestureType.DoubleTap:
                        {
                            soundEngineInstance = magic.CreateInstance();
                            soundEngineInstance.Play();
                        }
                        break;
/*
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
                    
                    // on drags, we just want to move the selected sprite with the drag
                    case GestureType.FreeDrag:
                        //if (spriteBatch != null)
                        {
                            //Camera.Location.X += gesture.Delta.X;
                            //spritePosition1.Y += gesture.Delta.Y;
                        }
                        break;
                    */
                    // on flicks, we want to update the selected sprite's velocity with
                    // the flick velocity, which is in pixels per second.
                    case GestureType.Flick:
                        {
                            if (gesture.Delta.Y < 0)
                            {
                                //Jump
                                Character.setJumping();
                            }
                            else
                            {
                                //Crouch
                                Character.setCrouching();
                            }
                        }
                        break;
/*
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
