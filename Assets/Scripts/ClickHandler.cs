using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    private TaskChecker _checker;
    public void OnPointerClick(PointerEventData eventData)
    {
       Cell cell = eventData.pointerCurrentRaycast.gameObject.GetComponent<Cell>();

        _checker.CheckAnswer(cell.Name);

    }



    private void Awake()
    {
        _checker = FindObjectOfType<TaskChecker>();
    }
}
