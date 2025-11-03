using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Bomb[] bombs = new Bomb[1];
        Vector2 position;
        Vector2 velocity;
        public void Setup()
        {
            Window.SetTitle("Bounty Runner");
            Window.SetSize(800, 600);

            position = new Vector2(100, 300);

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
            PlayerGravity();
        }
        void Player()
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
                position.Y -= 105;
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
        void PlayerGravity()
        {
            velocity += new Vector2(0,105) * Time.DeltaTime;
            position += velocity;
            if (position.Y > 300)
            {
                position.Y = 300;
                velocity.Y = 0;
            }
        }
    }
}