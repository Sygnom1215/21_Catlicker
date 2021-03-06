using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image itemImage = null;
    [SerializeField]
    private Text itemNameText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text cPsText = null;
    //[SerializeField]
    //private Button purchaseButton = null;
    [SerializeField]
    private Sprite[] itemSprite = null;


    private Item item = null;

    public void SetValue(Item item)
    {
        this.item = item;
        UpdateValues();
    }
    public void UpdateValues()
    {
        itemImage.sprite = itemSprite[item.itemNumber];
        itemNameText.text = item.itemName;
        amountText.text = string.Format("{0}", item.amount);
        priceText.text = string.Format("{0} ????", item.price);
        cPsText.text = string.Format("?ʴ? ȹ?? ????: {0}", item.cPs);
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
        GameManager.Instance.UI.ItemAppearance(item.itemNumber);
    }
}
