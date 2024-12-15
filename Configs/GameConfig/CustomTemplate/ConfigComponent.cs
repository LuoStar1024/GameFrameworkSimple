using System;
using GameConfig;
using Luban;
using UnityGameFramework.Runtime;

namespace GameProto
{
    /// <summary>
    /// 配置加载器。
    /// </summary>
    public class ConfigComponent : GameFrameworkComponent
    {
        private enum CfgType
        {
            ByteBuf,
            Json,
        }
        
        private bool m_Init = false;
        private CfgType m_CfgType = CfgType.ByteBuf; // 默认使用二进制

        private Tables m_Tables;

        public Tables Tables
        {
            get
            {
                if (!m_Init)
                {
                    Load();
                }

                return m_Tables;
            }
        }

        /// <summary>
        /// 加载配置。
        /// </summary>
        public void Load()
        {
            // 根据cfg.Tables的构造函数的Loader的返回值类型决定使用json还是ByteBuf Loader
            Type tablesType = typeof(Tables);
            var loadMethodInfo = tablesType.GetMethod("SetDefaultLoader");
            if (loadMethodInfo == null)
            {
                m_CfgType = CfgType.ByteBuf;
            }
            var loaderReturnType = loadMethodInfo.GetParameters()[0].ParameterType.GetGenericArguments()[1];
            if (loaderReturnType == typeof(ByteBuf))
            {
                m_CfgType = CfgType.ByteBuf;
            }
            else
            {
                m_CfgType = CfgType.Json;
            }
            
            m_Tables = new Tables(LoadByteBuf);
            m_Init = true;
        }

        /// <summary>
        /// 加载二进制配置。
        /// </summary>
        /// <param name="file">FileName</param>
        /// <returns>ByteBuf</returns>
        private ByteBuf LoadByteBuf(string file)
        {
            return null;

            // TODO
            if (m_CfgType == CfgType.ByteBuf)
            {
                // TextAsset textAsset = GameModule.Resource.LoadAsset<TextAsset>(file);
                //
                // if (textAsset == null || textAsset.bytes == null)
                // {
                //     throw new GameFrameworkException($"LoadByteBuf failed: {file}");
                // }
                //
                // byte[] bytes = textAsset.bytes;
                //
                // GameModule.Resource.UnloadAsset(textAsset);
                //
                // return new ByteBuf(bytes);
            }
            else
            {
                // TextAsset textAsset = GameModule.Resource.LoadAsset<TextAsset>(file);
                //
                // if (textAsset == null || textAsset.bytes == null)
                // {
                //     throw new GameFrameworkException($"LoadJson failed: {file}");
                // }
                //
                // string text = textAsset.text;
                //
                // GameModule.Resource.UnloadAsset(textAsset);
                //
                // return text;
            }
        }
    }
}
