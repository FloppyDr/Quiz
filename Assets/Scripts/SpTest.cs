using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpTest : MonoBehaviour
{
    
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<string> _names;
    [SerializeField] private Dictionary<string, Sprite> _images = new Dictionary<string, Sprite>();

    private SpriteRenderer _spriteRenderer;

    public Dictionary<string, Sprite> Images => _images;

    private void Awake()
    {
        for (int i = 0; i < _names.Count; i++)
        {
            _images.Add(_names[i], _sprites[i]);
        }
    }

    private void Start()
    {       
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int index = Random.Range(0, _images.Count);
            KeyValuePair<string, Sprite> pair = _images.ElementAt(index);

            _spriteRenderer.sprite = pair.Value;
            Debug.Log(pair.Key);
        }
    }
}
