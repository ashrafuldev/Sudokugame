
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberBtn : Selectable, IPointerClickHandler
{
    public int value;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvent.UpgradedSquareNumberMethod(value);
    }
}
