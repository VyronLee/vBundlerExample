//------------------------------------------------------------
//        File:  RandomChangeMaterials.cs
//       Brief:  RandomChangeMaterials
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:46
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Components
{
    public class RandomChangeMaterials : MonoBehaviour
    {
        private const float kChangeInterval = 1f;
        private MeshRenderer _render;
        public List<Material> materials;

        private void Start()
        {
            _render = GetComponent<MeshRenderer>();

            StartCoroutine(AutoChangeColorProcess());
        }

        private IEnumerator AutoChangeColorProcess()
        {
            while (true)
            {
                yield return new WaitForSeconds(kChangeInterval);

                var rand = Random.Range(0, materials.Count);
                _render.material = materials[rand];
            }
        }
    }
}