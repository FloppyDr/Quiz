using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    private string _name;
    private SpriteRenderer _spriteRenderer;

    public string Name => _name;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
}
