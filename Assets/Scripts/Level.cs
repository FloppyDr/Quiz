using System;
using UnityEngine;

[Serializable]
public class Level
{
    [SerializeField] private int _cellsCount;

    public int CellsCount => _cellsCount; 
}
