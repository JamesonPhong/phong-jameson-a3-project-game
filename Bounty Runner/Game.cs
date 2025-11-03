using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Bomb[] bombs = new Bomb[5];
        public void Setup()
        {
            Window.SetTitle("Bounty Runner");
            Window.SetSize(800, 600);

            for (int i = 0; i < bombs.Length; i++)
            {
                bombs[i] = new Bomb();
                bombs[i].Setup();
            }
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Draw a flat ground
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = new Color("228B22");
            Draw.Rectangle(0, 450, Window.Width, 450);

            for (int i = 0; i < bombs.Length; i++)
            {
                bombs[i].Update();
            }

            Player();
        }
        void Player()
        {
            // Draw player head
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = new Color("FFE9D1");
            Draw.Circle(175, 325, 25);

            // Draw player body
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Rectangle(150, 350, 50, 100);
        }
    }
}