using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
namespace NetworkShooter
{
    public static class Camera
    {
        public static Vector2 Position { get; private set; }
        public static Matrix Transform { get; private set; }
        public static float Delay { get; set; } = 3.0f;


        public static Vector2 ScreenToWorldSpace(in Vector2 point)
        {
            Matrix invertedMatrix = Matrix.Invert(Transform);
            return Vector2.Transform(point, invertedMatrix);
        }

        public static void Update(Vector2 newCameraPosition)
        {
            var dx = 1920 / 2 - newCameraPosition.X;
            var dy = 1080 / 2 - newCameraPosition.Y;

            Transform = Matrix.CreateTranslation(dx, dy, 0f);
        }
    }

}
