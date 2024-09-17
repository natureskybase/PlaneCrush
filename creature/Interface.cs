using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterface
{
    public class playerInterface : MonoBehaviour
    {
        public Camera m_camera;

        // 创建静态实例
        public static playerInterface Instance;

        // [Header("【鼠标信息】")]
        public Vector3 mousePositionVector = Vector3.zero;
        // public Vector3 mousePositionVector { get; set; } = Vector3.zero;


        void Awake() => Instance = this;

        void Start()
        {
            // 获取该脚本对应相机的实例
            m_camera = Camera.main;
            Application.targetFrameRate = 200;
        }

        public Vector3 getMousePosition()
        {
            mousePositionVector = Input.mousePosition;
            mousePositionVector = m_camera.ScreenToWorldPoint(mousePositionVector);
            mousePositionVector.z = 0f; // 对世界坐标系的z轴进行修正
            return mousePositionVector;
        }

        void Update()
        {
            this.getMousePosition();
        }
    }
}