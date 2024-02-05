using System;
using System.Collections;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] int cashPerSecond;

    [SerializeField] float tickSpeed;
    [Range(0, 1)] float chanceOfTheft;
    int cost;
    GameManager gameManager;
    int cashPerTick;
    private void Start()
    {
        cashPerTick = Mathf.RoundToInt(cashPerSecond * tickSpeed);
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(CountTick());
    }
    
    public IEnumerator CountTick() 
    {
        while (true) 
        { 
            yield return new WaitForSeconds(tickSpeed);
            Tick();
        }
    }

    void Tick()
    {
        gameManager.AddMoney(cashPerTick);
    }

    public int GetCashPerSecond() 
    {
        return cashPerSecond;
    }

    public void Sell()
    {
        gameManager.AddMoney(cost);
        Destroy(gameObject);
    }

    public void SetCost(int newCost)
    {
        cost = newCost;
    }
}
