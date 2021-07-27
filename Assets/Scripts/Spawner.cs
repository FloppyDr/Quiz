using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Storage _data;
    [SerializeField] private Cell _prefab;
    [SerializeField] private RectTransform _container;
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private List<Level> _levels;

    private bool _isFirstLevel = true;
    private List<Cell> _spawned = new List<Cell>();
    private Dictionary<string, Sprite> _curretData;
  
    public event UnityAction<List<Cell>> Spawned;
    public event UnityAction LevelsEnded;

    private void Start()
    {
        ChangeLevel();
    }

    private void Spawn()
    {
        if (_levels.Count > 0)
        {
            for (int i = 0; i < _levels[0].CellsCount; i++)
            {
                int index = Random.Range(0, _curretData.Count);

                KeyValuePair<string, Sprite> pair = _curretData.ElementAt(index);

                _curretData.Remove(pair.Key);

                var spawned = Instantiate(_prefab, _container);
                _spawned.Add(spawned);
                spawned.Init(pair.Key, pair.Value);
                if (_isFirstLevel)
                {
                    spawned.Visualizer.ShowAnimation();
                }
            }
            _isFirstLevel = false;
            _levels.RemoveAt(0);
            
        }
        else
        {
            LevelsEnded?.Invoke();
        }
    }

    private void Reset()
    {
        for (int i = 0; i < _spawned.Count; i++)
        {
            _spawned[i].Die();
        }

        _spawned.Clear();

        int index = Random.Range(0, _data.CardsData.Count);

        _curretData = new Dictionary<string, Sprite>(_data.CardsData[index]);
    }

    public void ChangeLevel()
    {
        Reset();
        Spawn();
        Spawned?.Invoke(_spawned);
    }
}
