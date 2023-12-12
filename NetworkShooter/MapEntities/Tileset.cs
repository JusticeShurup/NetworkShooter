using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.MapEntities
{
    public class Tileset : DrawableGameComponent
    {
        private Texture2D _tilesetTextureSheet;
        private SpriteBatch _spriteBatch;

        public Vector2 Position { get; private set; }
        public Vector2 Size { get; private set; }
        internal TilesetType TilesetType { get; private set; }

        private Rectangle _tileRect;


        public Tileset(Game game, SpriteBatch spriteBatch, Vector2 position)
                : base(game)
        {
            Position = position;
            _spriteBatch = spriteBatch;
        }

        internal Tileset(Game game, SpriteBatch spriteBatch, Vector2 position, TilesetType tilesetType)
                : base(game)
        {
            Position = position;
            _spriteBatch = spriteBatch;
            TilesetType = tilesetType;
        }

        protected override void LoadContent()
        {
            _tilesetTextureSheet = Game.Content.Load<Texture2D>("TilesetGrass");

            base.LoadContent();
        }

        public override void Initialize()
        {
            LoadContent();

            int width = _tilesetTextureSheet.Width / 2;
            int height = _tilesetTextureSheet.Height / 2;

            switch (TilesetType)
            {
                case TilesetType.Grass:
                    _tileRect = new Rectangle(0, 0, width, height);
                    break;
                case TilesetType.Flowers:
                    _tileRect = new Rectangle(width + 1, 0, width , height);
                    break;
                case TilesetType.VRoad:
                    _tileRect = new Rectangle(x: 0, y: height + 1, width, height);
                    break;
                case TilesetType.HRoad:
                    _tileRect = new Rectangle(x: width + 1, y: height + 1, width, height);
                    break;
            }

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(texture: _tilesetTextureSheet, position: Position, _tileRect, color: Color.White);
        }
    }
}
