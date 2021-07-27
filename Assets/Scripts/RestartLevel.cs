using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private RestartScreen _restartScreen;
    [SerializeField] private Image _loadingPanel;
    [SerializeField] private Color _targetColor;
    [SerializeField] private Button _restartButton;

    private int _minAlpha = 0;
    private int _maxAlpha = 1;
    private bool _isFadeEnded = false;

    public event UnityAction Restart;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _restartScreen.FadeEnded += OnFadeEnded;
    }

    private void OnDisable()
    {
        _restartScreen.FadeEnded -= OnFadeEnded;
    }

    private void OnFadeEnded()
    {
        _isFadeEnded = true;
    }

    private void OnRestartButtonClick()
    {
        if (_isFadeEnded)
        {
            _restartScreen.Reset();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(_loadingPanel.DOFade(_maxAlpha, 0));
            sequence.Append(_loadingPanel.DOColor(_targetColor, 2)).OnComplete(() => { ResetartScene(); });
        }
    }

    private void ResetartScene()
    {
        SceneManager.LoadScene(0);
    }
}
