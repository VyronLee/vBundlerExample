using System.IO;
using UnityEngine;
using vBundler;
using vBundler.Interface;
using vBundler.Utils;

namespace Example
{
    public class BundlerFacade : MonoBehaviour
    {
        private static BundlerFacade _instance;
        private IBundler _vBundler;

        public static BundlerFacade Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                return _instance = new GameObject("Bundler").AddComponent<BundlerFacade>();
            }
        }

        private void Awake()
        {
            var manifestFullPath = Path.Combine(Application.streamingAssetsPath, "Bundles/Manifest.json");
            var manifestText = File.ReadAllText(manifestFullPath);
            var manifest = JsonUtility.FromJson<BundlerManifest>(manifestText);
            var searchPath = Path.Combine(Application.streamingAssetsPath, "Bundles");

            _vBundler = new Bundler(manifest);
            _vBundler.AddSearchPath(searchPath);
        }

        public IAsset Load<T>(string path) where T : Object
        {
            return _vBundler.LoadAsset(path).GetAsset(typeof(T));
        }

        public ILoadRequestAsync LoadAsync(string path)
        {
            return _vBundler.LoadAssetAsync(path);
        }

        public void SetLogLevel(int level)
        {
            _vBundler.SetLogLevel(level);
        }

        private void Update()
        {
            _vBundler.GarbageCollect();
        }
    }
}