using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpTest _test;
    [SerializeField] private int _dataBorder;
    [SerializeField] private Cell _prefub;
    [SerializeField] private Transform _container;
    [SerializeField] private List<Transform> _spawnpoints;
    [Range(0, 2)]
    private int _difficulty = 0;

    private List<Cell> _spawned = new List<Cell>();
    private List<int> _curretData = new List<int>();


    public event UnityAction<List<Cell>> Spawned;

    private void Start()
    {
        if (Random.Range(0, 2) % 2 == 0)
        {
            for (int i = 0; i <= _dataBorder; i++)
            {
                _curretData.Add(i);
            }
        }
        else
        {
            for (int i = _dataBorder + 1; i < _test.Images.Count; i++)
            {
                _curretData.Add(i);
            }
        }

        Spawn();
        Spawned?.Invoke(_spawned);
    }

    private void Spawn()
    {
        int spawnpointsCount = 0;

        switch (_difficulty)
        {
            case 0:
                spawnpointsCount = 3;
                break;
            case 1:
                spawnpointsCount = 6;
                break;
            case 2:
                spawnpointsCount = 9;
                break;

            default:
                break;
        }
        for (int i = 0; i < spawnpointsCount; i++)
        {
            int index = _curretData[Random.Range(0, _curretData.Count)];

            KeyValuePair<string, Sprite> pair = _test.Images.ElementAt(index);

            _curretData.Remove(index);

            var spawned = Instantiate(_prefub, _spawnpoints[i].transform.position, Quaternion.identity, _container);
            _spawned.Add(spawned);
            spawned.Init(pair.Key, pair.Value);
        }

        _difficulty++;
        if (_difficulty > 2)
        {
            _difficulty = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
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
                for (int i = _dataBorder + 1; i < _test.Images.Count; i++)
                {
                    _curretData.Add(i);
                }
            }

            Spawn();
            Spawned?.Invoke(_spawned);
        }
    }

    public void ChangeDifficulty()
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
            for (int i = _dataBorder + 1; i < _test.Images.Count; i++)
            {
                _curretData.Add(i);
            }
        }

        Spawn();
        Spawned?.Invoke(_spawned);
    }

}
