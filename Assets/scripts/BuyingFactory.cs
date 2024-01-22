using UnityEngine;

public class BuyingFactory : MonoBehaviour
{
    [SerializeField] GameObject factory;
    [SerializeField] int cost;
    GameManager gameManager;
    FactoryPlacement factoryPlacement;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        factoryPlacement = FindObjectOfType<FactoryPlacement>();
    }
    public void BuyFactory()
    {
        gameManager.AddMoney(-cost);
        factoryPlacement.SpawnFactory(factory);
    }
}
