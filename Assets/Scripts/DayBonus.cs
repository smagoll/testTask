using DG.Tweening;
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

    private Tweener tweenerShake;

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
                tweenerShake.Pause();
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
                tweenerShake.Play();
            }
            else
            {
                button.interactable = false;
                tweenerShake.Pause();
            }
        }
    }

    private void Start()
    {
        textNumberDay.text = $"DAY{numberDay}";
        textCountTickets.text = $"X{countTicket}";

        tweenerShake = transform.DOShakePosition(1f, 0.5f).SetLoops(-1);
        tweenerShake.Pause();
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
