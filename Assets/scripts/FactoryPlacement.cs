using UnityEngine;

public class FactoryPlacement : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float columDistance;
    [SerializeField] float rowDistance;
    [SerializeField] float corridorLeft;
    [SerializeField] float corridorRight;
    [SerializeField] Vector2 startPos;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject parent;
    [SerializeField] int previewSize;

    int nextPosition;
    
    public void SpawnFactory(GameObject factory, int cost)
    {
        int currentCol = nextPosition % columns;
        int currentRow = -Mathf.FloorToInt(nextPosition / columns);
        
        GameObject placedFactory = Instantiate(factory, parent.transform);
        Vector3 spawnPos = new Vector3(currentCol * columDistance, currentRow * rowDistance, 0) + (Vector3)startPos;
        placedFactory.GetComponent<RectTransform>().localPosition = spawnPos;
        placedFactory.GetComponent<Factory>().SetCost(cost);
        nextPosition++;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.matrix = canvas.transform.localToWorldMatrix;
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(corridorLeft, startPos.y + (-rowIndex * rowDistance) + transform.localPosition.y - rowDistance * 0.5f), new Vector2(corridorRight, startPos.y + (-rowIndex * rowDistance) + transform.localPosition.y - rowDistance* 0.5f));

            for (int colIndex = 0; colIndex < columns; colIndex++)
            {
                Vector2 spawnPosition = new Vector2(startPos.x + (colIndex * columDistance), startPos.y + (-rowIndex * rowDistance)) + (Vector2)transform.localPosition;
                Gizmos.color = Color.white;
                Gizmos.DrawCube((Vector3)spawnPosition, Vector3.one * 20);
            }
        }
    }
}
