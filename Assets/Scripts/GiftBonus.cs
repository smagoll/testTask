using DG.Tweening;
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
    private Tweener tweenerShake;

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
                tweenerShake.Play();
            }
            else
            {
                GetComponent<Button>().interactable = false;
                tweenerShake.Pause();
            }
        }
    }

    private void Start()
    {
        textCountTickets.text = $"X{countTickets}";

        tweenerShake = transform.DOShakePosition(1f, 0.5f).SetLoops(-1);
        tweenerShake.Pause();
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
