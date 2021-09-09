using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text churuText = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    private void Start()
    {
        UpdateChuruPanel();
        CreatePanels();
    }
    private void CreatePanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;

        foreach (Item item in GameManager.Instance.CurrentUser.soldierList)
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
        GameManager.Instance.CurrentUser.energy++;
        //beakerAnimator.Play("Click");
        UpdateChuruPanel();
    }

    public void UpdateChuruPanel()
    {
        chruText.text = string.Format("{0} √Ú∏£", GameManager.Instance.CurrentUser.energy);
    }
}
