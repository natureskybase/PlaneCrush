using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class ObjectPool : MonoBehaviour
{
    // public static ObjectPool Instance;
    // void Awake() => Instance = this;

    [System.Serializable]
    public class pool_def
    {
        public string tag_prefab;
        public GameObject obj_prefab;
        public int num;
    }
    public List<pool_def> pools_def;

    public Dictionary<string, Stack<GameObject>> pools;
    public List<Stack<GameObject>> pools_list;

    public System.Action<GameObject> SetObjState;
    public void SetObjStateCall(System.Action<GameObject> callbaack) => SetObjState = callbaack;

    public void PoolsInit()
    {
        pools = new Dictionary<string, Stack<GameObject>>(pools_def.Count);
        foreach (pool_def _pool_def in pools_def)
        {
            Stack<GameObject> _pool = new Stack<GameObject>(_pool_def.num);

            for (int i = 0; i < _pool_def.num; i++)
            {
                GameObject _obj = Instantiate(_pool_def.obj_prefab, transform);
                _obj.tag = _pool_def.tag_prefab;
                _obj.SetActive(false);
                _pool.Push(_obj);
            }

            pools.Add(_pool_def.tag_prefab, _pool);

        }
    }

    public void SetObjActive(string _tag_prefab)
    {
        pools.TryGetValue(_tag_prefab, out Stack<GameObject> _pool);
        GameObject _obj = _pool.Pop();
        _obj.SetActive(true);
    }

    public void ResetObjActive(string _tag_prefab, GameObject _obj)
    {
        pools.TryGetValue(_tag_prefab, out Stack<GameObject> _pool);
        _obj.SetActive(false);
        _pool.Push(_obj);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
