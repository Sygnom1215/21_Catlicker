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
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private ChuruText churuTextTemplate = null;
    [SerializeField]
    private GameObject[] itemObjects = null;
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

        foreach (Item item in GameManager.Instance.CurrentUser.itemList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(item);
            newPanel.SetActive(true);
            upgradePanelList.Add(newPanelComponent);
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
}
