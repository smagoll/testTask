using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class ItemDonat : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countTickets;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private GameObject iapButton;

    public void BuyTickets(Product product)
    {
        GameManager.Tickets += Convert.ToInt32(product.definition.payout.quantity);
    }

    [Obsolete]
    public void Start()
    {
        var productId = iapButton.GetComponent<CodelessIAPButton>().productId;
        var product = CodelessIAPStoreListener.Instance.GetProduct(productId);
        itemName.text = $"[{product.metadata.localizedTitle}]";
        countTickets.text = product.definition.payout.quantity.ToString();
    }
}
