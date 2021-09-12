using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Text itemNameText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Image itemImage = null;

    private Item item = null;

    public void SetValue(Item item)
    {
        this.item = item;
        UpdateValues();
    }
    public void UpdateValues()
    {
        itemNameText.text = item.itemName;
        amountText.text = string.Format("{0}", item.amount);
        priceText.text = string.Format("{0} √Ú∏£", item.price);
        itemImage.sprite = item.itemSprite;
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.churu < item.price)
        {
            return;
        }

        GameManager.Instance.CurrentUser.churu -= item.price;
        item.amount++;
        item.price = (long)(item.price * 1.25f);
        UpdateValues();
        GameManager.Instance.UI.UpdateChuruPanel();
    }
}
