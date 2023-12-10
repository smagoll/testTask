using System.Linq;
using UnityEngine;

public class DailyBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject giftBonusWindow;
    [SerializeField]
    private GameObject dailyBonusWindow;
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
        if (currentDay <= maxDays-1)
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

        if (CurrentDay == maxDays)
        {
            return;
        }
        CurrentDay++;
    }

    private void OnEnable()
    {
        TransitionToNextDay();
        GlobalEventManager.Start_UpdateProgressBar(currentDay);
    }

    private void ResetWeeklyBonus()
    {
        CurrentDay = 1;
        foreach (var day in daysBonus)
        {
            day.ResetColor();
            day.IsAccess = false;
        }
        return;
    }
}
