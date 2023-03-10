using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeekendGame0SLN
{
    public class Bomb : Sprite
    {
        public Bomb(Texture2D texture)
            : base(texture)
        {
            Position = new Vector2(Game1.Random.Next(0, Game1.ScreenWidth - texture.Width), -texture.Height);
            Speed = Game1.Random.Next(3, 10);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprite)
        {
            Position.Y += Speed;

            if (Rectangle.Bottom >= Game1.ScreenHeight)
                IsRemoved = true;
        }
    }
}
