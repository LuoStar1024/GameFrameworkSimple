using GameFramework.Download;
using GameFramework.FileSystem;
using GameFramework.ObjectPool;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameFramework.Resource
{
    /// <summary>
    /// 资源管理器。
    /// </summary>
    internal sealed partial class ResourceManager : GameFrameworkModule, IResourceManager
    {
        private IResourceLoadHelper m_ResourceLoadHelper;

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
        /// <returns>检查资源是否存在的结果。</returns>
        public HasAssetResult HasAsset(string assetName)
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
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <param name="packageName">指定资源包的名称。不传使用默认资源包。</param>
        public void LoadAsset(string location, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData,
            string packageName = "")
        {
            if (m_ResourceLoadHelper == null)
            {
                throw new GameFrameworkException("Resource load helper is invalid.");
            }
            
            m_ResourceLoadHelper.LoadAsset(location,priority, loadAssetCallbacks, userData, packageName);
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
