using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class DayBonus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textNumberDay;
    [SerializeField]
    private TextMeshProUGUI textCountTickets;

    [SerializeField]
    private Button button;
    [SerializeField]
    private SVGImage svgImage;
    [SerializeField]
    private Color colorComplete;

    public int numberDay;
    [SerializeField]
    private int countTicket;
    private bool isComplete = false;
    private bool isAccess = false;

    public bool IsComplete
    {
        get { return isComplete; }
        set
        {
            isComplete = value;
            if (isComplete)
            {
                button.interactable = false;
                svgImage.color = colorComplete;
            }
        }
    }
    
    public bool IsAccess
    {
        get { return isAccess; }
        set
        {
            isAccess = value;
            if (isAccess)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }

    private void Start()
    {
        textNumberDay.text = $"DAY{numberDay}";
        textCountTickets.text = $"X{countTicket}";
    }

    public void TakeBonus()
    {
        GlobalEventManager.Start_PlaySFXButton();
        GameManager.Tickets += countTicket;
        IsComplete = true;
    }

    public void ResetColor()
    {
        svgImage.color = Color.white;
    }
}
