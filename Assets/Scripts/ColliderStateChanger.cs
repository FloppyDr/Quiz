using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CellVisualizer))]
public class ColliderStateChanger : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private CellVisualizer _visualizer;

    private void OnEnable()
    {
        _visualizer.CorrectSequenceStarted += OnCorrectSequenceStarted;
    }

    private void OnDisable()
    {
        _visualizer.CorrectSequenceStarted += OnCorrectSequenceStarted;
    }

    private void Awake()
    {
        _visualizer = GetComponent<CellVisualizer>();      
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCorrectSequenceStarted()
    {
        _boxCollider2D.enabled = false;
    }
}
