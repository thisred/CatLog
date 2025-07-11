
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace ET
{
[Config]
public partial class UnitConfigCategory: Singleton<UnitConfigCategory>
{
    private readonly System.Collections.Generic.Dictionary<int, UnitConfig> _dataMap;
    private readonly System.Collections.Generic.List<UnitConfig> _dataList;
    
    public UnitConfigCategory(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, UnitConfig>();
        _dataList = new System.Collections.Generic.List<UnitConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            UnitConfig _v;
            _v = global::ET.UnitConfig.DeserializeUnitConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public System.Collections.Generic.Dictionary<int, UnitConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<UnitConfig> DataList => _dataList;

    public UnitConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public UnitConfig Get(int key) => _dataMap[key];
    public UnitConfig this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
        PostResolve();
    }

    partial void PostInit();
    partial void PostResolve();
}

}
