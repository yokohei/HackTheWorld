using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static HackTheWorld.Constants;

namespace HackTheWorld
{
    class TitleScene : Scene
    {
        private bool _transiting;
        private Image[] _menuImages;
        private MenuItem[] _menu;
        private int _cursor;
        private Stopwatch _sw;

        public override void Cleanup()
        {
        }

        public override void Startup()
        {
            _sw = new Stopwatch();
            _sw.Start();
            _transiting = false;
            _cursor = 0;
            _menuImages = new Image[10];
            _menu = new MenuItem[5];

            _menuImages[0] = Image.FromFile(@".\image\10.png");
            _menuImages[1] = Image.FromFile(@".\image\3.png");

            _menu[0] = new MenuItem(_menuImages[0], _menuImages[1]);
            _menu[0].SetPosition(100, 100);
            _menu[1] = new MenuItem(_menuImages[0], _menuImages[1]);
            _menu[1].SetPosition(100, 200);
            _menu[2] = new MenuItem(_menuImages[0], _menuImages[1]);
            _menu[2].SetPosition(100, 300);
            _menu[3] = new MenuItem(_menuImages[0], _menuImages[1]);
            _menu[3].SetPosition(100, 400);
            _menu[4] = new MenuItem(_menuImages[0], _menuImages[1]);
            _menu[4].SetPosition(100, 500);

        }

        public override void Update()
        {
//            Console.WriteLine("title scene.");

            if (pressedKeys.Contains(Keys.Down) && !_transiting)
            {
                _cursor++;
                _transiting = true;
                _sw.Reset();
                _sw.Start();
            }
            if (pressedKeys.Contains(Keys.Up) && !_transiting)
            {
                _cursor--;
                _transiting = true;
                _sw.Reset();
                _sw.Start();
            }
            _cursor = (_cursor + 5) % 5;
            if (pressedKeys.Contains(Keys.Z) && !_transiting)
            {
                switch (_cursor)
                {
                    case 0:
                        Scene.Push(new GameScene());
                        break;
                    case 1:
                        Scene.Push(new MasatoScene1());
                        break;
                    case 2:
                        Scene.Push(new MasatoScene2());
                        break;
                    case 3:
                        Scene.Push(new MasatoScene3());
                        break;
                    case 4:
                        Application.Exit();
                        break;
                }
                _transiting = true;
                _sw.Reset();
                _sw.Start();
            }

            if (_sw.ElapsedMilliseconds > 200)
            {
                _transiting = false;
            }

            for (int i = 0; i < 5; i++)
            {
                _menu[i]._selected = false;
            }
            _menu[_cursor]._selected = true;



            GraphicsContext.Clear(Color.White);
            foreach (var item in _menu)
            {
                item.Draw();
            }

        }
    }
}
