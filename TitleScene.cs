using System;
using System.Drawing;
using System.Windows.Forms;
using static HackTheWorld.Constants;

namespace HackTheWorld
{
    class TitleScene : Scene
    {
        Image _img;

        public override void Cleanup()
        {
        }

        public override void Startup()
        {
            _img = System.Drawing.Image.FromFile(@"inouemasatosennsei.png");
        }

        public override void Update()
        {
            Console.WriteLine("title scene.");
            GraphicsContext.DrawImage(_img, 0, 0,192,256);

        }
    }
}
