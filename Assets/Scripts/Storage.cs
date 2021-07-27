using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Storage : MonoBehaviour
{
    [SerializeField] private CardData[] _data;

    private List<Dictionary<string, Sprite>> _cardsData = new List<Dictionary<string, Sprite>>();

    public List<Dictionary<string, Sprite>> CardsData => _cardsData;

    private void Awake()
    {
        for (int i = 0; i < _data.Count(); i++)
        {
            _cardsData.Add(_data[i].ToDictionary());
        }
    }
}
