using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image charImage = null;
    [SerializeField]
    private Text levelText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text cPcText = null;
    [SerializeField]
    private Button button = null;


    private Character character = null;

    public void SetValue(Character character)
    {
        this.character = character;
        UpdateValues();
    }
    public void UpdateValues()
    {

        charImage.sprite = GameManager.Instance.UI.CharacterSprite[character.charNumber];
        levelText.text = string.Format("{0}", character.level);
        priceText.text = string.Format("{0} √Ú∏£", character.price);
        cPcText.text = string.Format("≈¨∏Ø¥Á »πµÊ √Ú∏£: {0}", character.cPc);
        button.interactable = character.level != 0;
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.churu < character.price)
        {
            return;
        }

        GameManager.Instance.CurrentUser.churu -= character.price;
        character.level++;
        character.price = (long)(character.price * 1.25f);
        UpdateValues();
        GameManager.Instance.UI.UpdateChuruPanel();
    }

    public void ChangeSprite()
    {
        Debug.Log(character.charNumber);
        GameManager.Instance.UI.ChangeSprite(character.charNumber);
    }

}
