using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpCardUI : MonoBehaviour
{
    [SerializeField] private UpCardSO data;
    [SerializeField] private TextMeshProUGUI lv;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI price;
    private void Awake()
    {
        setCard();
    }
    private void setCard()
    {
        price.text = data.price.ToString();
        lv.text = data.level.ToString();
        desc.text = data.upDescription;
        icon.sprite = data.icon;
    }
    public void UpCard(int multiplier)
    {
        data.level++;
        data.price = data.price * multiplier;
        setCard();
    }
    public int GetPrice()
    {
        return data.price;
    }
}
