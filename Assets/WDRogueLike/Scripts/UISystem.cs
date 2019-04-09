using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WDAlgorithm
{
    /// <summary>
    /// ui系统
    /// </summary>
    public class UISystem : MonoBehaviour
    {
        /// <summary>
        /// 主房间数量
        /// </summary>
        [Header("主房间数量")]
        public InputField MainRoomCount;
        /// <summary>
        /// 次房间数量
        /// </summary>
        [Header("次房间数量")]
        public InputField OptionRoomCount;
        /// <summary>
        /// 生成
        /// </summary>
        public void Generate() {
            string s_maincount = MainRoomCount.text;
            if (string.IsNullOrEmpty(s_maincount))
                return;
            int opcount = 0;
            string s_opcount = OptionRoomCount.text;
            if (!string.IsNullOrEmpty(s_opcount)) {
                opcount = System.Convert.ToInt32(s_opcount);
            }
            WDApplication.Generate(System.Convert.ToInt32(s_maincount), opcount);
        }
    }
}