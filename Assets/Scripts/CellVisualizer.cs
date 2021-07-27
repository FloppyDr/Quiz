using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class CellVisualizer : MonoBehaviour
{
    [SerializeField] private List<ScaleAnimatonData> _bounceScales = new List<ScaleAnimatonData>();
    [SerializeField] private List<PositionXAnimatonData> _positions = new List<PositionXAnimatonData>();

    private ParticleSystem _starEffect;
    private Sequence _curretSequence;
    private Vector3 _startScale;
    private float _startPositionX;

    public event UnityAction<CellVisualizer> SequenceEnded;
    public event UnityAction CorrectSequenceStarted;

    private void Awake()
    {
        _starEffect = GetComponentInChildren<ParticleSystem>();      
    }

    public void ShowAnimation()
    {
        transform.DOScale(0, 0.01f);
        transform.DOScale(1, 0.2f).SetEase(Ease.OutBounce);
    }

    public void Correct()
    {
        _startScale = transform.localScale;
        CorrectSequenceStarted?.Invoke();
        PlayEffect();
        SequenceReset();

        _curretSequence = DOTween.Sequence();

        for (int i = 0; i < _bounceScales.Count; i++)
        {
            _curretSequence.Append(transform.DOScale(_bounceScales[i].ScaleValue, 0.5f)).SetEase(_bounceScales[i].Ease);
        }

        _curretSequence.Append(transform.DOScale(_startScale, 0.5f)).SetEase(Ease.OutBounce).OnComplete(() => { SequenceEnded?.Invoke(this); });
    }

    public void Incorrect()
    {
        _startPositionX = transform.position.x;

        SequenceReset();

        _curretSequence = DOTween.Sequence();

        for (int i = 0; i < _positions.Count; i++)
        {
            _curretSequence.Append(transform.DOMoveX(transform.position.x + _positions[i].PositionValue, 0.2f).SetEase(_positions[i].Ease));
        }

        _curretSequence.Append(transform.DOMoveX(_startPositionX, 0.2f).SetEase(Ease.OutBounce));
    }

    private void SequenceReset()
    {
        if (_curretSequence != null)
        {
            _curretSequence.Complete();
        }
    }

    private void PlayEffect()
    {
        _starEffect.transform.position = transform.position;
        _starEffect.Play();
    }
}
