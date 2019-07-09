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

namespace Example.Scenes
{
    public class LoadSceneAsyncSample : MonoBehaviour
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

        private void OnGUI()
        {
            var style = new GUIStyle(GUI.skin.button) {fontSize = 30};

            if (GUI.Button(new Rect(100, 100, 200, 80), new GUIContent("Load"), style))
            {
                StartCoroutine(LoadScene());
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