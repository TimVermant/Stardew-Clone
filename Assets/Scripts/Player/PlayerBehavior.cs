using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] PlayerMovementBehavior m_MovementBehavior;

    [SerializeField] GameObject m_HarvestSquarePrefab;
    [SerializeField] GameObject m_Tool;
    private CircleCollider2D m_CircleCollider;
    private GameObject m_HarvestSquareObject;

    //Cooldown system
    private float m_UsageCooldown = 0.5f;
    private float m_CurrentUsage = 0.0f;

    LayerMask m_HarvestLayer;


    private bool m_UsePerformed = false;
    private bool m_Clicked = false;

    private void Start()
    {
        m_HarvestSquareObject = Instantiate(m_HarvestSquarePrefab);
        m_CircleCollider = m_Tool.GetComponent<CircleCollider2D>();


        m_HarvestLayer = LayerMask.GetMask("Harvestables");
    }

    public void Use()
    {
        if (m_CurrentUsage == 0.0f)
        {

            m_Clicked = !m_Clicked;
            Debug.Log(m_Clicked);

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

        m_HarvestSquareObject.transform.position = new Vector3(m_MovementBehavior.CurrentMousePos.x, m_MovementBehavior.CurrentMousePos.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
