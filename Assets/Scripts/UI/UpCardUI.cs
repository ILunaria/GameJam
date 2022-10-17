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
    [SerializeField] private TextMeshProUGUI _name;
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
        _name.text = data.upName;
    }
    public void UpCard(float multiplier)
    {
        data.level++;
        float newPrice = data.price * multiplier;

        data.price = Mathf.FloorToInt(newPrice);
        setCard();
    }
    public int GetPrice()
    {
        return data.price;
    }
}
