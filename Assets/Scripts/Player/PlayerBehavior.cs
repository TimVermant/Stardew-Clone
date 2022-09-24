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
    private BoxCollider2D _HarvestCollider;

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
        _HarvestCollider = _HarvestSquareObject.GetComponent<BoxCollider2D>();  

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

        
        // Disable when mouse is too far
        float maxDistance = 10.0f;

        float distance = Vector3.Distance(_HarvestSquareObject.transform.position, transform.position );
       // Debug.Log(_HarvestSquareObject.transform.position);
        Debug.Log(transform.position);
        Debug.Log(distance);
        _HarvestCollider.enabled = distance < maxDistance;

    }


}
