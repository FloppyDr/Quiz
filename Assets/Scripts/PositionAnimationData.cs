using System;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class PositionXAnimatonData
{
    [SerializeField] private float _positionValue;
    [SerializeField] private Ease _ease;

    public float PositionValue => _positionValue;
    public Ease Ease => _ease;
}
