//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        /// <summary>
        /// 获取游戏基础组件。
        /// </summary>
        public static BaseComponent Base
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置组件。
        /// </summary>
        public static ConfigComponent Config
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据结点组件。
        /// </summary>
        public static DataNodeComponent DataNode
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表组件。
        /// </summary>
        public static DataTableComponent DataTable
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取调试组件。
        /// </summary>
        public static DebuggerComponent Debugger
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载组件。
        /// </summary>
        public static DownloadComponent Download
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体组件。
        /// </summary>
        public static EntityComponent Entity
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取事件组件。
        /// </summary>
        public static EventComponent Event
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取文件系统组件。
        /// </summary>
        public static FileSystemComponent FileSystem
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取有限状态机组件。
        /// </summary>
        public static FsmComponent Fsm
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取本地化组件。
        /// </summary>
        public static LocalizationComponent Localization
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取网络组件。
        /// </summary>
        public static NetworkComponent Network
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取对象池组件。
        /// </summary>
        public static ObjectPoolComponent ObjectPool
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取流程组件。
        /// </summary>
        public static ProcedureComponent Procedure
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源组件。
        /// </summary>
        public static ResourceComponent Resource
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取场景组件。
        /// </summary>
        public static SceneComponent Scene
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置组件。
        /// </summary>
        public static SettingComponent Setting
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取声音组件。
        /// </summary>
        public static SoundComponent Sound
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取定时器组件。
        /// </summary>
        public static TimerComponent Timer
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取界面组件。
        /// </summary>
        public static UIComponent UI
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取网络组件。
        /// </summary>
        public static WebRequestComponent WebRequest
        {
            get;
            private set;
        }

        private static void InitBuiltinComponents()
        {
            Base = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<BaseComponent>();
            Config = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<ConfigComponent>();
            DataNode = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<DataNodeComponent>();
            DataTable = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<DataTableComponent>();
            Debugger = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<DebuggerComponent>();
            Download = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<DownloadComponent>();
            Entity = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<EntityComponent>();
            Event = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<EventComponent>();
            FileSystem = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<FileSystemComponent>();
            Fsm = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<FsmComponent>();
            Localization = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<LocalizationComponent>();
            Network = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<NetworkComponent>();
            ObjectPool = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<ObjectPoolComponent>();
            Procedure = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<ProcedureComponent>();
            Resource = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<ResourceComponent>();
            Scene = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<SceneComponent>();
            Setting = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<SettingComponent>();
            Sound = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<SoundComponent>();
            Timer = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<TimerComponent>();
            UI = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<UIComponent>();
            WebRequest = UnityGameFramework.Runtime.UnityGameFrameworkEntry.GetComponent<WebRequestComponent>();
        }
    }
}
