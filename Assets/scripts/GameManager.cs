using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int money;
    float clickMultiplier = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
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
