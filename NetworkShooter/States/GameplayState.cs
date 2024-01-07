using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NetworkShooter.GameObjects;
using NetworkShooter.MapEntities;
using NetworkShooter.States.Base;
using System.Collections.Generic;
using System;

namespace NetworkShooter.States
{
    public class GameplayState : GameState
    {


        private Player _player;
        private GUI _gui;
        private Map _map;

        private List<Bullet> bullets = new List<Bullet>();
        private List<Enemy> enemies = new List<Enemy>();

        private float _respawnCooldown = 1000;
        private int _respawnReduceCooldownLimit = 200;
        private int _currentLimit = 0;

        private float enemyRespawnTimer = 0;

        private GameMode GameMode { get; set; }


        public GameplayState(MainGame game, SpriteBatch spriteBatch, GameMode gameMode) 
            : base(game, spriteBatch)
        {
            GameMode = gameMode;
            _respawnCooldown = 1000f / (int)gameMode;
        }

       
        public override void Initialize()
        {
            _player = new Player(game, _spriteBatch);
            _player.SetPosition(new Vector2(1000, 1000));
            _map = new Map(game, _spriteBatch, 40, 40);
            _gui = new GUI(game, _spriteBatch, _player);

            game.Components.Add(_player);
            game.Components.Add(_map);
            game.Components.Add(_gui);
        }

        public override void Update(GameTime gameTime)
        {
            List<Enemy> enemiesToRemove = new List<Enemy>();
            List<Bullet> bulletToRemove = new List<Bullet>();



            foreach (var enemy in enemies)
            {
                if (_player.Collision(enemy))
                {
                    game.Components.Clear();
                    game.ChangeState(new MenuState(game, _spriteBatch));
                    return;
                }
            }

            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.Collision(bullet))
                    {
                        enemiesToRemove.Add(enemy);
                        bulletToRemove.Add(bullet);
                        game.Score += 1 * (int)GameMode;
                        break;
                    }
                }
            }

            foreach (var enemy in enemiesToRemove)
            {
                game.Components.Remove(enemy);
                enemies.Remove(enemy);
            }

            foreach (var bullet in bulletToRemove)
            {
                game.Components.Remove(bullet);
                bullets.Remove(bullet);
            }

            enemyRespawnTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (enemyRespawnTimer >= _respawnCooldown )
            {
                enemyRespawnTimer -= _respawnCooldown ;

                if (_currentLimit < _respawnReduceCooldownLimit)
                {
                    _currentLimit += 1;
                    _respawnCooldown -= 1;

                }
                var value = new Random().Next(0, 360);

                float xCoord = (float)Math.Cos(value * Math.PI / 180) * 2000;
                float yCoord = (float)Math.Sin(value * Math.PI / 180) * 2000;

                Enemy enemy1 = new Enemy(game, _spriteBatch, _player);
                enemy1.SetPosition(new Vector2(xCoord, yCoord) + _player.Position);


                enemies.Add(enemy1);
                game.Components.Add(enemy1);
            }


        }

        public override void AddBullet(Bullet bullet)
        {
            game.Components.Add(bullet);
            bullets.Add(bullet);
        }

        public override void RemoveBullet(Bullet bullet)
        {
            game.Components.Remove(bullet);
            bullets.Remove(bullet);
        }

        public override void Draw(GameTime gameTime)
        {

        }

    }
}