using System;
using System.Numerics;

namespace MohawkGame2D;
public class Bomb
{
    public Vector2 position;
    Vector2 velocity;
    public int size;
    Color color;
    public void Setup(int x, int s)
    {
        // Spawn position of bombs
        position = new Vector2(x, 425);

        // Move left at a random speed
        Vector2 direction = new Vector2(-1, 0);
        velocity = direction * s;

        // Bomb size and colour
        size = 25;
        color = Color.Black;
    }
    public void Update()
    {
        // Movement of bombs
        position += velocity * Time.DeltaTime;

        // Draw the bombs
        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        Draw.FillColor = color;
        Draw.Circle(position.X, position.Y, size);
    }
}