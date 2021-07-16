using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private TaskGenerator _taskGenerator;
    [SerializeField] private RestartLevel _restartLevel;

    private int _minAlpha = 0;
    private int _maxAlpha = 1;

    private void OnEnable()
    {
        _taskGenerator.TaskUpdated += OnTaskUpdated;
    }

    private void OnDisable()
    {
        _taskGenerator.TaskUpdated -= OnTaskUpdated;
    }

    private void Awake()
    {
        _display.alpha = _minAlpha;
    }

    private void Start()
    {
        StartCoroutine(ChangeAlpha(_maxAlpha));
    }

    private void OnTaskUpdated(string task)
    {
        _display.text = "Find " + task.ToUpper();
    }

    private IEnumerator ChangeAlpha(int targetAlpha)
    {
        while (_display.alpha != targetAlpha)
        {
            _display.alpha = Mathf.MoveTowards(_display.alpha, targetAlpha, Time.deltaTime);
            yield return null;
        }
    }
}
