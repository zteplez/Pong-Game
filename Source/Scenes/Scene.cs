using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PongGame.Source;

namespace PongGame.Source.Scenes
{
    public abstract class Scene
    {
        protected Game1 _game = null;
        public Scene(Game1 game1)
        {
            _game = game1;
        }
        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void UnloadContent();

    }
}
