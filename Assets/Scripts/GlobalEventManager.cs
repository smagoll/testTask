using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent UpdateTickets = new();
    public static UnityEvent<float> UpdateProgressBar = new();
    public static UnityEvent ResetWeeklyBonus = new();
    public static UnityEvent PlaySFXButton = new();

    public static void Start_UpdateTickets()
    {
        UpdateTickets.Invoke();
    }

    public static void Start_ResetWeeklyBonus()
    {
        ResetWeeklyBonus.Invoke();
    }
    
    public static void Start_PlaySFXButton()
    {
        PlaySFXButton.Invoke();
    }
    
    public static void Start_UpdateProgressBar(float currentDay)
    {
        UpdateProgressBar.Invoke(currentDay);
    }
}
