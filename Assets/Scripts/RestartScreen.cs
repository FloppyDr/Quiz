using UnityEngine;

public class RestartScreen : Fade
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _spawner.LevelsEnded += OnLevelsEnded;
    }

    private void OnDisable()
    {
        _spawner.LevelsEnded -= OnLevelsEnded;
    }

    private void Awake()
    {
        Reset();
    }

    private void OnLevelsEnded()
    {
        StartCoroutine(ChangeAlpha(_maxAlpha,_canvasGroup));
        ChangeCanvasGroupState();
    }

    private void ChangeCanvasGroupState()
    {
        _canvasGroup.blocksRaycasts = !_canvasGroup.blocksRaycasts;
        _canvasGroup.interactable = !_canvasGroup.interactable;
    }

    public void Reset()
    {
        _canvasGroup.alpha = _minAlpha;
        ChangeCanvasGroupState();
    } 
}
