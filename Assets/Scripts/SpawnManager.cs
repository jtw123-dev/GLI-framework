using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnStartPoint;
    //private int _amountToSpawn;
    private bool _spawnTrue = true;

    [SerializeField] private List<GameObject> _pooledObjects;
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("SpawnManager is null");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        SpawnObject();
    }
    private void Start()
    {
        _pooledObjects = GenerateSpawn(10);
    }
    private List <GameObject> GenerateSpawn(int amountToSpawn)
    {
        for (int i =0;i<amountToSpawn;i++)
        {
            GameObject spawn = Instantiate(_spawnObject);
            _pooledObjects.Add(spawn);
            spawn.SetActive(false);
        }
        return _pooledObjects;
    }


    private GameObject RequestSpawn()
    {
        foreach (var spawn in _pooledObjects)
        {
            if (spawn.activeInHierarchy ==false)
            {
                spawn.SetActive(true);
                return spawn;
            }
        }

        GameObject newSpawn = Instantiate(_spawnObject);
        _pooledObjects.Add(newSpawn);
        return newSpawn;
    }
    public void SpawnObject()
    {
        if (_spawnTrue==false)
        {
            return;
        }
        else
        {
            StartCoroutine("SpawningObjects");
            _spawnTrue = false;
        }
    }

    private IEnumerator SpawningObjects()
    {
        Debug.Log("Spawn is called");
        GameObject spawn = RequestSpawn();
       // Instantiate(_spawnObject, _spawnStartPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        _spawnTrue = true;
    }
}
//setup max 10
//if 10 than recycle 
//