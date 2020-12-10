using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Platformerengine.res.game_res.game_code {
    class SpriteRepository {
        private static SpriteRepository Instance { get; set; }
        public static SpriteRepository getInstance() {
            if (Instance == null) {
                Instance = new SpriteRepository();
            }

            return Instance;
        }
        
        public Dictionary<string, ImageBrush> Sprites { get; set; }
        private SpriteRepository() {
            Sprites = new Dictionary<string, ImageBrush>();
            DirectoryInfo dir = new DirectoryInfo("../../res/game_res/assets");

            foreach (FileInfo file in dir.EnumerateFiles("*.jpg")) {
                ImageBrush img = new ImageBrush(
                    new BitmapImage(
                        new Uri(file.FullName, UriKind.RelativeOrAbsolute)
                    )
                );
                Sprites.Add(file.Name, img);
            }
        }
    }
}
