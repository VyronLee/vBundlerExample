//------------------------------------------------------------
//        File:  LoadSceneAsyncSample.cs
//       Brief:  LoadSceneAsyncSample
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 12:58
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================

using UnityEngine;
using UnityEngine.SceneManagement;
using vBundler.Interface;

namespace Example.Samples
{
    public class LoadSceneSyncSample : BundlerSampleBase
    {
        private static readonly string kScenePath = "Assets/Scenes/LoadAssetSyncSample.unity";

        private IScene _scene;

        protected override void OnGUI()
        {
            base.OnGUI();

            var style = new GUIStyle(GUI.skin.button) {fontSize = 32};

            if (GUI.Button(new Rect(0, 120, 300, 100), new GUIContent("Load"), style))
            {
                if (_scene != null)
                    return;

                _scene = BundlerFacade.Instance.Bundler.Load(kScenePath).GetScene(LoadSceneMode.Additive);
                _scene.Activate();
                return;
            }

            if (GUI.Button(new Rect(320, 120, 300, 100), new GUIContent("Unload"), style))
            {
                if (null != _scene)
                    _scene.Unload();
                _scene = null;
                return;
            }
        }
    }
}
