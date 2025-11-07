using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position = new Vector2(100, 300);
        Vector2 velocity;
        public void PlayerAvatar()
        {
            // Draw player head
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = new Color("FFE9D1");
            Draw.Circle(position.X + 75, position.Y + 25, 25);

            // Draw player body
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Rectangle(position.X + 50, position.Y + 50, 50, 100);

            // Player Jump
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Up) ||
                Input.IsKeyboardKeyPressed(KeyboardInput.W))
            {
                position.Y -= 100;
            }
            // Player Moves Left
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left) ||
                Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                position.X -= 10;
            }
            // Player Moves Right
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right) ||
                Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                position.X += 10;
            }
        }
        public void PlayerGravity()
        {
            velocity += new Vector2(0, 40) * Time.DeltaTime;
            position += velocity;
            if (position.Y > 300)
            {
                position.Y = 300;
                velocity.Y = 0;
            }
        }
    }
}
