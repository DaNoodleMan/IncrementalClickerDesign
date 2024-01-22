using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickCounter : MonoBehaviour
{
    private int points = 0; // Variable to store the points

    GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void OnButtonClick()
    {
        GameManager.instance.AddMoney(1);
    }
}
