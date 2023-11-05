using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using PongGame.Source;
using PongGame.Source.Controls;

namespace PongGame.Source.Scenes
{
    public class MainMenu : Scene
    {
        private Color _backgroundColor;
        private List<Button> _buttons;

        public MainMenu(Game1 game1) : base(game1)
        {
            _game = game1;
        }
        public override void LoadContent(ContentManager content)
        {
            Texture2D buttonTexture = content.Load<Texture2D>("sprites/button");
            _buttons = new List<Button>() { new Button(buttonTexture, new Vector2(_game.GraphicsDevice.Viewport.Width / 2 - buttonTexture.Width, 150), "Play", Color.White, _game.Font),
                new Button(buttonTexture, new Vector2(_game.GraphicsDevice.Viewport.Width / 2 - buttonTexture.Width, 200), "Quit", Color.White, _game.Font) };
            _backgroundColor = Color.Yellow;

            _buttons[0].OnClick += PlayButton_Click;
            _buttons[1].OnClick += ExitButton_Click;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in _buttons.ToArray())
            {
                button.Update(gameTime);
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _game.GraphicsDevice.Clear(_backgroundColor);

            foreach (Button button in _buttons)
            {
                button.Draw(spriteBatch);
            }
        }
        public override void UnloadContent()
        {
            _buttons.Clear();
        }
        private void PlayButton_Click()
        {
            _game.ChangeScene(_game.GameScene);
        }
        private void ExitButton_Click()
        {
            _game.Exit();
        }

    }
}
