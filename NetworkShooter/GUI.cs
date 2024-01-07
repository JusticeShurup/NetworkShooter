using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter
{
    public class GUI 
        : DrawableGameComponent
    {
        private readonly MainGame game;
        private readonly Player _player;
        private readonly SpriteBatch _spriteBatch;

        private SpriteFont font;
        private readonly ContentManager contentManager;

        public int BulletCount { get; private set; } = 30;

        public GUI(MainGame game, SpriteBatch spriteBatch, Player player) 
            : base(game)
        {
            this.game = game;
            _player = player;
            contentManager = game.Content;
            _spriteBatch = spriteBatch;
            DrawOrder = 1100;
        }


        protected override void LoadContent()
        {
            font = contentManager.Load<SpriteFont>("gui");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            BulletCount = _player.Bullets;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, $"{BulletCount}/30", new Vector2(1800, 50), Color.White, 0, Vector2.One, 2, SpriteEffects.None, 0);
            _spriteBatch.DrawString(font, $"Score: {game.Score}", new Vector2(900, 50), Color.White, 0, Vector2.One, 2, SpriteEffects.None, 0);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
