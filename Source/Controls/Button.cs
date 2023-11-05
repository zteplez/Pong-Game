using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;


namespace PongGame.Source.Controls
{
    public class Button
    {
        #region Fields

        Texture2D _texture;
        Rectangle _rect;
        string _text;
        Color _color;
        SpriteFont _font;
        bool _isHovering;
        bool _isPressed;
        MouseState _currentMouse;
        MouseState _previousMouse;

        #endregion
        #region Properties
        public bool IsPressed { get => _isPressed; }
        public event Action OnClick;

        #endregion

        public Button(Texture2D texture, Vector2 position, string text, Color color, SpriteFont font)
        {
            Debug.WriteLine("Button initialized.");
            _texture = texture;
            _rect.Width = texture.Width * 2;
            _rect.Height = texture.Height * 2;
            _rect.X = (int)position.X;
            _rect.Y = (int)position.Y;
            _text = text;
            _color = color;
            _font = font;
            _isHovering = false;
        }

        public void Update(GameTime gameTime)
        {

            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
            _isPressed = false;

            if (_rect.Intersects(mouseRect))
            {
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    OnClick?.Invoke();
                    _isPressed = true;

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isHovering) _color = Color.Red;
            else _color = Color.White;

            spriteBatch.Draw(_texture, _rect, _color);
            Vector2 textMiddlePoint = _font.MeasureString(_text) / 2;
            spriteBatch.DrawString(_font, _text, new Vector2(_rect.X + _rect.Width / 2 - textMiddlePoint.X, _rect.Y + _rect.Height / 2 - textMiddlePoint.Y), Color.White);
        }

    }
}
