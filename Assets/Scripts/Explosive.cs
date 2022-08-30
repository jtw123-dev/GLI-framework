using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private GameObject _explodingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
          var explodingCopy =  Instantiate(_explodingPrefab, transform.position, Quaternion.identity);
        Instantiate(explodingCopy, transform.position, Quaternion.identity);
        this.gameObject.GetComponent<BoxCollider>().size = new Vector3(10,0.5f,5);
        Destroy(this.gameObject,1.5f);
    }
}
