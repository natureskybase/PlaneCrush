using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityPID;
using UnityTimer;

namespace UnityCreature
{
    public class Creature : MonoBehaviour
    {
        // >组件的存储变量
        public Rigidbody m_Rb;

        // >物体的世界坐标位置信息
        [Header("[自身位置参数]")]
        public Vector3 m_Position;
        public float m_angle;

        // >物体的自身坐标系参数
        [Header("[运动参数]")]
        public Vector3 m_Volocity;
        public float m_torque;

        private void getAngle()
        {
            Quaternion _q = m_Rb.rotation;
            m_angle = _q.eulerAngles.z;
        }

        /// <summary>
        /// 更新物体的各种参数信息
        /// </summary>
        public void informationUpdate()
        {
            m_Position = m_Rb.position;
            getAngle();
        }

        public void creatureInit()
        {
            // 获取刚体
            m_Rb = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// 进行数据的更新
        /// </summary>
        public void creatureUpdate()
        {
            informationUpdate();
        }
    }
}