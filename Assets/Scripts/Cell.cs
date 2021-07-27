using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CellVisualizer))]
[RequireComponent(typeof(ColliderStateChanger))]
public class Cell : MonoBehaviour
{
    private string _name;
    private CellVisualizer _visualizer;
    private Image _image;

    public string Name => _name;
    public CellVisualizer Visualizer => _visualizer;
    public event UnityAction<Cell> SequenceEnded;

    private void Awake()
    {
        _visualizer = GetComponent<CellVisualizer>();    
        _image = GetComponent<Image>();
    }

    public void Init(string name, Sprite sprite)
    {
        _name = name;
        _image.sprite = sprite;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
