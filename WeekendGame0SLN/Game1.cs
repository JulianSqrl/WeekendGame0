using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace WeekendGame0SLN
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private Sprite _sprite1;
        //private Sprite _sprite2;

        public static Random Random;

        public static int ScreenHeight;
        public static int ScreenWidth;

        private List<Sprite> _sprites;

        private float _timer;

        private bool _hasStarted = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Random = new Random();

            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Restart();

            //_sprite1 = new Sprite(texture);
            //_sprite1.Position = new Vector2(100, 100);

            //_sprite2 = new Sprite(texture)
            //{
            //    Position = new Vector2(200,100),
            //};

            // TODO: use this.Content to load your game content here
        }

        private void Restart()
        {
            var playerTexture = Content.Load<Texture2D>("White Ball");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2((ScreenWidth / 2) - (playerTexture.Width/ 2), ScreenHeight- playerTexture.Height),
                    Speed = 10f,
                }
            };

            _hasStarted = false;
        }

        protected override void Update(GameTime gameTime)
        {
            //_sprite1.Update();
            //_sprite2.Update();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _hasStarted = true;
            }

            if (!_hasStarted)
                return;

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);

            if (_timer > 0.25f)
            {
                _timer = 0;
                _sprites.Add(new Bomb(Content.Load<Texture2D>("Bomb")));
            }

            for(int i= 0; i < _sprites.Count; i++)
            {
                var sprite = _sprites[i];
                if (sprite.IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }

                if (sprite is Player)
                {
                    var player = sprite as Player;

                    if (player.HasDied)
                    {
                        Restart();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            //_sprite1.Draw(_spriteBatch);
            //_sprite2.Draw(_spriteBatch);

            foreach (var sprite in _sprites)
            {
                sprite.Draw(_spriteBatch);
            }
              
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
