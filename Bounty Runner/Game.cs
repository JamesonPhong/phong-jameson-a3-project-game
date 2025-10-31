using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        public void Setup()
        {
            Window.SetTitle("Bounty Runner");
            Window.SetSize(800, 600);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
        }
    }
}