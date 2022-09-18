using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBehavior : MonoBehaviour
{
    [SerializeField] PlayerMovementBehavior m_MovementBehavior;
    [SerializeField] PlayerBehavior m_PlayerBehavior;

    [SerializeField] Camera m_MainCamera;

    public void PlayerMove(InputAction.CallbackContext context)
    {
     
      m_MovementBehavior.Movement = context.ReadValue<Vector2>();

    }

    public void PlayerLook(InputAction.CallbackContext context)
    {
      
      m_MovementBehavior.CurrentMousePos = m_MainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void PlayerUse(InputAction.CallbackContext context)
    {
        m_PlayerBehavior.Use();
    }

}
