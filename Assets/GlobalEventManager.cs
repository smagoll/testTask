using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent UpdateTickets = new();

    public static void Start_UpdateTickets()
    {
        UpdateTickets.Invoke();
    }
}
