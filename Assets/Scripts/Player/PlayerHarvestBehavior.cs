using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvestBehavior : MonoBehaviour
{

    //Cooldown system
    private float _UsageCooldown = 0.5f;
    private float _CurrentUsage = 0.0f;


    private bool _IsClicked = false;
    public bool IsClicked
    {
        get { return _IsClicked; }
        set { _IsClicked = value; }
    }

    public void Click()
    {

        _IsClicked = !_IsClicked;
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
    }
}
