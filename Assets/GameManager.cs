using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTickets;

    private static int tickets = 700;
    public static int currentLevel = 1;

    public static int Tickets
    {
        get { return tickets; }
        set
        {
            tickets = value;
            GlobalEventManager.Start_UpdateTickets();
        }
    }

    private void Awake()
    {
        GlobalEventManager.UpdateTickets.AddListener(UpdateTextTickets);

        UpdateTextTickets();
    }

    private void UpdateTextTickets()
    {
        textTickets.text = tickets.ToString();
    }
}
