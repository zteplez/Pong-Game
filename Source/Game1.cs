using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGame.Source.Scenes;

namespace PongGame.Source
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SpriteFont Font = null;
       
        private Scene _currentScene;
        public MainMenu MainMenuScene;
        public GameScene GameScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 540;
            _graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "Pong Game";
            MainMenuScene = new MainMenu(this);
            GameScene = new GameScene(this);
            _currentScene = MainMenuScene;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("DefaultFont");
            _currentScene.LoadContent(Content);
        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _currentScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Pink);

            _spriteBatch.Begin();

            _currentScene.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ChangeScene(Scene newScene)
        {
            _currentScene.UnloadContent();
            _currentScene = newScene;
            _currentScene.LoadContent(Content);
        }
    }
}