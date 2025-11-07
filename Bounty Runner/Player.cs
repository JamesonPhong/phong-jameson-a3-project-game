using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position = new Vector2(100, 300);
        Vector2 velocity;
        public int playerLives = 5;
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
            // Calculate Player Gravity
            velocity += new Vector2(0, 40) * Time.DeltaTime;
            position += velocity;

            // Ensures Player doesn't fall through the floor
            if (position.Y > 300)
            {
                position.Y = 300;
                velocity.Y = 0;
            }
        }
        public void CollideWithPlayer(Bomb bomb)
        {
            // Remove Collision Detection for any Bombs that hit the Player
            if (bomb.hitThePlayer == true)
            {

            }
            else // Bomb Collision Detection
            {
                float bombLeft = bomb.position.X - bomb.size;
                float bombRight = bomb.position.X + bomb.size;
                float bombTop = bomb.position.Y - bomb.size;

                float playerLeft = position.X;
                float playerRight = position.X + 50;
                float playerBottom = position.Y + 100;

                bool bombCollidePlayerRight = bombLeft <= playerRight;
                bool bombCollidePlayerLeft = bombRight >= playerLeft;
                bool bombCollidePlayerBottom = bombTop <= playerBottom;

                // Check if Bomb hits Player
                if (bombCollidePlayerLeft && bombCollidePlayerRight && bombCollidePlayerBottom)
                {
                    playerLives -= 1;
                    bomb.hitThePlayer = true;
                }
            }
        }
    }
}
