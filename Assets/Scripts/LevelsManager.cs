using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public Level[] levels;

    private void Start()
    {
        levels = levels.OrderBy(x => x.numberLevel).ToArray();
        foreach (var level in levels)
        {
            if (level.numberLevel <= GameManager.currentLevel)
            {
                level.IsComplete = true;
            }
            else
            {
                level.IsComplete = false;
            }
            level.gameObject.GetComponent<Button>().onClick.AddListener(delegate { OpenNextLevel(level.numberLevel); });
        }
    }

    public void OpenNextLevel(int currentLevel)
    {
        if (GameManager.currentLevel < levels.Length)
        {
            if (GameManager.currentLevel == currentLevel)
            {
                GlobalEventManager.Start_PlaySFXButton();
                GameManager.currentLevel += 1;
                levels[GameManager.currentLevel - 1].IsComplete = true;
            }
        }
    }
}
