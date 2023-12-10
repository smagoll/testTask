using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private GameObject lockLevel;
    [SerializeField]
    private Button button;
    private bool isComplete = false;
    public int numberLevel;

    public bool IsComplete
    {
        get { return isComplete; }
        set
        {
            isComplete = value;
            CheckCompleteLevel();
        }
    }

    private void Start()
    {
        textLevel.text = numberLevel.ToString();
        CheckCompleteLevel();
    }

    private void CheckCompleteLevel()
    {
        if (isComplete)
        {
            button.interactable = true;
            lockLevel.SetActive(false);
            textLevel.gameObject.SetActive(true);
        }
        else
        {
            button.interactable = false;
        }
    }
}
