using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float Scale = 1.1f;
    public float Duration = 0.25f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOScale(Scale, Duration).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOScale(1, Duration).SetUpdate(true);
    }
}
