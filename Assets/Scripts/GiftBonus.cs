using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject giftBonusWindow;
    [SerializeField]
    private GameObject dailyBonusWeeklyWindow;
    [SerializeField]
    private TextMeshProUGUI textCountTickets;
    [SerializeField]
    private int countTickets;

    private bool isAccess = false;

    public bool IsAccess
    {
        get { return isAccess; }
        set
        {
            isAccess = value;
            if (isAccess)
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }

    private void Start()
    {
        textCountTickets.text = $"X{countTickets}";
    }

    public void TakeGift()
    {
        GlobalEventManager.Start_PlaySFXButton();
        giftBonusWindow.SetActive(true);
        dailyBonusWeeklyWindow.SetActive(false);
        GameManager.Tickets += countTickets;
        GlobalEventManager.Start_ResetWeeklyBonus();
    }
}
