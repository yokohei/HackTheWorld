using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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

        public override void Cleanup()
        {
        }

        public override void Startup()
        {
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
            if (pressedKeys.Contains(Keys.Down) && !_transiting)
            {
                _cursor = (_cursor + 1) % 5;
                _transiting = true;
                Task.Run(() => {
                    Thread.Sleep(200);
                    _transiting = false;
                });
            }

            if (pressedKeys.Contains(Keys.Up) && !_transiting)
            {
                _cursor = (_cursor + 4) % 5;
                _transiting = true;
                Task.Run(() => {
                    Thread.Sleep(200);
                    _transiting = false;
                });
            }

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
            }

            // 下に戻っちゃうのは入力を pushed と pressed に分ければ解決する。
            if (pressedKeys.Contains(Keys.X) && !_transiting)
            {
                _cursor = 4;
            }

            foreach (var item in _menu)
            {
                item._selected = false;
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
