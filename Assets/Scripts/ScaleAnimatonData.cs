using System;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class ScaleAnimatonData
{
    [SerializeField] private float _scaleValue;
    [SerializeField] private Ease _ease;

    public float ScaleValue => _scaleValue;
    public Ease Ease => _ease;
}
