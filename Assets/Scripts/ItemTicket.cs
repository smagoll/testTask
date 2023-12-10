using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTicket : MonoBehaviour
{
    [SerializeField]
    private GameObject lockItem;
    [SerializeField]
    private GameObject iconItem;
    [SerializeField]
    private TextMeshProUGUI textTickets;
    [SerializeField]
    private TextMeshProUGUI textLevelItem;
    [SerializeField]
    private GameObject price;
    [SerializeField]
    private TextMeshProUGUI textNameItem;
    [SerializeField]
    private GameObject iconPurchased;
    [SerializeField]
    private string nameItem;
    [SerializeField]
    private int needLevel;
    [SerializeField]
    private int needTickets;
    [SerializeField]
    private Button buttonBuy;


    private bool isOpen = false;
    public bool isHave = false;

    public bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            if (isOpen)
            {
                lockItem.SetActive(false);
                iconItem.SetActive(true);
            }
        }
    }
    
    public bool IsHave
    {
        get { return isHave; }
        set
        {
            isHave = value;
            if (isHave)
            {
                buttonBuy.interactable = false;
                iconPurchased.SetActive(true);
                price.SetActive(false);
            }
            else
            {
                buttonBuy.interactable = true;
                iconPurchased.SetActive(false);
                price.SetActive(true);
            }
        }
    }

    private void Start()
    {
        textTickets.text = "x" + needTickets.ToString();
        textLevelItem.text = $"LV. {needLevel}";
        textNameItem.text = nameItem;
    }

    private void OnEnable()
    {
        if (needLevel <= GameManager.currentLevel)
        {
            IsOpen = true;
        }
        if (isHave)
        {
            buttonBuy.interactable = false;
        }
    }

    public void BuyItem()
    {
        if (needTickets <= GameManager.Tickets && IsOpen)
        {
            GameManager.Tickets -= needTickets;
            IsHave = true;
        }
    }
}
