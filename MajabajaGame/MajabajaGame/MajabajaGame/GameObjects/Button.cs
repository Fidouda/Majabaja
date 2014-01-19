using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Button
{
    Texture2D m_image;
    Rectangle m_field;
    Vector2 m_position;
    SpriteBatch m_spriteBatch;

    public Button(SpriteBatch p_spriteBatch, Texture2D p_image, Vector2 p_position )
    {
        m_spriteBatch = p_spriteBatch;
        m_image = p_image;
        m_position = p_position;
        m_field = new Rectangle((int)m_position.X, (int)m_position.Y, (int)m_image.Width, (int)m_image.Height);
    }


    public Rectangle getField()
    {
        return m_field;
    }


    public void Draw()
    {
        m_spriteBatch.Draw(m_image, m_position, Color.White);
    }
}
