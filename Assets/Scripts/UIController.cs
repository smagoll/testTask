using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject dailyBonus;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject levels;
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private GameObject fadeImage;

    [SerializeField]
    private GameObject currentWindow;

    [SerializeField]
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;

    public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
        currentWindow.SetActive(false);
        currentWindow = window;
    }

    public void ShowWindow(GameObject window)
    {
        window.SetActive(true);
        fadeImage.SetActive(true);
        currentWindow = window;
    }

    public void ButtonHome()
    {
        currentWindow.SetActive(false);
        menu.SetActive(true);
        currentWindow = menu;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_PointerEventData = new PointerEventData(eventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new();

            m_Raycaster.Raycast(m_PointerEventData, results);

            if (results.Count > 0)
            {
                if (results[0].gameObject.CompareTag("fade"))
                {
                    currentWindow.SetActive(false);
                    fadeImage.SetActive(false);
                    currentWindow = menu;
                }
            }
        }

    }
}
