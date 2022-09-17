using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_MovementSpeed = 5.0f;
    [SerializeField] private Rigidbody2D m_Rigidbody;


    Vector2 m_Movement;

    public void MovePlayer(InputAction.CallbackContext context)
    {
        m_Movement = context.ReadValue<Vector2>();

        Debug.Log(m_Movement);

    }

    void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_MovementSpeed * Time.fixedDeltaTime);
       
    }
}
