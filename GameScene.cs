using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static HackTheWorld.Constants;

namespace HackTheWorld
{
    class GameScene : Scene
    {
        public override void Cleanup()
        {
        }

        public override void Startup()
        {
        }

        public override void Update()
        {
            Console.WriteLine("game scene.");
            GraphicsContext.FillRectangle(Brushes.Red, 100, 100, 100, 100);
        }
    }
}
