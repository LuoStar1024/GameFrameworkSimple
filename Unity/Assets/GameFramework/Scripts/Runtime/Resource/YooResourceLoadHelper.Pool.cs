using GameFramework;
using GameFramework.ObjectPool;

namespace UnityGameFramework.Runtime
{
    public partial class YooResourceLoadHelper
    {
        private IObjectPool<AssetObject> m_AssetPool;
        
        /// <summary>
        /// 获取或设置资源对象池自动释放可释放对象的间隔秒数。
        /// </summary>
        public float AssetAutoReleaseInterval
        {
            get => m_AssetPool.AutoReleaseInterval;
            set => m_AssetPool.AutoReleaseInterval = value;
        }

        /// <summary>
        /// 获取或设置资源对象池的容量。
        /// </summary>
        public int AssetCapacity
        {
            get => m_AssetPool.Capacity;
            set => m_AssetPool.Capacity = value;
        }

        /// <summary>
        /// 获取或设置资源对象池对象过期秒数。
        /// </summary>
        public float AssetExpireTime
        {
            get => m_AssetPool.ExpireTime;
            set => m_AssetPool.ExpireTime = value;
        }

        /// <summary>
        /// 获取或设置资源对象池的优先级。
        /// </summary>
        public int AssetPriority
        {
            get => m_AssetPool.Priority;
            set => m_AssetPool.Priority = value;
        }
        
        /// <summary>
        /// 设置对象池管理器。
        /// </summary>
        /// <param name="objectPoolManager">对象池管理器。</param>
        private void SetObjectPoolManager(IObjectPoolManager objectPoolManager)
        {
            if (objectPoolManager == null)
            {
                throw new GameFrameworkException("Object pool manager is invalid.");
            }
            m_AssetPool = objectPoolManager.CreateMultiSpawnObjectPool<AssetObject>("Asset Pool");
        }
    }
}
