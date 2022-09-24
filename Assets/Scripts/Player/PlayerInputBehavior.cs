using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBehavior : MonoBehaviour
{
    [SerializeField] PlayerMovementBehavior _MovementBehavior;
    [SerializeField] PlayerBehavior _PlayerBehavior;

    [SerializeField] Camera _MainCamera;

    public void PlayerMove(InputAction.CallbackContext context)
    {
     
      _MovementBehavior.Movement = context.ReadValue<Vector2>();

    }

    public void PlayerLook(InputAction.CallbackContext context)
    {
      
      _MovementBehavior.CurrentMousePos = _MainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void PlayerUse(InputAction.CallbackContext context)
    {
        _PlayerBehavior.Use();
        
    }

}
