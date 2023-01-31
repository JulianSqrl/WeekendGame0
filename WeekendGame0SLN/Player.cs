using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeekendGame0SLN
{
    public class Player : Sprite
    {
        public bool HasDied = false;

        public Player(Texture2D texture)
            : base(texture)
        {

        }

        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Velocity.X -= Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                Velocity.X = Speed;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            foreach(var sprite in sprites)
            {
                if (sprite is Player)
                    continue;

                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    this.HasDied = true;
                }
            }

            Position += Velocity;
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width); // Keep the Sprite on Screen
            Velocity = Vector2.Zero; // Resets Velocity to Zero when not touching a key
        }
    }
}
