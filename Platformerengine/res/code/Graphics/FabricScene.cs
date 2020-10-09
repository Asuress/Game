using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Platformerengine.res.code.Graphics {
    class FabricScene {
        private Dictionary<string, LinkedList<logic.GameObject>> Scenes;
        private static FabricScene Instance;
        private FabricScene() {
            Scenes = new Dictionary<string, LinkedList<Platformerengine.res.code.logic.GameObject>>();
        }

        public static FabricScene GetInstance() {
            if (Instance == null) {
                Instance = new FabricScene();
            }
            return Instance;
        }

        public void AddScene(string name, LinkedList<logic.GameObject> go) {
            Scenes.Add(name, go);
        }

        public LinkedList<logic.GameObject> GetScene(string name) {
            if (Scenes.ContainsKey(name))
                return Scenes[name];
            else return null;
        }
    }
}
