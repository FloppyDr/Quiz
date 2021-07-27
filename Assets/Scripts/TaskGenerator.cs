using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskGenerator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private string _task;
    private List<string> _previousTasks = new List<string>();

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
        List<string> availebleNames = new List<string>();

        for (int i = 0; i < _spawned.Count; i++)
        {
            availebleNames.Add(_spawned[i].Name);
        }

        if (_previousTasks.Count>0)
        {
            for (int i = 0; i < _previousTasks.Count; i++)
            {
                for (int j = 0; j < availebleNames.Count; j++)
                {
                    if (_previousTasks[i] == availebleNames[j])
                    {
                        availebleNames.Remove(_previousTasks[i]);
                    }
                }
            }
        }

        int index = Random.Range(0, availebleNames.Count);

        _task = availebleNames[index];
        _previousTasks.Add(_task);
        TaskUpdated?.Invoke(_task);
    }
}
