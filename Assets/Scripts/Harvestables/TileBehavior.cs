using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    enum TileType { ground, crop, water };

    private TileType _TileType = TileType.ground;

    [SerializeField] private Color _DefaultColor = Color.magenta;
    [SerializeField] private Color _SelectedColor = Color.green;
    [SerializeField] private SpriteRenderer _Renderer;


    private void Start()
    {
        _Renderer.material.color = _DefaultColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerHarvestBehavior>() != null)
            _Renderer.material.color = _SelectedColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHarvestBehavior>() != null)
            _Renderer.material.color = _DefaultColor;
    }

}

