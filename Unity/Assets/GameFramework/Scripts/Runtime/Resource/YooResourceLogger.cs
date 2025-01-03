namespace UnityGameFramework.Runtime
{
    internal class YooResourceLogger : YooAsset.ILogger
    {
        public void Log(string message)
        {
            UnityGameFramework.Runtime.Log.Info(message);
        }

        public void Warning(string message)
        {
            UnityGameFramework.Runtime.Log.Warning(message);
        }

        public void Error(string message)
        {
            UnityGameFramework.Runtime.Log.Error(message);
        }

        public void Exception(System.Exception exception)
        {
            UnityGameFramework.Runtime.Log.Fatal(exception.Message);
        }
    }   
}
