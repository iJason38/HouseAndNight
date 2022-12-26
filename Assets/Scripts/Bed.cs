using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private QuestController _questC;
    private GameController _gameC;
    private Player _player;
    private bool _isTouch = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player = collision.GetComponent<Player>();
        _isTouch = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouch = false;
    }
    void Start()
    {
        _questC = FindObjectOfType<QuestController>();
        _gameC = FindObjectOfType<GameController>();
    }
    void Update()
    {
        if (_player!=null &&_player.CanSleep && _isTouch && Input.GetKeyDown(KeyCode.E))
        {
            _gameC.Night++;
            _player.CanSleep = false;
            Debug.Log("Night= " + _gameC.Night);
            _questC.SetQuest(_gameC.Night);
        }
    }
}
