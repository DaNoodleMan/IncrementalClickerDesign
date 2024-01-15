using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPlacement : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float columDistance;
    [SerializeField] float rowDistance;
    [SerializeField] Vector2 startPos;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject parent;
    [SerializeField] int previewSize;

    int nextPosition = 30;

    // Start is called before the first frame update
    void Start()
    {
        int currentCol = nextPosition % columns - 1;
        int currentRow = Mathf.FloorToInt(nextPosition / columns);
        print(currentCol + "," + currentRow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnFactory(GameObject factory)
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.matrix = canvas.transform.localToWorldMatrix;
        Gizmos.color = Color.white;
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < columns; colIndex++)
            {
                Vector2 spawnPosition = new Vector2(startPos.x + (colIndex * columDistance), startPos.y + (-rowIndex * rowDistance)) + (Vector2)transform.localPosition;
                Gizmos.DrawCube((Vector3)spawnPosition, Vector3.one * 20);
            }
        }
    }
}
