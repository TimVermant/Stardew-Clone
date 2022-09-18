using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerBehavior : MonoBehaviour
{
    private List<Rect> m_LevelGrid;
    [SerializeField] private int m_CellSize = 1;
    [SerializeField] private GameObject m_TilePrefab;
    [SerializeField] private Camera m_MainCamera;

    private void Start()
    {
        m_LevelGrid = new List<Rect>();
        int width = m_MainCamera.pixelWidth / m_CellSize;
        int height = m_MainCamera.pixelHeight / m_CellSize;
        Vector2Int windowPos = new Vector2Int(-width/2,-height/2);
        for (int i = 0; i < width/2; i++)
        {
            for (int j = 0; j < height/2; j++)
            {
                Rect rect = new Rect(windowPos.x + i * m_CellSize, windowPos.y +  j * m_CellSize, m_CellSize, m_CellSize);
                m_LevelGrid.Add(rect);
                Instantiate(m_TilePrefab, rect.position,new Quaternion());
            }
        }

    }
}
