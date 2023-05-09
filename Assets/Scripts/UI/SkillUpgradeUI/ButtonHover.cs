using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText;

    [TextArea (10, 20)]
    public string str;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.text = str;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.text = "";
    }
}
