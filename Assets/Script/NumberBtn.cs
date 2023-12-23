using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NumberBtn : Selectable, IPointerClickHandler
{
    public int value = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvent.UpdateSqureNumberMethod(value);
    }
}
