using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Bomb[] bombs = new Bomb[300];
        Player player = new Player();
        int speedLimit = 0;
        float timeSurvived;
        public void Setup()
        {
            Window.SetTitle("Bounty Runner");
            Window.SetSize(800, 600);

            // Game Reset
            player.playerLives = 5;
            timeSurvived = 0;
            Time.SecondsElapsed = 0;

            for (int i = 0; i < bombs.Length; i++)
            {
                // Gradually increase Bomb Speed to a point, then randomize
                if (speedLimit > 5)
                {
                    speedLimit = Random.Integer(5, 10);
                }
                else
                {
                    speedLimit += 1;
                }
                bombs[i] = new Bomb();
                bombs[i].Setup(Window.Width + (1000 * i) * 2, 100 * (10 + speedLimit));
            }
        }
        public void Update()
        {
            // End the Game Player has no more lives
            if (player.playerLives == 0)
            {
                EndScreen();
            }
            else // Run the Game if Player has lives
            {
                BountyRunnerGame();
            }
        }
        void BountyRunnerGame()
        {
            Window.ClearBackground(Color.OffWhite);

            // Draw a flat ground
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = new Color("228B22");
            Draw.Rectangle(0, 450, Window.Width, 450);

            // Draw Player Lives on screen
            string playerLiveCount = $"Player Lives: {player.playerLives}";
            string trackTimeSurvived = $"Time Survived: {Time.SecondsElapsed:0.0}";

            // Draw Time Survived on screen
            timeSurvived = Time.SecondsElapsed;
            Text.Color = Color.Black;
            Text.Draw(playerLiveCount, 50, 50);
            Text.Draw(trackTimeSurvived, 50, 100);

            for (int i = 0; i < bombs.Length; i++)
            {
                bombs[i].Update();
                player.CollideWithPlayer(bombs[i]);
            }

            // Draw Player Avatar on screen
            player.PlayerAvatar();
            player.PlayerGravity();
        }
        void EndScreen()
        {
            Window.ClearBackground(Color.OffWhite);
            Text.Color = Color.Black;
            string endText = $"Time Survived: {timeSurvived:0.0}\nPress R to Retry";
            float y = Window.Height / 2 - Text.Size;
            Text.Draw(endText, 50, y);

            // Reset Game
            if (Input.IsKeyboardKeyPressed(KeyboardInput.R))
            {
                Setup();
            }
        }
    }
}