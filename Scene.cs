using System.Collections.Generic;
using System.Linq;

namespace HackTheWorld
{
    abstract class Scene
    {
        static Stack<Scene> _sceneStack;

        static Scene Current
        {
            set
            {
                Scene s = value;
                foreach (Scene scene in _sceneStack) scene.Cleanup();
                s?.Startup();
                _sceneStack = new Stack<Scene>();
                _sceneStack.Push(s);
            }
            get
            {
                return _sceneStack.First();
            }
        }

        static void Push(Scene s)
        {
            s.Startup();
            _sceneStack.Push(s);
        }

        static void Pop()
        {
            var s = _sceneStack.Pop();
            s.Cleanup();
        }

        protected abstract void Update();
        protected abstract void Cleanup();
        protected abstract void Startup();

    }
}
