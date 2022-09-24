using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerBehavior : MonoBehaviour
{
    private List<GameObject> _LevelGrid;

    [SerializeField] private int _CellSize = 1;
    [SerializeField] private int _GridSize = 15;

    [SerializeField] private GameObject _TilePrefab;
    [SerializeField] private Camera _MainCamera;


    private void Start()
    {
        _LevelGrid = new List<GameObject>();
        int width = _MainCamera.pixelWidth / _CellSize;
        int height = _MainCamera.pixelHeight / _CellSize;
        //Vector2Int windowPos = new Vector2Int(-width / 2, -height / 2);
        Vector2Int windowPos = new Vector2Int(-_GridSize / 2, -_GridSize / 2);
        for (int i = 0; i < _GridSize; i++)
        {
            for (int j = 0; j < _GridSize; j++)
            {
                Rect rect = new Rect(windowPos.x + i * _CellSize, windowPos.y + j * _CellSize, _CellSize, _CellSize);

                _LevelGrid.Add(Instantiate(_TilePrefab, rect.position, new Quaternion()));
            }
        }
        
    }
}
