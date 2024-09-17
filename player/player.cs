using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityCreature;
using UnityTimer;
using UnityInterface;

public class player : Creature
{
    public Timer timer;
    public playerInterface controlInterface;

    public static player Instance;
    void Awake() => Instance = this;

    void topTowardMouse()
    {
        Vector3 _mousePosition = playerInterface.Instance.mousePositionVector;
        Vector3 _playerPosition = m_Rb.position;

        float _errAngle = Mathf.Atan2((_mousePosition.x - _playerPosition.x), (_mousePosition.y - _playerPosition.y)) * 180f / 3.14f;
        _errAngle = _errAngle <= 0 ? -_errAngle : -_errAngle + 360;

        m_angle = _errAngle;

        m_Rb.rotation = Quaternion.Euler(0, 0, m_angle);
    }

    void Start()
    {
        creatureInit();
        // timer = Timer.Register(0.01f, state_update, isLooped: true);
    }

    void MouseControl_forward()
    {
        bool _mouse_get_left = Input.GetMouseButton(0);
        bool _mouse_get_right = Input.GetMouseButton(1);

        if (_mouse_get_left == true)
        {
            m_Rb.velocity = m_Rb.rotation * new Vector3(0, 8, 0);
        }
        if (_mouse_get_right == true)
        {
            m_Rb.velocity = m_Rb.rotation * new Vector3(0, -8, 0);
        }

        if (_mouse_get_left == false && _mouse_get_right == false)
        {
            m_Rb.velocity = m_Rb.rotation * new Vector3(0, 0, 0);
        }
    }

    // !每帧更新
    void Update()
    {
        creatureUpdate();

        topTowardMouse();
        MouseControl_forward();

    }





}

