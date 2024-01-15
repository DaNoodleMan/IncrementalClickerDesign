using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickCounter : MonoBehaviour
{
    public TMP_Text pointDisplay; // Reference to the Text component to display points
    private int points = 0; // Variable to store the points

    GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void OnButtonClick()
    {
        
        points++;
        
        UpdatePointDisplay();
    }

    // Update the Text component to display the current points
    private void UpdatePointDisplay()
    {
        if (pointDisplay != null)
        {
            pointDisplay.text = "Money: " + points.ToString();
        }

        gameManager.AddMoney(+1);
    }
}
