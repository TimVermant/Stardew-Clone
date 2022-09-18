using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] GameObject m_Tool;
    private CircleCollider2D m_CircleCollider;


    //Cooldown system
    private float m_UsageCooldown = 0.5f;
    private float m_CurrentUsage = 0.0f;

    LayerMask m_HarvestLayer;
    


    private void Start()
    {
        m_CircleCollider = m_Tool.GetComponent<CircleCollider2D>();
        m_HarvestLayer = LayerMask.GetMask("Harvestables");
    }

    public void Use()
    {
        if (m_CurrentUsage == 0.0f)
        {
            if(m_CircleCollider.IsTouchingLayers(m_HarvestLayer))
            {
                Debug.Log("Touching crop");
            }
            m_CurrentUsage = m_UsageCooldown;
        }
    }

    private void Update()
    {
        if (m_CurrentUsage > 0.0f)
        {
            m_CurrentUsage -= Time.deltaTime;
        }
        if (m_CurrentUsage < 0.0f)
        {
            m_CurrentUsage = 0.0f;
        }
    }


}
