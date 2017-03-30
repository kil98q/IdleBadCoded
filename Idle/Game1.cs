using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Idle
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Game game;
        public delegate void UpdateEventHandler(object source, EventArgs args);
        public event UpdateEventHandler UpdateObjects;
        Grid2D Grid;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            Grid = new Grid2D(10, 10);
            foreach(GameObject obj in Grid.GetNearby(new Vector2(0, 0)))
            {
                Console.Write(Grid.GetObjectCords(obj));
            }
            game = this;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            OnUpdate();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
        protected virtual void OnUpdate()
        {
            if (UpdateObjects != null)
                UpdateObjects(this, EventArgs.Empty);
        }
    }
}
