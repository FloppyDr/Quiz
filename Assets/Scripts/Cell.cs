using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour
{
    private string _name;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private ParticleSystem _starEffect;

    public string Name => _name;

    public event UnityAction<Cell> SequenceEnded;

    private void Awake()
    {
        _starEffect = GetComponentInChildren<ParticleSystem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void ShowAnimation()
    {
        transform.DOScale(0, 0.01f);
        transform.DOScale(1, 0.2f).SetEase(Ease.OutBounce);
    }

    public void Init(string name, Sprite sprite)
    {
        _name = name;
        _spriteRenderer.sprite = sprite;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Correct()
    {
        _starEffect.transform.position = transform.position;
        _starEffect.Play();

        Sequence sequence = DOTween.Sequence();


        sequence.Append(transform.DOScale(0.5f, 0.5f)).SetEase(Ease.InBounce);
        sequence.Append(transform.DOScale(1.5f, 0.5f)).SetEase(Ease.InOutBounce);
        sequence.Append(transform.DOScale(1f, 0.5f)).SetEase(Ease.OutBounce).OnComplete(() => { SequenceEnded?.Invoke(this); });

        _boxCollider2D.enabled = false;
    }

    public void Incorrect()
    {
        Sequence sequence = DOTween.Sequence();

        float _startPositionX = transform.position.x;

        sequence.Append(transform.DOMoveX(transform.position.x - 0.25f, 0.2f).SetEase(Ease.InBounce));

        sequence.Append(transform.DOMoveX(transform.position.x + 0.5f, 0.2f).SetEase(Ease.InBounce));

        sequence.Append(transform.DOMoveX(_startPositionX, 0.2f).SetEase(Ease.OutBounce));



    }
}
