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

    public void CheckAnswer(string answer, Cell cell)
    {
        _curretTask = _taskGenerator.Task;

        if (answer == _curretTask)
        {
            cell.Visualizer.SequenceEnded += OnSequenceEnded;
            cell.Visualizer.Correct();       
        }
        else
        {
            cell.Visualizer.Incorrect();
            return;
        }
    }

    private void OnSequenceEnded(CellVisualizer cell)
    {
        _spawner.ChangeLevel();
        cell.SequenceEnded -= OnSequenceEnded;
    }
}


