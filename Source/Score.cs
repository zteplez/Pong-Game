using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PongGame.Source.Scenes;
using System.Diagnostics;
using System.Reflection.Emit;

namespace PongGame.Source
{
    public class Score
    {
        private Game1 _game;
        private Texture2D _scoreTexture;
        private Label _leftLabel;
        private Label _rightLabel;
        private int _leftScore;
        private int _rightScore;

        public Score(Texture2D scoreTexture, Game1 gameRef) {
            _game = gameRef;
            _scoreTexture = scoreTexture;
            _leftScore = 0;
            _rightScore = 0;
            _leftLabel = new Label(_game.Font, "0", new Vector2(960 / 2 - 140 , 10), Color.White);
            _rightLabel = new Label(_game.Font, "0", new Vector2(960 / 2 + 140, 10), Color.White);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_scoreTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(1.40f, 1f), SpriteEffects.None, 0f); 
            spriteBatch.Draw(_scoreTexture, new Vector2(480, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(1.55f, 1f), SpriteEffects.FlipHorizontally, 0f);

            _leftLabel.Draw(spriteBatch);
            _rightLabel.Draw(spriteBatch);
        }
        public void AddOne(char whichLabel)
        {
            Debug.WriteLine("This func called.");
            if(whichLabel == 'L')
            {
                _rightScore = int.Parse(_leftLabel.Text);
                _rightScore++;
                _leftLabel.Text = _rightScore.ToString();
            }
            else if(whichLabel == 'R')
            {
                _leftScore = int.Parse(_rightLabel.Text);
                _leftScore++;
                _rightLabel.Text = _leftScore.ToString();
            }
            CheckGameIsOver();
        }
        public void CheckGameIsOver()
        {
            if(_rightScore >= 5 || _leftScore >= 5)
            {
                _game.GameScene.GameOver = true;
            }
        }

    }
}
