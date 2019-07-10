//------------------------------------------------------------
//        File:  LoadSceneAsyncSample.cs
//       Brief:  LoadSceneAsyncSample
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 12:58
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using vBundler.Interface;

namespace Example.Samples
{
    public class LoadSceneAsyncSample : BundlerSampleBase
    {
        private static readonly string kScenePath = "Assets/Scenes/LoadAssetAsyncSample.unity";

        private ISceneAsync _scene;

        private IEnumerator LoadScene()
        {
            if (null != _scene)
                yield break;

            var request = BundlerFacade.Instance.Bundler.LoadAsync(kScenePath);
            yield return request;

            var scene = request.GetSceneAsync(LoadSceneMode.Additive);
            yield return scene;

            scene.Activate();

            _scene = scene;
        }

        protected override void OnGUI()
        {
            base.OnGUI();

            var style = new GUIStyle(GUI.skin.button) {fontSize = 32};

            if (GUI.Button(new Rect(0, 120, 300, 100), new GUIContent("Load"), style))
            {
                StartCoroutine(LoadScene());
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