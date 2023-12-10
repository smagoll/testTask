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
    private WindowManager menu;
    [SerializeField]
    private WindowManager dailyBonus;
    [SerializeField]
    private WindowManager settings;
    [SerializeField]
    private WindowManager levels;
    [SerializeField]
    private WindowManager shop;
    [SerializeField]
    private GameObject fadeImage;

    [SerializeField]
    private WindowManager currentWindow;

    [SerializeField]
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;

    public void OpenWindow(WindowManager window)
    {
        window.Enable();
        currentWindow.Disable();
        currentWindow = window;
    }

    public void ShowWindow(WindowManager window)
    {
        window.Enable();
        currentWindow = window;
    }

    public void ButtonHome()
    {
        currentWindow.Disable();
        menu.Enable();
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
                    currentWindow.Disable();
                    currentWindow = menu;
                }
            }
        }

    }
}
