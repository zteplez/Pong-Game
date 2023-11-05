using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Label
{
    private SpriteFont _font;
    private string _text;
    private Vector2 _position;
    private Color _color;
    public string Text { get => _text; set => _text = value; }

    public Label(SpriteFont font, string text, Vector2 position, Color color)
    {
        _font = font;
        _text = text;
        _position = position;
        _color = color;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(_font, _text, _position, _color);
    }

}
