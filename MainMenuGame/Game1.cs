using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Drawing.Printing;

namespace MainMenuGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D plant;
        private MouthGuy mouthGuy;
        private SpriteFont font;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mouthGuy = new MouthGuy() { Position = new Vector2(_graphics.GraphicsDevice.Viewport.Width /2 , _graphics.GraphicsDevice.Viewport.Height / 2) };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            mouthGuy.LoadContent(Content);
            plant = Content.Load<Texture2D>("Bush");
            font = Content.Load<SpriteFont>("File");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (mouthGuy.exit)
                Exit();

            // TODO: Add your update logic here
            mouthGuy.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SandyBrown);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            _spriteBatch.Draw(plant, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(plant, new Vector2(210, 300), Color.White);
            _spriteBatch.Draw(plant, new Vector2(400, 40), Color.White);
            _spriteBatch.Draw(plant, new Vector2(500, 400), Color.White);
            _spriteBatch.Draw(plant, new Vector2(60, 450), Color.White);
            _spriteBatch.DrawString(font, "Hold Space to Exit Game", new Vector2(250, 100), Color.Black);
            mouthGuy.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}