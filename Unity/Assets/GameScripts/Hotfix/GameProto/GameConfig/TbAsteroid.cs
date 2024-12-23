
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
public partial class TbAsteroid
{
    private readonly System.Collections.Generic.Dictionary<int, Asteroid> _dataMap;
    private readonly System.Collections.Generic.List<Asteroid> _dataList;
    
    public TbAsteroid(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Asteroid>();
        _dataList = new System.Collections.Generic.List<Asteroid>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Asteroid _v;
            _v = Asteroid.DeserializeAsteroid(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Asteroid> DataMap => _dataMap;
    public System.Collections.Generic.List<Asteroid> DataList => _dataList;

    public Asteroid GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Asteroid Get(int key) => _dataMap[key];
    public Asteroid this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

