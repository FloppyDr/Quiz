using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartScreen : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CanvasGroup _canvasGroup;

    private int _minAlpha = 0;
    private int _maxAlpha = 1;

    public event UnityAction FadeEnded;

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
        StartCoroutine(ChangeAlpha(_maxAlpha));
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    private IEnumerator ChangeAlpha(int targetAlpha)
    {
        while (_canvasGroup.alpha != targetAlpha)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, targetAlpha, Time.deltaTime);
            yield return null;
        }
        FadeEnded?.Invoke();
    }

    public void Reset()
    {
        _canvasGroup.alpha = _minAlpha;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
}
