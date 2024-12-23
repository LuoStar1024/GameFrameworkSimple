
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
public sealed partial class Weapon : Luban.BeanBase
{
    public Weapon(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Attack = _buf.ReadInt();
        AttackInterval = _buf.ReadFloat();
        BulletId = _buf.ReadInt();
        BulletSpeed = _buf.ReadFloat();
        BulletSoundId = _buf.ReadInt();
    }

    public static Weapon DeserializeWeapon(ByteBuf _buf)
    {
        return new Weapon(_buf);
    }

    /// <summary>
    /// 武器编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 攻击力
    /// </summary>
    public readonly int Attack;
    /// <summary>
    /// 攻击间隔
    /// </summary>
    public readonly float AttackInterval;
    /// <summary>
    /// 子弹编号
    /// </summary>
    public readonly int BulletId;
    /// <summary>
    /// 子弹速度
    /// </summary>
    public readonly float BulletSpeed;
    /// <summary>
    /// 子弹声音编号
    /// </summary>
    public readonly int BulletSoundId;
   
    public const int __ID__ = -1707954628;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "attack:" + Attack + ","
        + "attackInterval:" + AttackInterval + ","
        + "bulletId:" + BulletId + ","
        + "bulletSpeed:" + BulletSpeed + ","
        + "bulletSoundId:" + BulletSoundId + ","
        + "}";
    }
}

}

