using Cysharp.Threading.Tasks;
using YooAsset;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 资源组件。YooAsset特有的部分
    /// </summary>
    public sealed partial class ResourceComponent : GameFrameworkComponent
    {
        
        /// <summary>
        /// 获取或设置运行模式。
        /// </summary>
        EPlayMode PlayMode { get; set; }

        /// <summary>
        /// 缓存系统启动时的验证级别。
        /// </summary>
        EVerifyLevel VerifyLevel { get; set; }

        // /// <summary>
        // /// 初始化操作。
        // /// </summary>
        // /// <param name="packageName">资源包名称。</param>
        // UniTask<InitializationOperation> InitPackage(string packageName);
        
        // /// <summary>
        // /// 获取资源信息列表。
        // /// </summary>
        // /// <param name="resTag">资源标签。</param>
        // /// <param name="packageName">指定资源包的名称。不传使用默认资源包</param>
        // /// <returns>资源信息列表。</returns>
        // AssetInfo[] GetAssetInfos(string resTag, string packageName = "");
        //
        // /// <summary>
        // /// 获取资源信息列表。
        // /// </summary>
        // /// <param name="tags">资源标签列表。</param>
        // /// <param name="packageName">指定资源包的名称。不传使用默认资源包</param>
        // /// <returns>资源信息列表。</returns>
        // AssetInfo[] GetAssetInfos(string[] tags, string packageName = "");
        //
        // /// <summary>
        // /// 获取资源信息。
        // /// </summary>
        // /// <param name="location">资源的定位地址。</param>
        // /// <param name="packageName">指定资源包的名称。不传使用默认资源包</param>
        // /// <returns>资源信息。</returns>
        // AssetInfo GetAssetInfo(string location, string packageName = "");
    }   
}