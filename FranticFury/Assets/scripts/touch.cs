using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class touch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool is_Touched = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        is_Touched = true;
        Debug.Log("Dowm");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        is_Touched = false;
        Debug.Log("Up");
    }
}