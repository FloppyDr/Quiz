using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TaskGenerator))]
public class TaskChecker : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private string _curretTask;
    private TaskGenerator _taskGenerator;

    private void Start()
    {
        _taskGenerator = GetComponent<TaskGenerator>();
    }

    public void CheckAnswer(string answer)
    {
        _curretTask = _taskGenerator.Task;

        if (answer == _curretTask)
        {
            _spawner.ChangeDifficulty();
        }
        else
        {
            return;
        }
    }
}


