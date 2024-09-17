using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class bullet_manager : ObjectPool
{
    public static bullet_manager Instance;
    void Awake() => Instance = this;


    public new void SetObjActive(string _tag_prefab)
    {
        pools.TryGetValue(_tag_prefab, out Stack<GameObject> _pool);
        GameObject _obj = _pool.Pop();
        _obj.GetComponent<bullet>().hasTriggered = false;
        _obj.SetActive(true);

        // _bullet.timer = UnityTimer.Timer.Register(2, _bullet.timercomplete);
    }

    public new void ResetObjActive(string _tag_prefab, GameObject _obj)
    {
        pools.TryGetValue(_tag_prefab, out Stack<GameObject> _pool);
        _obj.SetActive(false);
        _pool.Push(_obj);

        bullet _bullet = _obj.GetComponent<bullet>();
        _bullet.hasTriggered = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        PoolsInit();
    }


    // Update is called once per frame
    void Update()
    {

    }
}