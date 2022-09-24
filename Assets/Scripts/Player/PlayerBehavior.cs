using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] PlayerMovementBehavior _MovementBehavior;

    [SerializeField] GameObject _HarvestBehavior;
    [SerializeField] GameObject _Tool;
    private CircleCollider2D _CircleCollider;
    private GameObject _HarvestSquareObject;

    //Cooldown system
    private float _UsageCooldown = 0.5f;
    private float _CurrentUsage = 0.0f;

    LayerMask _HarvestLayer;


    private bool _UsePerformed = false;
    private bool _Clicked = false;

    private void Start()
    {
        _HarvestSquareObject = Instantiate(_HarvestBehavior);
        _CircleCollider = _Tool.GetComponent<CircleCollider2D>();


        _HarvestLayer = LayerMask.GetMask("Harvestables");
    }

    public void Use()
    {
        if (_CurrentUsage == 0.0f)
        {

            _Clicked = !_Clicked;
           // Debug.Log(_Clicked);

        }
    }

    private void Update()
    {
        if (_CurrentUsage > 0.0f)
        {
            _CurrentUsage -= Time.deltaTime;
        }
        if (_CurrentUsage < 0.0f)
        {
            _CurrentUsage = 0.0f;
        }

        _HarvestSquareObject.transform.position = new Vector3(_MovementBehavior.CurrentMousePos.x, _MovementBehavior.CurrentMousePos.y);
    }

  
}
