using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionRoom : MonoBehaviour
{
    private GameController _gameC;
    private QuestController _questC;
    private Fade _fade;
    private Player _player;
    private bool _isTouch = false;
    public int NextRoom;
    private bool _checkRomm = false;
    private void Start()
    {
        _fade = FindObjectOfType<Fade>();
        _player = FindObjectOfType<Player>();
        _gameC = FindObjectOfType<GameController>();
        _questC = FindObjectOfType<QuestController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isTouch = true;
        if (collision.GetComponent<Player>().CheckAllRoom)
            _checkRomm = true;
        else
            _checkRomm = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouch = false;
    }
    private void Update()
    {
        if (_isTouch && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Нажал");
            _fade.FadeOn();
            _fade.NumberRoom = NextRoom;
            if (_checkRomm)
                _questC.CheckAllRoomCheck(NextRoom);
        }
    }
}
