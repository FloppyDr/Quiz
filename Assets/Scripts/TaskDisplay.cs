using UnityEngine;
using TMPro;

public class TaskDisplay : Fade
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private TaskGenerator _taskGenerator;
    [SerializeField] private RestartLevel _restartLevel;

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
        StartCoroutine(ChangeAlpha(_maxAlpha, _display));
    }

    private void OnTaskUpdated(string task)
    {
        _display.text = "Find " + task.ToUpper();
    }
}
