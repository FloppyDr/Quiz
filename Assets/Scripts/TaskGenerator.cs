using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Spawner _spawner;

    private List<Cell> _cells = new List<Cell>();
    private string _task;

    public string Task => _task;

    private void OnEnable()
    {
        _spawner.Spawned += GenerateTask;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= GenerateTask;
    }

    private void Start()
    {
       
    }

    private void GenerateTask(List<Cell> _spawned)
    {              
        int index = Random.Range(0, _cells.Count);
        _task = _spawned[index].Name;

        Debug.Log("Find " + _task);
    }
}
