using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private  Text _score;
    [SerializeField] private Text _enemy;
    [SerializeField] private Text _timeRemaining;
    private float _time = 60;
    private static UIManager  _instance;
    [SerializeField] private Text _winText;
    public bool noRessurect;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UIManager is null");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (_time>0)
        {
            _time -= Time.deltaTime;
            _timeRemaining.text = _time.ToString();
        }

        if (_enemy.text==0.ToString())
        {
            _winText.gameObject.SetActive(true);
            noRessurect = true;
            
        }
    }
    public void ScoreUpdate(int playerScore)
    {
        _score.text = playerScore.ToString();
    }

    public void EnemyUpdate(int enemyAmount)
    {
        _enemy.text = enemyAmount.ToString();
    }

    
}
