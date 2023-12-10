using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textCompleteDays;

    private void Awake()
    {
        GlobalEventManager.UpdateProgressBar.AddListener(UpdateProgress);
    }

    public void SetMaxDays(float countDays, float currentDay)
    {
        slider.maxValue = countDays;
        slider.value = currentDay;
    }

    public void UpdateProgress(float currentDay)
    {
        if (currentDay <= slider.maxValue)
        {
            slider.value = currentDay;
            textCompleteDays.text = $"{slider.value}/{slider.maxValue}";
        }
    }
}
