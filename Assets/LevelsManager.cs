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
            level.gameObject.GetComponent<Button>().onClick.AddListener(OpenNextLevel);
        }
    }

    public void OpenNextLevel()
    {
        if (GameManager.currentLevel < levels.Length)
        {
            GameManager.currentLevel += 1;
            levels[GameManager.currentLevel - 1].IsComplete = true;
        }
    }
}
