using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace PongGame.Source
{
    public class Paddle
    {
        private Game1 _game = null;
        private Texture2D _texture;
        private Vector2 _position;
        private int _verticalSpeed;
        Input _input = null;
        public Rectangle PaddleRect { get => new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);  }

        public Paddle(Texture2D texture, Vector2 position, Input input, Game1 game1)
        {
            _game = game1;
            _texture = texture;
            _position = position;
            _verticalSpeed = 5;
            _input = input;
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(_input.Up))
            {
                _position.Y -= _verticalSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(_input.Down))
            {
                _position.Y += _verticalSpeed;
            }
            _position.Y = MathHelper.Clamp(_position.Y, 0, 540 - _texture.Height);
            CheckBallCollision();

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height), Color.White);
        }
        public void CheckBallCollision()
        {
            Ball ball = _game.GameScene.ball;
            if (ball.BallRect.Intersects(PaddleRect))
            {
                ball.SpeedUp();
            }
        }
        public void Reset(Vector2 basePos)
        {
            _position = basePos;
        }
    }
}
