using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] int cashPerSecond;
    [SerializeField] float tickSpeed;
    [Range(0, 1)] float chanceOfTheft;
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
}
