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

namespace Example.Scenes
{
    public class LoadSceneSyncSample : MonoBehaviour
    {
        private static readonly string kScenePath = "Assets/Scenes/LoadAssetSyncSample.unity";

        private IScene _scene;

        private void OnGUI()
        {
            var style = new GUIStyle(GUI.skin.button) {fontSize = 30};

            if (GUI.Button(new Rect(100, 100, 200, 80), new GUIContent("Load"), style))
            {
                if (_scene != null)
                    return;

                _scene = BundlerFacade.Instance.Bundler.LoadAsset(kScenePath).GetScene(LoadSceneMode.Additive);
                _scene.Activate();
                return;
            }

            if (GUI.Button(new Rect(350, 100, 200, 80), new GUIContent("Unload"), style))
            {
                if (null != _scene)
                    _scene.Unload();
                _scene = null;
                return;
            }
        }
    }
}
