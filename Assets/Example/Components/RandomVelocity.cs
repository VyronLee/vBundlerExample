//------------------------------------------------------------
//        File:  RandomVelocity.cs
//       Brief:  RandomVelocity
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:46
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================
using UnityEngine;

namespace Example.Components
{
    public class RandomVelocity : MonoBehaviour
    {
        private void Start()
        {
            var randx = Random.Range(-1f, 1f) * 10;
            var randz = Random.Range(5f, 10f);
            GetComponent<Rigidbody>().velocity = new Vector3(randx, 0, randz);
        }
    }
}