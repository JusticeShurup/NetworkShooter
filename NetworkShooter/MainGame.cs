using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NetworkShooter.Animations;
using NetworkShooter.GameObjects;
using NetworkShooter.MapEntities;
using NetworkShooter.States;
using NetworkShooter.States.Base;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkShooter
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameState _state;

        public int Score = 0;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        public void ChangeState(GameState newGameState)
        {
            _state = newGameState;
            _state.Initialize();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.ApplyChanges();
            

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _state = new MenuState(this, _spriteBatch);

            _state.Initialize();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _state.Update(gameTime);
            
            base.Update(gameTime);
        }

        public void AddBullet(Bullet bullet)
        {
            _state.AddBullet(bullet);
        }

        public void RemoveBullet(Bullet bullet)
        {
            _state.RemoveBullet(bullet);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _state.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}