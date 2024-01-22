using TMPro;
using UnityEngine;

public class BuyingFactory : MonoBehaviour
{
    [SerializeField] Factory factory;
    [SerializeField] int cost;
    [SerializeField] int produce;
    [SerializeField] TextMeshProUGUI CostText;
    [SerializeField] TextMeshProUGUI ProduceText;
    GameManager gameManager;
    FactoryPlacement factoryPlacement;

    private void Start()
    {
        CostText.text = cost.ToString();
        ProduceText.text = produce.ToString();
        gameManager = FindObjectOfType<GameManager>();
        factoryPlacement = FindObjectOfType<FactoryPlacement>();
    }
    public void BuyFactory()
    {
        if (GameManager.instance.GetMoney() < cost) { return; }

        GameManager.instance.BuyFactory(cost, factory);
        gameManager.AddMoney(-cost);
        factoryPlacement.SpawnFactory(factory.gameObject);
    }
}
