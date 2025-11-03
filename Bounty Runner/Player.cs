using System;
using System.Numerics;

namespace MohawkGame2D;
public class Player
{
    Vector2 position;
    Vector2 velocity;

    public void Setup()
    {
        position = new Vector2(200, 425);
    }
}