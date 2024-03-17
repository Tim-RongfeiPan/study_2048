using UnityEngine;

public class TileRow : MonoBehaviour
{
    public TileCell[] cells {  get; set; }// 当前行所管辖的单元格
    // { get; private set; } 的意思是，允许别的类使用这个成员，但不允许修改
    
    private void Awake()
    {
        // 通过获取子节点中所有带有TileCell的对象
        cells = GetComponentsInChildren<TileCell>();
    }

}

