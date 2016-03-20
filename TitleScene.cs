using System;
using System.Drawing;
using static HackTheWorld.Constants;

namespace HackTheWorld
{
    class TitleScene : Scene
    {
        public override void Cleanup()
        {
        }

        public override void Startup()
        {
        }

        public override void Update()
        {
            Console.WriteLine("title scene.");
            GraphicsContext.FillRectangle(Brushes.Blue, 100, 100, 100, 100);
        }
    }
}
