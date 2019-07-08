﻿using System.Collections;
using System.Collections.Generic;
using Example;
using UnityEngine;
using vBundler.Extension;
using vBundler.Interface;

namespace Sample.Scripts.Components
{
    public class RandomChangeMaterials2 : MonoBehaviour
    {
        private const float kChangeInterval = 1f;

        private readonly List<string> materials = new List<string>
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
                var request = BundlerFacade.Instance.LoadAsync(materials[rand]);
                yield return request;
                var asset = request.GetAsset(typeof(Material));
                _render.SetMaterial(asset);
            }
        }
    }
}