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

    int nextPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnFactory(GameObject factory)
    {
        print(nextPosition);
        int currentCol = nextPosition % columns;
        int currentRow = -Mathf.FloorToInt(nextPosition / columns);
        print(currentCol + ","+currentRow);
        
        GameObject placedFactory = Instantiate(factory, parent.transform);
        Vector3 spawnPos = new Vector3(currentCol * columDistance, currentRow * rowDistance, 0) + (Vector3)startPos;
        print(spawnPos);
        placedFactory.GetComponent<RectTransform>().localPosition = spawnPos;
        nextPosition++;

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
