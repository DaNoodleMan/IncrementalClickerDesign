using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int money;
    float clickMultiplier = 1;

    public TMP_Text pointDisplay;

    void Start()
    {
        
    }

    void Update()
    {
        if (pointDisplay != null)
        {
            pointDisplay.text = "Money: " + money.ToString();
        }
    }

    public void ClickMoney()
    {
        money = Mathf.FloorToInt(money * clickMultiplier);
    }

    public void AddMoney(int addedMoney) 
    {
        money += addedMoney;
        
    }
}
