using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField] private float m_MovementSpeed = 5.0f;
    [SerializeField] private Rigidbody2D m_Rigidbody;


    private Vector2 m_Movement;
    public Vector2 Movement
    {
        get { return m_Movement; }
        set { m_Movement = value; }
    }

    private Vector3 m_CurrMousePos;
    public Vector3 CurrentMousePos
    {
        get { return m_CurrMousePos; }
        set { m_CurrMousePos = value; }
    }


  

    void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_MovementSpeed * Time.fixedDeltaTime);


        // Look at mouse pointer
        Vector3 rotation = m_CurrMousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        m_Rigidbody.SetRotation(Quaternion.Euler(0f, 0f, rotZ));

    }
}
