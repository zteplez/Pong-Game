using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace PongGame.Source
{
    public class Ball
    {
        private Game1 _game;
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;
        private float _baseSpeed = 3f;
        public Vector2 Velocity { get=>_velocity; set=> _velocity = value; }
        public Rectangle BallRect{get =>new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);}
        public bool BallOut = true;

        public Ball(Texture2D texture, Game1 game)
        {
            _game = game;   
            _texture = texture;
            _position = new Vector2(960 / 2 - _texture.Width / 2, 540 / 2 - _texture.Height / 2);
            _velocity = GenerateRandomVelocity();
        }
        public void Update()
        {
            if (!BallOut)
            {
                Debug.WriteLine(Velocity);
                _position += _velocity;

                if (_position.Y < 0 || _position.Y + _texture.Height > 540)
                {
                    _velocity.Y *= -1.02f;
                }
                CheckGameBounds();
            }
            else
            {
                Reset();
            }  
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height), Color.White); 
        }

        private Vector2 GenerateRandomVelocity()
        {
            Random random = new Random();

            float randomX = (random.Next(2) == 0) ? -1 : 1;
            float randomY = (random.Next(2) == 0) ? -1 : 1;

            return new Vector2(randomX * _baseSpeed, randomY * _baseSpeed);
        }
        public void Reset()
        {
            _position = new Vector2(960 / 2 - _texture.Width / 2, 540 / 2 - _texture.Height / 2);
            _velocity = GenerateRandomVelocity();
        }
        private void CheckGameBounds()
        {
            if (_position.X < 0 || _position.X + _texture.Width > 960)
            {
                if (_position.X < 0)
                {
                    _game.GameScene.score.AddOne('R'); //R means left paddle in score script

                }
                else if (_position.X + _texture.Width > 960)
                {
                    _game.GameScene.score.AddOne('L'); //L means left paddle in score script

                }
                BallOut = true;
            }
        }
        public void SpeedUp()
        {
            Velocity = new Vector2(Velocity.X * -1.1f, Velocity.Y);
        }
    }
}
