using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.VisualScripting;
using System;

public class Main : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("main start");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // for(int i=0;i<10;i++)
        // {
        //     GameObject obj = GameObject.Instantiate(prefabs);
        //     obj.SetActive(false);
        // }
    }
    // Update is called once per frame
    void Update()
    {
        var debug_key = Input.GetKeyDown(KeyCode.W);
        if (debug_key == true)
        {
            // transform.position = new Vector3(3, 2, 0);
            bullet_manager.Instance.SetObjActive("bullet");
        }
    }
}
