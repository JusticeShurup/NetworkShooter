using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkShooter.MapEntities
{
    public class Map : DrawableGameComponent
    {
        readonly SpriteBatch _spriteBatch;

        List<Tileset> _tilesets = new List<Tileset>();

        public int Width { get; private set; }
        public int Height { get; private set; }



        public Map(Microsoft.Xna.Framework.Game game, SpriteBatch spriteBatch, int width, int height) : base(game)
        {
            _spriteBatch = spriteBatch;
            Width = width; 
            Height = height;
        }

        public override void Initialize()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    _tilesets.Add(new Tileset(Game, _spriteBatch, new Vector2(x * 64, y * 64), TilesetType.VRoad));
                    _tilesets.LastOrDefault().Initialize();
                }
            }   

            base.Initialize();
        }

        protected override void LoadContent()
        { 

            base.LoadContent(); 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(transformMatrix: Camera.Translation);
            foreach (var tileset in _tilesets)
            {
                tileset.Draw(gameTime);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
