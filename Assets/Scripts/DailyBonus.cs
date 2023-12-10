using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DailyBonus : WindowManager
{
    [SerializeField]
    private GameObject giftBonusWindow;
    [SerializeField]
    private GameObject dailyBonusWindow;
    [SerializeField]
    private Image fade;
    [SerializeField]
    private GiftBonus gift;
    [SerializeField]
    private ProgressBar progressBar;
    [SerializeField]
    private float maxDays;
    [SerializeField]
    private DayBonus[] daysBonus;


    private static float currentDay = 1;

    public static float CurrentDay
    {
        get { return currentDay; }
        set
        {
            currentDay = value;
        }
    }

    private void Awake()
    {
        GlobalEventManager.ResetWeeklyBonus.AddListener(ResetWeeklyBonus);
    }

    private void Start()
    {
        progressBar.SetMaxDays(maxDays, currentDay);
        daysBonus.OrderBy(x => x.numberDay);
        foreach (var day in daysBonus)
        {
            if (day.numberDay <= currentDay)
            {
                day.IsAccess = true;
            }
        }
    }

    public void TransitionToNextDay()
    {
        if (currentDay < maxDays)
        {
            var dayBonus = daysBonus.Where(x => x.numberDay == currentDay).ToArray().FirstOrDefault();
            dayBonus.IsAccess = true;
        }
        else
        {
            gift.IsAccess = true;
        }

    }

    private void OnDisable()
    {
        
        giftBonusWindow.SetActive(false);
        dailyBonusWindow.SetActive(true);

        if (CurrentDay < maxDays)
        {
            CurrentDay++;
        }
    }

    private void OnEnable()
    {
        
        TransitionToNextDay();
        GlobalEventManager.Start_UpdateProgressBar(currentDay);
    }

    private void ResetWeeklyBonus()
    {
        gift.IsAccess = false;
        CurrentDay = 0;
        foreach (var day in daysBonus)
        {
            day.ResetColor();
            day.IsAccess = false;
        }
        return;
    }

    public override void Disable()
    {
        var sequence = DOTween.Sequence();
        fade.raycastTarget = false;

        sequence.Append(transform.DOScale(new Vector3(0f, 0f, 0f), 0.3f));
        sequence.AppendCallback(() =>
        {
            gameObject.SetActive(false);
            fade.gameObject.SetActive(false);
            sequence.Kill();
        });
    }

    public override void Enable()
    {
        transform.localScale = new Vector3(0,0,0);
        var sequence = DOTween.Sequence();
        gameObject.SetActive(true);
        fade.gameObject.SetActive(true);
        fade.raycastTarget = true;

        sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.3f));
        sequence.AppendCallback(() =>
        {
            sequence.Kill();
        });
    }
}
