//------------------------------------------------------------
//        File:  BundlerFacade.cs
//       Brief:  BundlerFacade
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:48
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================

using System.IO;
using UnityEngine;
using vBundler;
using vBundler.Interface;
using Logger = vBundler.Logs.Logger;

#if UNITY_EDITOR
    using UnityEditor;
#endif


namespace Example
{
    public class BundlerFacade : MonoBehaviour
    {
        private static BundlerFacade _instance;
        private IBundler _vBundler;
        public bool BundleMode { private set; get; }

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
            var bundleMode = false;
            var logLevel = Logger.LogLevel.ERROR;
#if UNITY_EDITOR
            bundleMode = EditorPrefs.GetBool("vBundlerModePreferenceKey", false);
            logLevel = EditorPrefs.GetInt("vBundlerLogLevelPreferenceKey", 0) + 1;
#endif

            var manifestFullPath = Path.Combine(Application.streamingAssetsPath, "Bundles/Manifest.json");
            var manifestText = File.ReadAllText(manifestFullPath);
            var manifest = JsonUtility.FromJson<BundlerManifest>(manifestText);
            var searchPath = Path.Combine(Application.streamingAssetsPath, "Bundles");

            _vBundler = new Bundler(manifest);
            _vBundler.AddSearchPath(searchPath);
            _vBundler.SetMode(bundleMode ? BundleModeType.Bundle : BundleModeType.Resource);
            _vBundler.SetLogLevel(logLevel);

            BundleMode = bundleMode;
        }

        public IBundler Bundler
        {
            get { return _vBundler; }
        }

        private void Update()
        {
            _vBundler.Collect();
        }
    }
}