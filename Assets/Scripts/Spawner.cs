using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Storage _data;
    [SerializeField] private int _dataBorder;
    [SerializeField] private Cell _prefub;
    [SerializeField] private Transform _container;
    [SerializeField] private List<Transform> _spawnpointsEasy;
    [SerializeField] private List<Transform> _spawnpointsMedium;
    [SerializeField] private List<Transform> _spawnpointsHard;
    [SerializeField] private RestartLevel _restartLevel;

    private int _level = 0;
    private List<Cell> _spawned = new List<Cell>();
    private List<int> _curretData = new List<int>();

    public event UnityAction<List<Cell>> Spawned;
    public event UnityAction LevelsEnded;

    private void Start()
    {
        Reset();
        Spawn();
        Spawned?.Invoke(_spawned);
    }

    private void Spawn()
    {
        List<Transform> curretSpawnpoints = new List<Transform>();

        switch (_level)
        {
            case 0:
                curretSpawnpoints = _spawnpointsEasy;
                break;
            case 1:
                curretSpawnpoints = _spawnpointsMedium;
                break;
            case 2:
                curretSpawnpoints = _spawnpointsHard;
                break;

            default:
                break;
        }

        for (int i = 0; i < curretSpawnpoints.Count; i++)
        {
            int index = _curretData[Random.Range(0, _curretData.Count)];

            KeyValuePair<string, Sprite> pair = _data.Images.ElementAt(index);

            _curretData.Remove(index);

            var spawned = Instantiate(_prefub, curretSpawnpoints[i].transform.position, Quaternion.identity, _container);
            _spawned.Add(spawned);
            spawned.Init(pair.Key, pair.Value);
            if (_level == 0)
            {
                spawned.ShowAnimation();
            }

        }

        if (_level > 2)
        {
            _level = 0;
            LevelsEnded?.Invoke();
        }
        _level++;
    }  

    private void Reset()
    {
        for (int i = 0; i < _spawned.Count; i++)
        {
            _spawned[i].Die();
        }

        _spawned.Clear();
        _curretData.Clear();
        if (Random.Range(0, 2) % 2 == 0)
        {
            for (int i = 0; i <= _dataBorder; i++)
            {
                _curretData.Add(i);
            }
        }
        else
        {
            for (int i = _dataBorder + 1; i < _data.Images.Count; i++)
            {
                _curretData.Add(i);
            }
        }

       
    }

    public void ChangeLevel()
    {
        Reset();

        Spawn();
        Spawned?.Invoke(_spawned);
    }

}
