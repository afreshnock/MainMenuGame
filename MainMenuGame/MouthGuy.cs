using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing.Printing;
using Microsoft.Xna.Framework.Content;
using SharpDX.Direct2D1.Effects;
using SharpDX.DXGI;

namespace MainMenuGame
{
    public class MouthGuy
    {
        public Vector2 Position;
        private short animationFrame;
        private Texture2D texture;
        private KeyboardState prior;
        private KeyboardState current;
        private double animationTimer;
        private float scaling = 5;
        public bool exit;
        private bool held;

        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("mouth guy");
        }

        public void Update(GameTime gameTime)
        {
            prior = current;
            current = Keyboard.GetState();
            if(current.IsKeyDown(Keys.Space) && prior.IsKeyDown(Keys.Space))
            {
                if(held == false) 
                {
                    held = true;
                    animationFrame = 0;
                }
                
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimer > 0.1)
                {
                    animationFrame++;
                    if (animationFrame == 3)
                    {
                        animationFrame = 2;
                        scaling++;
                        if (scaling >= 25) exit = true;
                    }
                    animationTimer -= 0.1;
                }
            }
            else
            {
                if (held)
                {
                    held = false;
                    animationFrame = 0;
                    scaling = 5;
                }
                else
                {
                    animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
                    if (animationTimer > 1)
                    {
                        if (animationFrame == 0 || animationFrame == 4)
                        {
                            animationFrame = 3;
                        }
                        else if (animationFrame == 3)
                        {
                            animationFrame = 4;
                        }
                        
                        animationTimer -= 1;
                    }
                }
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle source = new Rectangle(0 , animationFrame * 32 , 32 ,32);
            spriteBatch.Draw(texture, Position, source, Color.White, 0, new Vector2(16f, 16f), scaling, SpriteEffects.None, 0);
        }

    }
}
