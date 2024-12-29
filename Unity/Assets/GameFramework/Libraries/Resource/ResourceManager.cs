namespace GameFramework.Resource
{
    /// <summary>
    /// 资源管理器。
    /// </summary>
    internal sealed partial class ResourceManager : GameFrameworkModule, IResourceManager
    {
        private IResourceLoadHelper m_ResourceLoadHelper;
        
        /// <summary>
        /// 获取游戏框架模块优先级。
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行。</remarks>
        internal override int Priority
        {
            get
            {
                return 4;
            }
        }

        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {

        }

        internal override void Shutdown()
        {

        }

        public void SetResourceLoadHelper(IResourceLoadHelper resourceLoadHelper)
        {
            if (resourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }

            m_ResourceLoadHelper = resourceLoadHelper;
        }
        
        /// <summary>
        /// 检查资源是否存在。
        /// </summary>
        /// <param name="assetName">要检查资源的名称。</param>
        /// <param name="packageName">指定资源包的名称。不传使用默认资源包。</param>
        /// <returns>检查资源是否存在的结果。</returns>
        public HasAssetResult HasAsset(string assetName, string packageName = "")
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }

            return m_ResourceLoadHelper.HasAsset(assetName);
        }

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="location">资源的定位地址。</param>
        /// <param name="assetType">要加载资源的类型。</param>
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <param name="packageName">指定资源包的名称。不传使用默认资源包。</param>
        public void LoadAssetAsync(string location, System.Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks,
            object userData, string packageName = "")
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }
            
            m_ResourceLoadHelper.LoadAssetAsync(location,assetType, priority, loadAssetCallbacks, userData, packageName);
        }

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="location">资源的定位地址。</param>
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <param name="packageName">指定资源包的名称。不传使用默认资源包。</param>
        public void LoadAssetAsync(string location, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData,
            string packageName = "")
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }
            
            m_ResourceLoadHelper.LoadAssetAsync(location,priority, loadAssetCallbacks, userData, packageName);
        }

        /// <summary>
        /// 卸载资源。
        /// </summary>
        /// <param name="asset">要卸载的资源。</param>
        public void UnloadAsset(object asset)
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }
            
            m_ResourceLoadHelper.UnloadAsset(asset);
        }

        /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneAssetName">要加载场景资源的名称。</param>
        /// <param name="priority">加载场景资源的优先级。</param>
        /// <param name="loadSceneCallbacks">加载场景回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks,
            object userData)
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }
            
            m_ResourceLoadHelper.LoadScene(sceneAssetName, priority, loadSceneCallbacks, userData);
        }

        /// <summary>
        /// 异步卸载场景。
        /// </summary>
        /// <param name="sceneAssetName">要卸载场景资源的名称。</param>
        /// <param name="unloadSceneCallbacks">卸载场景回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks, object userData)
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }
            
            m_ResourceLoadHelper.UnloadScene(sceneAssetName, unloadSceneCallbacks, userData);
        }
    }
}
