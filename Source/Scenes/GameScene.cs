using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace PongGame.Source.Scenes
{
    public class GameScene : Scene
    {
        private Texture2D _backgroundImage = null;
        public Paddle paddleRight = null;
        public Paddle paddleLeft = null;
        public Ball ball = null;
        public Score score = null;
        public bool GameOver;

        public GameScene(Game1 game1) : base(game1)
        {
            _game = game1;
        }
        public override void LoadContent(ContentManager content)
        {
            GameOver = false;
            _backgroundImage = content.Load<Texture2D>("sprites/Board");
            paddleRight = new Paddle(content.Load<Texture2D>("sprites/Player"), new Vector2(960 - 30, 270 - 60), new Input() { Down = Keys.Down, Up = Keys.Up }, _game);
            paddleLeft = new Paddle(content.Load<Texture2D>("sprites/Computer"), new Vector2(15, 270 - 60), new Input() { Down = Keys.S, Up = Keys.W }, _game);
            ball = new Ball(content.Load<Texture2D>("sprites/Ball"), _game);
            score = new Score(content.Load<Texture2D>("sprites/ScoreBar"), _game);
        }

        public override void Update(GameTime gameTime)
        {
            if (!GameOver)
            {
                if (!ball.BallOut)
                {
                    paddleRight.Update();
                    ball.Update();
                    paddleLeft.Update();
                }

                else
                {
                    ball.Reset();
                    paddleLeft.Reset(new Vector2(15, 270 - 60));
                    paddleRight.Reset(new Vector2(960 - 30, 270 - 60));

                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        ball.BallOut = false;
                    }
                }
            }
            else
            {
                _game.ChangeScene(_game.MainMenuScene);
            }
            

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _game.GraphicsDevice.Clear(Color.White);

            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height), Color.White);
            score.Draw(spriteBatch);
            paddleRight.Draw(spriteBatch);
            paddleLeft.Draw(spriteBatch);
            ball.Draw(spriteBatch);

        }
        public override void UnloadContent()
        {
            _backgroundImage.Dispose();
            paddleRight = null;
            paddleLeft = null;
            ball = null;
            score = null;
        }

    }
}
