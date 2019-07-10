//------------------------------------------------------------
//        File:  MixLoadSyncAndAsyncSample.cs
//       Brief:  MixLoadSyncAndAsyncSample
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:47
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Samples
{
    public class MixLoadSyncAndAsyncSample : BundlerSampleBase
    {
        private const int kMaxBalls = 200;
        private const float kCreateBallsInterval = 0.3f;
        private readonly List<GameObject> balls = new List<GameObject>();

        private readonly List<string> prefabs = new List<string>
        {
            "Assets/Resources/Prefabs/Balls/BlueBall.prefab",
            "Assets/Resources/Prefabs/Balls/GreenBall.prefab",
            "Assets/Resources/Prefabs/Balls/RedBall.prefab",
            "Assets/Resources/Prefabs/Balls/ColorfulBall.prefab",
            "Assets/Resources/Prefabs/Balls/ColorfulBall2.prefab"
        };

        private void Start()
        {
            StartCoroutine(CreateBallsAsync());
            StartCoroutine(CreateBallsSync());
        }

        private IEnumerator CreateBallsSync()
        {
            while (true)
            {
                yield return CreateBall();
                yield return new WaitForSeconds(kCreateBallsInterval);
            }
        }

        private IEnumerator CreateBallsAsync()
        {
            while (true)
            {
                yield return CreateBallAsync();
                yield return new WaitForSeconds(kCreateBallsInterval);
            }
        }

        private IEnumerator CreateBall()
        {
            var randIdx = Random.Range(0, prefabs.Count);
            var asset = BundlerFacade.Instance.Bundler.Load(prefabs[randIdx]).GetAsset<GameObject>();
            var ball = asset.InstantiateGameObject();
            ball.transform.position += (Vector3.up + Vector3.back) * 2;

            if (balls.Count > kMaxBalls)
            {
                Destroy(balls[0]);
                balls.RemoveAt(0);
            }

            balls.Add(ball);

            yield break;
        }

        private IEnumerator CreateBallAsync()
        {
            var randIdx = Random.Range(0, prefabs.Count);
            var request = BundlerFacade.Instance.Bundler.LoadAsync(prefabs[randIdx]);
            yield return request;
            var asset = request.GetAsset(typeof(GameObject));
            var ball = asset.InstantiateGameObject();
            ball.transform.position += (Vector3.up + Vector3.back) * 2;

            if (balls.Count > kMaxBalls)
            {
                Destroy(balls[0]);
                balls.RemoveAt(0);
            }

            balls.Add(ball);
        }
    }
}