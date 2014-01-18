using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public enum ButtonStatus {Normal, Highlighted, Clicked}

public class Button
{
    Texture2D image;
    SpriteFont font;
    Rectangle location;
    string text;
    Vector2 textLocation;
    SpriteBatch spriteBatch;
    MouseState mouse;
    MouseState oldMouse;
    bool clicked = false;
    string clickText = "Button was Clicked!";
    public event EventHandler Clicked;

    public Button(Texture2D texture, SpriteFont font, SpriteBatch sBatch)
    {
        image = texture;
        this.font = font;
        location = new Rectangle(0, 0, image.Width, image.Height);
        spriteBatch = sBatch;
    }

    public string Text
    {
        get { return text; }
        set
        {
            text = value;
            Vector2 size = font.MeasureString(text);
            textLocation = new Vector2();
            textLocation.Y = location.Y + ((image.Height / 2) - (size.Y / 2));
            textLocation.X = location.X + ((image.Width / 2) - (size.X / 2));
        }
    }

    public void Location(int x, int y)
    {
        location.X = x;
        location.Y = y;
    }
    

    /// <summary>
    /// Allows the game component to update itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public void Update()
    {
        mouse = Mouse.GetState();

        if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                clicked = true;
            }
        }

        Text = "Play";
        oldMouse = mouse;
    }


    public void Draw()
    {

        if (location.Contains(new Point(mouse.X, mouse.Y)))
        {
            spriteBatch.Draw(image,
                location,
                Color.Silver);
        }
        else
        {
            spriteBatch.Draw(image,
                location,
                Color.White);
        }

        spriteBatch.DrawString(font,
            text,
            textLocation,
            Color.Black);

        if (clicked)
        {
            Vector2 position = new Vector2(10, 75);
            spriteBatch.DrawString(font,
                clickText,
                position,
                Color.White);
        }
    }

}
