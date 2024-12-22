using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace GameFramework.Resource
{
    /// <summary>
    /// 资源管理器。
    /// </summary>
    internal sealed partial class ResourceManager:GameFrameworkModule,IResourceManager
    {
        public string ApplicableGameVersion { get; }
        public int InternalResourceVersion { get; }
        public int DownloadingMaxNum { get; set; }
        public int FailedTryAgain { get; set; }
        public string ReadOnlyPath { get; }
        public string ReadWritePath { get; }
        
        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {
            throw new System.NotImplementedException();
        }

        internal override void Shutdown()
        {
            throw new System.NotImplementedException();
        }
        
        public void SetReadOnlyPath(string readOnlyPath)
        {
            throw new NotImplementedException();
        }

        public void SetReadWritePath(string readWritePath)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public string DefaultPackageName { get; set; }
        public long Milliseconds { get; set; }
        public string HostServerURL { get; set; }
        public float AssetAutoReleaseInterval { get; set; }
        public int AssetCapacity { get; set; }
        public float AssetExpireTime { get; set; }
        public int AssetPriority { get; set; }
        public void UnloadAsset(object asset)
        {
            throw new NotImplementedException();
        }

        public void UnloadUnusedAssets()
        {
            throw new NotImplementedException();
        }

        public void ForceUnloadAllAssets()
        {
            throw new NotImplementedException();
        }

        public HasAssetResult HasAsset(string location, string packageName = "")
        {
            throw new NotImplementedException();
        }

        public bool CheckLocationValid(string location, string packageName = "")
        {
            throw new NotImplementedException();
        }

        public void LoadAssetAsync(string location, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData,
            string packageName = "")
        {
            throw new NotImplementedException();
        }

        public void LoadAssetAsync(string location, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks,
            object userData, string packageName = "")
        {
            throw new NotImplementedException();
        }

        public T LoadAsset<T>(string location, string packageName = "") where T : Object
        {
            throw new NotImplementedException();
        }

        public UniTaskVoid LoadAsset<T>(string location, Action<T> callback, string packageName = "") where T : Object
        {
            throw new NotImplementedException();
        }

        public TObject[] LoadSubAssetsSync<TObject>(string location, string packageName = "") where TObject : Object
        {
            throw new NotImplementedException();
        }

        public UniTask<TObject[]> LoadSubAssetsAsync<TObject>(string location, string packageName = "") where TObject : Object
        {
            throw new NotImplementedException();
        }

        public UniTask<T> LoadAssetAsync<T>(string location, CancellationToken cancellationToken = default, string packageName = "") where T : Object
        {
            throw new NotImplementedException();
        }
    }
}
