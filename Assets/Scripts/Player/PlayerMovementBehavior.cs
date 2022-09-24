using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed = 5.0f;
    [SerializeField] private Rigidbody2D _RigidBody;


    private Vector2 _Movement;
    public Vector2 Movement
    {
        get { return _Movement; }
        set { _Movement = value; }
    }

    private Vector3 _CurrMousePos;
    public Vector3 CurrentMousePos
    {
        get { return _CurrMousePos; }
        set { _CurrMousePos = value; }
    }


  

    void FixedUpdate()
    {
        _RigidBody.MovePosition(_RigidBody.position + _Movement * _MovementSpeed * Time.fixedDeltaTime);


        // Look at mouse pointer
        Vector3 rotation = _CurrMousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        _RigidBody.SetRotation(Quaternion.Euler(0f, 0f, rotZ));

    }
}
