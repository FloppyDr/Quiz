using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Card Data")]
public class CardData : ScriptableObject
{
    [SerializeField] private Card[] _card;

    public Dictionary<string,Sprite> ToDictionary()
    {
        Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();

        for (int i = 0; i < _card.Length; i++)
        {
            dictionary.Add(_card[i].Name, _card[i].Sprite);
        }

        return dictionary;
    }
}
