using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        float changeLandscape = Time.SecondsElapsed;
        float doesLandScapeChange = Random.Float(9);
        public void Setup()
        {
            Window.SetTitle("Bounty Runner");
            Window.SetSize(800, 600);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Draw a flat ground
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(0, 450, Window.Width, 450);

            Player();
        }
        public void Player()
        {
            // Draw player head
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Black;
            Draw.Circle(175, 325, 25);

            // Draw player body
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(150, 350, 50, 100);
        }
    }
}