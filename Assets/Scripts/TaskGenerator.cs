using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Spawner _spawner;

    private string _task;

    public string Task => _task;

    public event UnityAction<string> TaskUpdated;

    private void OnEnable()
    {
        _spawner.Spawned += GenerateTask;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= GenerateTask;
    }

    private void GenerateTask(List<Cell> _spawned)
    {              
        int index = Random.Range(0, _spawned.Count);
        _task = _spawned[index].Name;

        TaskUpdated?.Invoke(_task);
    }
}
