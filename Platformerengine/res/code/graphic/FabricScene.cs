using Microsoft.Win32;
using Platformerengine.res.code.graphic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Platformerengine.res.code.Graphics {
    class FabricScene {
        private Dictionary<string, Scene> Scenes;
        public Scene CurrentScene { get; set; }
        private static FabricScene Instance;
        public Dictionary<string, Scene> Checkpoints { get; }
        private FabricScene() {
            Scenes = new Dictionary<string, Scene>();
            Checkpoints = new Dictionary<string, Scene>();
        }

        public void AddCheckpoint(string name, Scene scene) {
            Checkpoints.Add(name, scene);
        }

        public void InitCurrentScene() {
            CurrentScene.InitScene();
        }

        public void LoadCheckpoint(string name) {
            CurrentScene.Stop();
            if (Checkpoints.ContainsKey(name))
                CurrentScene = Checkpoints[name];
        }

        public static FabricScene GetInstance() {
            if (Instance == null) {
                Instance = new FabricScene();
            }
            return Instance;
        }

        public void SetCurrentScene(string name) {
            if (Scenes.ContainsKey(name))
                CurrentScene = Scenes[name];

        }

        public void AddScene(string name, Scene scene) {
            Scenes.Add(name, scene);
            if (CurrentScene == null) {
                CurrentScene = scene;
            }
        }

        public Scene GetScene(string name) {
            if (Scenes.ContainsKey(name))
                return Scenes[name];
            else return null;
        }
    }
}