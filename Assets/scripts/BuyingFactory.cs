using TMPro;
using UnityEngine;

public class BuyingFactory : MonoBehaviour
{
    [SerializeField] Factory factory;
    [SerializeField] int cost;
    [SerializeField] int produce;
    [SerializeField] TextMeshProUGUI CostText;
    [SerializeField] TextMeshProUGUI ProduceText;
    FactoryPlacement factoryPlacement;

    private void Start()
    {
        CostText.text = cost.ToString();
        ProduceText.text = produce.ToString();
        factoryPlacement = FindObjectOfType<FactoryPlacement>();
    }
    public void BuyFactory()
    {
        if (GameManager.instance.GetMoney() < cost) { return; }

        GameManager.instance.BuyFactory(cost, factory);
        factoryPlacement.SpawnFactory(factory.gameObject, cost);
    }
}
