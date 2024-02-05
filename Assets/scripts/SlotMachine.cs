using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] float fullRowWinMultiplier;
    [SerializeField] float parcialRowWinMultiplier;
    [SerializeField] float jackpotwWinMultiplier;
    [SerializeField] int possibleSlots;
    [SerializeField] List<Image> sprites = new List<Image>();
    [SerializeField] TMP_InputField betInput;
    [SerializeField] Sprite[] slotSprites;

    public void Play()
    {

        if(!int.TryParse(betInput.text ,out int bet))
        {
            print("failed");
            betInput.text = "Invalid amount";
            return;
        }
        if(bet > GameManager.instance.GetMoney()) { return; }
        print("succes");
        GameManager.instance.AddMoney(-bet);
        List<int> slots = new List<int>();
        bool canWin = true;
        bool winTroughStreak = false;
        bool jackpot = true;
        int currentStreak = -1;

        for (int index = 0; index < sprites.Count; index++)
        {
            slots.Add(Random.Range(0, possibleSlots));
            int slotNumber = slots[index];
            sprites[index].sprite = slotSprites[slotNumber];
            if (slotNumber == 0)
            {
                if(currentStreak == 0)
                {
                    print(index);
                    winTroughStreak = true;
                }
                currentStreak = slots[index];
            }
            else
            {
                currentStreak = -1;
            }
            
            if (slots[0] != slotNumber)
            {
                canWin = false;
            }

        }
        foreach(int slot in slots)
        {
            if(slot != 3)
            {
                jackpot = false; break;
            }
        }

        if(jackpot)
        {
            GameManager.instance.AddMoney(Mathf.RoundToInt(bet * jackpotwWinMultiplier));
            print(jackpot);
        }
        else if (canWin)
        {
            GameManager.instance.AddMoney(Mathf.RoundToInt(bet * fullRowWinMultiplier));
        }
        else if(winTroughStreak)
        {
            print("streak");
            GameManager.instance.AddMoney(Mathf.RoundToInt(bet * parcialRowWinMultiplier));
        }
    }

    private void OnDrawGizmosSelected()
    {
        print(jackpotwWinMultiplier + fullRowWinMultiplier * 4 +  parcialRowWinMultiplier * 10);
    }
}
