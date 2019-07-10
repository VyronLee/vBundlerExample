//------------------------------------------------------------
//        File:  AssetBundleCollectSample.cs
//       Brief:  AssetBundleCollectSample
//
//      Author:  VyronLee, lwz_jz@hotmail.com
//
//    Modified:  2019-07-09 14:46
//   Copyright:  Copyright (c) 2019, VyronLee
//============================================================

using System.Collections;
using UnityEngine;
using Logger = vBundler.Logs.Logger;

namespace Example.Samples
{
    public class AssetBundleCollectSample : BundlerSampleBase
    {
        private const string PrefabName = "Assets/Resources/Prefabs/Balls/ColorfulBall2.prefab";
        private const string InactivePrefabName = "Assets/Resources/Prefabs/Balls/InactiveColorfulBall2.prefab";

        private IEnumerator Start()
        {
            BundlerFacade.Instance.Bundler.SetLogLevel(Logger.LogLevel.VERBOSE);

            Debug.Log("=====================================");
            Debug.Log("Load GameObject: " + PrefabName);
            Debug.Log("=====================================");
            var asset = BundlerFacade.Instance.Bundler.Load(PrefabName).GetAsset<GameObject>();
            var go = asset.InstantiateGameObject();
            yield return new WaitForSeconds(1f);

            Debug.Log("=====================================");
            Debug.Log("Destroy GameObject Using 'Object.Destroy': " + PrefabName);
            Debug.Log("=====================================");
            Destroy(go);
            yield return new WaitForSeconds(1f);

            Debug.Log("=====================================");
            Debug.Log("Load Inactive GameObject: " + InactivePrefabName);
            Debug.Log("=====================================");
            asset = BundlerFacade.Instance.Bundler.Load(InactivePrefabName).GetAsset<GameObject>();
            go = asset.InstantiateGameObject();
            yield return new WaitForSeconds(3f);

            Debug.Log("=====================================");
            Debug.Log("Destroy Inactive GameObject Using 'Object.Destroy': " + InactivePrefabName);
            Debug.Log("=====================================");
            Destroy(go);
            yield return new WaitForSeconds(1f);

            Debug.Log("=====================================");
            Debug.Log("Deep collecting... ");
            Debug.Log("=====================================");
            BundlerFacade.Instance.Bundler.DeepCollect();

            Debug.Log("=====================================");
            Debug.Log("Load Inactive GameObject Again: " + InactivePrefabName);
            Debug.Log("=====================================");
            asset = BundlerFacade.Instance.Bundler.Load(InactivePrefabName).GetAsset<GameObject>();
            go = asset.InstantiateGameObject();
            yield return new WaitForSeconds(3f);

            Debug.Log("=====================================");
            Debug.Log("Destroy Inactive GameObject Using 'IAsset.DestroyGameObject': " + InactivePrefabName);
            Debug.Log("=====================================");
            asset.DestroyGameObject(go);
            yield return new WaitForSeconds(1f);
        }
    }
}