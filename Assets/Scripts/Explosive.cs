using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private GameObject _explodingPrefab;
    public bool _isDead=true;
    public int howMany;
    private int _addEnemy;
    public void Explode()
    {
          var explodingCopy =  Instantiate(_explodingPrefab, transform.position, Quaternion.identity);
        Instantiate(explodingCopy, transform.position, Quaternion.identity);
        this.gameObject.GetComponent<BoxCollider>().size = new Vector3(10,0.5f,5);
        Destroy(this.gameObject,1.5f);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            _addEnemy++;
            yield return new WaitForSeconds(1);
            EnemyTotal();
            Debug.Log(howMany);
            Debug.Log(_isDead);
        }
    }
    public void EnemyTotal()
    {
        howMany = _addEnemy;
    }

}
