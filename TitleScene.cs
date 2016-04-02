using System;
using System.Drawing;
using static HackTheWorld.Constants;

namespace HackTheWorld
{
    class TitleScene : Scene
    {
        Image img;
        public override void Cleanup()
        {
        }

        public override void Startup()
        {
            img = System.Drawing.Image.FromFile(@"inouemasatosennsei.png");
        }

        public override void Update()
        {
            Console.WriteLine("title scene.");
            GraphicsContext.DrawImage(img, 0, 0,192,256);

        }
    }
}
