using GameFramework.Resource;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public abstract class YooResourceLoadHelperBase : MonoBehaviour,IResourceLoadHelper
    {
        public abstract HasAssetResult HasAsset(string assetName);

        public abstract void LoadAsset(string location, int priority, LoadAssetCallbacks loadAssetCallbacks,
            object userData,
            string packageName = "");

        public abstract void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks,
            object userData);

        public abstract void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks,
            object userData);
    }
}
