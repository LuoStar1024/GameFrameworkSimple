using GameFramework;
using GameFramework.ObjectPool;
using YooAsset;

namespace UnityGameFramework.Runtime
{
    public partial class YooResourceLoadHelper
    {
        /// <summary>
        /// 资源对象。
        /// </summary>
        private sealed class AssetObject : ObjectBase
        {
            private AssetHandle m_AssetHandle = null;

            public static AssetObject Create(string name, object target, object assetHandle)
            {
                if (assetHandle == null)
                {
                    throw new GameFrameworkException("Resource is invalid.");
                }

                AssetObject assetObject = ReferencePool.Acquire<AssetObject>();
                assetObject.Initialize(name, target);
                assetObject.m_AssetHandle = (AssetHandle)assetHandle;
                return assetObject;
            }

            public override void Clear()
            {
                base.Clear();
                m_AssetHandle = null;
            }

            // protected override void OnUnspawn()
            // {
            //     base.OnUnspawn();
            // }

            protected override void Release(bool isShutdown)
            {
                if (!isShutdown)
                {
                    AssetHandle handle = m_AssetHandle;
                    if (handle is { IsValid: true })
                    {
                        handle.Dispose();
                    }
                    handle = null;
                }
            }
        }
    }
}
