using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    enum TileType { ground, crop, water };

    private TileType _TileType = TileType.ground;
    private bool _TileSelected = false;



    [SerializeField] private SpriteRenderer _Renderer;
    private Color _DefaultColor = Color.magenta;
    private Color _SelectedColor = Color.green;



    private void Start()
    {
        int randomNr = Random.Range(0, 3);
        _TileType = (TileType)randomNr;
        switch (_TileType)
        {
            case TileType.ground:
                _DefaultColor = new Color(154 / 255.0f, 77 / 255.0f, 18 / 255.0f);
                _SelectedColor = new Color(199 / 255.0f, 77 / 255.0f, 18 / 255.0f);
                break;
            case TileType.crop:
                _DefaultColor = new Color(107 / 255.0f, 210 / 255.0f, 18 / 255.0f);
                _SelectedColor = new Color(66 / 255.0f, 126 / 255.0f, 16 / 255.0f);
                break;
            case TileType.water:
                _DefaultColor = new Color(30 / 255.0f, 10 / 255.0f, 209 / 255.0f);
                _SelectedColor = new Color(30 / 255.0f, 10 / 255.0f, 135 / 255.0f);
                break;
            default:
                break;
        }
        _Renderer.material.color = _DefaultColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHarvestBehavior playerHarvest = collision.GetComponent<PlayerHarvestBehavior>();
        if (playerHarvest != null)
        {
            _Renderer.material.color = _SelectedColor;
            _TileSelected = true;
            if (playerHarvest.IsClicked)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHarvestBehavior>() != null)
        {

            _Renderer.material.color = _DefaultColor;
            _TileSelected = false;
        }
    }

}

