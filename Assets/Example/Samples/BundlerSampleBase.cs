//------------------------------------------------------------
//        File:  BundlerSampleBase.cs
//       Brief:  BundlerSampleBase
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-10 10:52
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================

using UnityEngine;

namespace Example.Samples
{
    public class BundlerSampleBase : MonoBehaviour
    {
        protected virtual void OnGUI()
        {
            var mode = BundlerFacade.Instance.BundleMode ? "Mode: Bundle" : "Mode: Resource";
            var style = new GUIStyle(GUI.skin.button)
            {
                fontSize = 32
            };
            GUILayout.Label(new GUIContent(mode), style, GUILayout.Width(300), GUILayout.Height(100));
        }
    }
}