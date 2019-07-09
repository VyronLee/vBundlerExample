//------------------------------------------------------------
//        File:  LoadAssetSyncSample.cs
//       Brief:  LoadAssetSyncSample
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:47
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Scenes
{
    public class LoadAssetSyncSample : MonoBehaviour
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

        private IEnumerator CreateBall()
        {
            var randIdx = Random.Range(0, prefabs.Count);
            var asset = BundlerFacade.Instance.Bundler.LoadAsset(prefabs[randIdx]).GetAsset<GameObject>();
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
    }
}