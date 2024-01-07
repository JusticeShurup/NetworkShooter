using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.GameObjects;
using NetworkShooter.States.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.States
{
    public class MenuState
        : GameState
    {
        private Button _playButton;

        private Button _easyButton;
        private Button _mediumButton;
        private Button _hardButton;

        private Button _exitButton;


        bool _isPlayButtonClicked = false;

        public MenuState(MainGame game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            
        }


        public override void Initialize()
        {
            SpriteFont spriteFont = game.Content.Load<SpriteFont>("gui");
            
            _playButton = new Button(game.Content.Load<Texture2D>("ButtonBackground"), spriteFont);
            _playButton.Text = "Play";
            _playButton.Position = new Vector2(1920 / 2 - 300, 400);
            _playButton.Click += PlayButton_Click;

            _easyButton = new Button(game.Content.Load<Texture2D>("ButtonBackground"), spriteFont);
            _easyButton.Text = "Easy Mode";
            _easyButton.Position = new Vector2(1920 / 2 - 300, 100);
            _easyButton.Click += EasyButton_Click;

            _mediumButton = new Button(game.Content.Load<Texture2D>("ButtonBackground"), spriteFont);
            _mediumButton.Text = "Medium Mode";
            _mediumButton.Position = new Vector2(1920 / 2 - 300, 300);
            _mediumButton.Click += MediumButton_Click;

            _hardButton = new Button(game.Content.Load<Texture2D>("ButtonBackground"), spriteFont);
            _hardButton.Text = "Hard Mode";
            _hardButton.Position = new Vector2(1920 / 2 - 300, 550);
            _hardButton.Click += HardButton_Click;



            _exitButton = new Button(game.Content.Load<Texture2D>("ButtonBackground"), spriteFont);
            _exitButton.Text = "Exit";
            _exitButton.Position = new Vector2(1920 / 2 - 300, 800);
            _exitButton.Click += ExitButton_Click;


            
        }

        public override void Update(GameTime gameTime)
        {
            if (!_isPlayButtonClicked) _playButton.Update(gameTime);

            if (_isPlayButtonClicked) _easyButton.Update(gameTime);
            if (_isPlayButtonClicked) _mediumButton.Update(gameTime);
            if (_isPlayButtonClicked) _hardButton.Update(gameTime);

            _exitButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (!_isPlayButtonClicked) _playButton.Draw(gameTime, _spriteBatch);

            if (_isPlayButtonClicked) _easyButton.Draw(gameTime, _spriteBatch);
            if (_isPlayButtonClicked) _mediumButton.Draw(gameTime, _spriteBatch);
            if (_isPlayButtonClicked) _hardButton.Draw(gameTime, _spriteBatch);

            _exitButton.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
        }

        public override void AddBullet(Bullet bullet)
        {
            throw new NotImplementedException();
        }

        public override void RemoveBullet(Bullet bullet)
        {
            throw new NotImplementedException();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            _isPlayButtonClicked = true;
        }


        private void EasyButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameplayState(game, _spriteBatch, GameMode.Easy));
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameplayState(game, _spriteBatch, GameMode.Medium));
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameplayState(game, _spriteBatch, GameMode.Hard));
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            game.Exit();
        }
    }
}
