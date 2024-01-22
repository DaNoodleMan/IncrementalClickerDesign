using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    public int money;
    float clickMultiplier = 1;
    List<Factory> factories;

    public TextMeshProUGUI pointDisplay;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        pointDisplay.text = "Money: " + money.ToString();
    }

    public void ClickMoney()
    {
        money = Mathf.FloorToInt(money * clickMultiplier);
        UpdateDisplay();
    }

    public void AddMoney(int addedMoney) 
    {
        money += addedMoney;
        UpdateDisplay();
    }

    public int GetMoney()
    {
        return money;
    }

    public void BuyFactory(int cost, Factory factory)
    {
        factories.Add(factory);
        AddMoney(-cost);
    }

}
