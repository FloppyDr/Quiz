using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private TaskChecker _checker;

    private void Awake()
    {
        _checker = FindObjectOfType<TaskChecker>();
    }

    private void OnMouseDown()
    {
        Cell cell = gameObject.GetComponent<Cell>();
        _checker.CheckAnswer(cell.Name, cell);
    }
}
