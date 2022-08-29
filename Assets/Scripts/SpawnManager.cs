using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    private bool _spawnTrue = true;
    [SerializeField] private GameObject _spawnContainer;
    [SerializeField] private List<GameObject> _pooledObjects;
    private AI _ai;
    
    public bool _resurrect =true;
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
            spawn.transform.parent = _spawnContainer.transform;
            _pooledObjects.Add(spawn);
            spawn.SetActive(false);
        }
        return _pooledObjects;
    }

    private GameObject RequestSpawn()
    {
        foreach (var spawn in _pooledObjects)
        {
            if (spawn.activeInHierarchy ==false &&UIManager.Instance.noRessurect==false )
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
        yield return new WaitForSeconds(5);
        _spawnTrue = true;
    }
}