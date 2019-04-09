using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WDAlgorithm
{
    /// <summary>
    ///项目启动器
    /// </summary>
    public class WDApplication : MonoBehaviour
    {
        public List<GameObject> mainAssets = new List<GameObject>();
        public List<GameObject> optionAssets = new List<GameObject>();
        [Header("生成房间的随机半径")]
        public int Range = 10;
        private List<GameObject> mainGameObjects = new List<GameObject>();
        private List<GameObject> optionGameObjects = new List<GameObject>();
        private static WDApplication _instance;
        private void Awake()
        {
            _instance = this;
        }
        /// <summary>
        /// 生成地图
        /// </summary>
        public static void Generate(int mainCout, int opCout) {
            // 先生成所有的房间
            _instance._Generate(mainCout, opCout);
            // 把所有的房间挤开
        }
        /// <summary>
        /// 生成地图
        /// </summary>
        private void _Generate(int mainCout, int opCout) {
            if (mainCout <= 0) {
                return;
            }
            int allmainAssetCount = mainAssets.Count;
            if (allmainAssetCount <= 0) {
                return;
            }
            int alloptionAssetCount = optionAssets.Count;
            if (alloptionAssetCount == 0 && opCout > 0) {
                opCout = 0;
            }
            ClearAllRoom();
            CreateMainRoom(mainCout);
            CreateOptionRoom(opCout);
        }
        /// <summary>
        /// 清理房间
        /// </summary>
        private void ClearAllRoom() {
            int count = mainGameObjects.Count;
            for (int index = 0; index < count; index++) {
                Destroy(mainGameObjects[index]);
            }
            count = optionAssets.Count;
            for (int index = 0; index < count; index++)
            {
                Destroy(optionAssets[index]);
            }
            mainGameObjects.Clear();
            optionAssets.Clear();
        }
        /// <summary>
        /// 创建主要房间
        /// </summary>
        /// <param name="count">数量</param>
        private void CreateMainRoom(int count) {
            int allmainAssetCount = mainAssets.Count;
            for (int index = 0; index < count; index++) {
                int assetIndex = UnityEngine.Random.Range(0, allmainAssetCount - 1);
                GameObject go = mainAssets[assetIndex];
                InitializeRoom(go, ref mainGameObjects);
            }
        }
        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="go"></param>
        /// <param name="mainGameObjects"></param>
        private void InitializeRoom(GameObject go, ref List<GameObject> list)
        {
            int x = UnityEngine.Random.Range(-Range, Range);
            int z = UnityEngine.Random.Range(-Range, Range);
            GameObject _g = Instantiate(go, new Vector3(x, 0, z), Quaternion.identity);
            list.Add(_g);
        }

        /// <summary>
        /// 创建次要房间
        /// </summary>
        /// <param name="count">数量</param>
        private void CreateOptionRoom(int count) {
            int allmainAssetCount = optionAssets.Count;
            for (int index = 0; index < count; index++)
            {
                int assetIndex = UnityEngine.Random.Range(0, allmainAssetCount - 1);
                GameObject go = optionAssets[assetIndex];
                InitializeRoom(go, ref optionGameObjects);
            }
        }
    }
}