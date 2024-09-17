using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

using UnityTimer;
public class bullet : MonoBehaviour
{
    [SerializeField] Rigidbody m_Rg;
    [SerializeField] int type_id;
    [SerializeField] int type_tag;

    public bool hasTriggered = false;

    public UnityTimer.Timer timer;

    public enum collisionType
    {
        to_map = 0,
    }

    public float lifeTimeMax;
    public bool IsActive;
    public Vector3 InitialPos, CurrentPos;
    public Quaternion InitialRot, CurrentRot;

    public System.Action<GameObject> OnEnableTrig;
    public void SetOnTrigCall(System.Action<GameObject> callbaack) => OnEnableTrig = callbaack;

    void OnEnable()
    {
        if (!hasTriggered)
        {
            SetOnTrigCall(delegate{ BulletEmit(this.gameObject); });
            OnEnableTrig(this.gameObject);
            hasTriggered = true;
        }
    }

    void BulletEmit(GameObject obj)
    {
        Quaternion _rot = player.Instance.transform.rotation;
        Vector3 _pos = player.Instance.transform.position;

        Debug.Log("rot is"+_rot);
        obj.transform.position = _pos + _rot * new Vector3(0, (float)0.7, 0);
        obj.transform.rotation = _rot;

        m_Rg.velocity = _rot * new Vector3(0, 10, 0);
    }

    void Awake()
    {

    }

    public void timercomplete()
    {
        bullet_manager.Instance.ResetObjActive("bullet", this.gameObject);
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