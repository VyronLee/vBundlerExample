//------------------------------------------------------------
//        File:  RandomChangeMaterials2.cs
//       Brief:  RandomChangeMaterials2
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:46
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vBundler.Extension;
using vBundler.Interface;

namespace Example.Components
{
    public class RandomChangeMaterials2 : MonoBehaviour
    {
        private const float kChangeInterval = 1f;

        private static readonly List<string> materials = new List<string>
        {
            "Assets/Resources/Materials/Orange_1.mat",
            "Assets/Resources/Materials/Orange_2.mat",
            "Assets/Resources/Materials/Orange_3.mat"
        };

        private Renderer _render;

        private IBundler bundler;

        private IEnumerator Start()
        {
            _render = GetComponent<Renderer>();

            yield return AutoChangeColorProcess();
        }

        private IEnumerator AutoChangeColorProcess()
        {
            while (true)
            {
                yield return new WaitForSeconds(kChangeInterval);

                var rand = Random.Range(0, materials.Count);
                var request = BundlerFacade.Instance.Bundler.LoadAsync(materials[rand]);
                yield return request;
                var asset = request.GetAsset(typeof(Material));
                _render.SetMaterial(asset);
            }
        }
    }
}