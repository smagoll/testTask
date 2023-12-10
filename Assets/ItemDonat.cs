using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ItemDonat : MonoBehaviour
{
    [SerializeField]
    private int countTickets;

    public void BuyTickets(Product product)
    {
        GameManager.Tickets += Convert.ToInt32(product.definition.payout.quantity);
    }
}
