using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text churuText = null;
    [SerializeField]
    private Animator catMove1Animator = null;
    [SerializeField]
    private ScrollRect scrollRect = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private GameObject characterUpgradePanelTemplate = null;
    [SerializeField]
    private ChuruText churuTextTemplate = null;
    [SerializeField]
    private GameObject[] itemObjects = null;
    [SerializeField]
    private Sprite[] character = null;
    [SerializeField]
    private SpriteRenderer charImage = null;
    [SerializeField]
    private RectTransform[] contants = null;

    public Sprite[] CharacterSprite
    {
        get
        {
            return character;
        }
    }

    //[SerializeField]
    //private GameObject items = null;

    //private GameObject[] item = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    private void Start()
    {
        UpdateChuruPanel();
        CreatePanels();
        //item = items.GetComponentsInChildren<GameObject>();
    }
    private void CreatePanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;
        CharacterUpgradePanel newCharPanelComponent = null;

        foreach (Item item in GameManager.Instance.CurrentUser.itemList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(item);
            newPanel.SetActive(true);
            if (item.amount > 0)
            {
                ItemAppearance(item.itemNumber);
            }
            upgradePanelList.Add(newPanelComponent);
        }
        foreach (Character character in GameManager.Instance.CurrentUser.charList)
        {
            newPanel = Instantiate(characterUpgradePanelTemplate, characterUpgradePanelTemplate.transform.parent);
            newCharPanelComponent = newPanel.GetComponent<CharacterUpgradePanel>();
            newCharPanelComponent.SetValue(character);
            newPanel.SetActive(true);
        }
    }

    public void OnClickBeaker()
    {
        GameManager.Instance.CurrentUser.churu++;
        catMove1Animator.Play("CatMoveAnim");

        ChuruText newText = null;
        if (GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<ChuruText>();
        }
        else
        {
            newText = Instantiate(churuTextTemplate, GameManager.Instance.Canvas.transform).GetComponent<ChuruText>();
        }
        newText.Show(Input.mousePosition);
        UpdateChuruPanel();
    }

    public void UpdateChuruPanel()
    {
        churuText.text = string.Format("{0} √Ú∏£", GameManager.Instance.CurrentUser.churu);
    }

    public void ItemAppearance(int num) //bool isShow
    {
        itemObjects[num].SetActive(true);

    }

    public void OnClickShowPanel(int num)
    {
        scrollRect.content = contants[num];
        for (int i = 0; i < contants.Length; i++)
        {
            if (num == i)
            {
                contants[i].gameObject.SetActive(true);
            }
            else
            {
                contants[i].gameObject.SetActive(false);
            }


        }
    }
}
