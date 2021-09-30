using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChuruText : MonoBehaviour
{
    private Text churuText = null;
    [SerializeField]
    private Canvas canvas = null;

    public void Show(Vector2 mousePosition)
    {
        churuText = GetComponent<Text>();
        churuText.text = string.Format("+{0}", GameManager.Instance.CurrentUser.charList[GameManager.Instance.CurrentUser.charNum].cPc);

        churuText.gameObject.SetActive(true);
        churuText.transform.SetParent(GameManager.Instance.Canvas.transform);
        churuText.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 100f;

        churuText.DOFade(0f, 0.5f).OnComplete(() => Despawn());
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
    }

    private void Despawn()
    {
        churuText.DOFade(1f, 0f);
        transform.SetParent(GameManager.Instance.Pool);
        gameObject.SetActive(false);
    }

}
