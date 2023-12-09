using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject DailyBonus;
    [SerializeField]
    private GameObject Settings;
    [SerializeField]
    private GameObject Levels;
    [SerializeField]
    private GameObject Shop;


   public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
