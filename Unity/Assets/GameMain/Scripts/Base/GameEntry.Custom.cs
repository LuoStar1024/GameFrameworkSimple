//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameProto;
using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static ConfigComponent Config
        {
            get;
            private set;
        }
        
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }

        public static HPBarComponent HPBar
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            Config = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<ConfigComponent>();
            BuiltinData = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<BuiltinDataComponent>();
            HPBar = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<HPBarComponent>();
        }
    }
}
