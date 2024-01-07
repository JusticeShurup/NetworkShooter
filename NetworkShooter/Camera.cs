using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NetworkShooter
{
    public static class Camera
    {
        public static Vector2 Position { get; private set; }
        public static float Rotation { get; private set; } = 0; // In degrees
        public static Matrix Translation { get; private set; }
        public static float Delay { get; set; } = 3.0f;


        public static Vector2 ScreenToWorldSpace(in Vector2 point)
        {
            Matrix invertedMatrix = Matrix.Invert(Translation);
            return Vector2.Transform(point, invertedMatrix);
        }

        public static void Update(Vector2 newCameraPosition, float newRotationInDegrees = 0)
        {
            Position = newCameraPosition;

            Translation = Matrix.CreateTranslation(1920f / 2f - Position.X, 1080f / 2f - Position.Y, 0);
            Rotation = newRotationInDegrees;
        }
    }

}
