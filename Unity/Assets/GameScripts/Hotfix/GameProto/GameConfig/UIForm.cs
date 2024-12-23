
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace GameConfig
{
public sealed partial class UIForm : Luban.BeanBase
{
    public UIForm(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        AssetName = _buf.ReadString();
        UiGroupName = _buf.ReadString();
        AllowMultiInstance = _buf.ReadBool();
        PauseCoveredUiForm = _buf.ReadBool();
    }

    public static UIForm DeserializeUIForm(ByteBuf _buf)
    {
        return new UIForm(_buf);
    }

    /// <summary>
    /// 界面编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 资源名称
    /// </summary>
    public readonly string AssetName;
    /// <summary>
    /// 界面组名称
    /// </summary>
    public readonly string UiGroupName;
    /// <summary>
    /// 是否允许多个界面实例
    /// </summary>
    public readonly bool AllowMultiInstance;
    /// <summary>
    /// 是否暂停被其覆盖的界面
    /// </summary>
    public readonly bool PauseCoveredUiForm;
   
    public const int __ID__ = -1791876744;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "assetName:" + AssetName + ","
        + "uiGroupName:" + UiGroupName + ","
        + "allowMultiInstance:" + AllowMultiInstance + ","
        + "pauseCoveredUiForm:" + PauseCoveredUiForm + ","
        + "}";
    }
}

}

