using UnityEngine;
using System;

[Serializable]
public class Card 
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;

    public string Name => _name;
    public Sprite Sprite => _sprite;
}
