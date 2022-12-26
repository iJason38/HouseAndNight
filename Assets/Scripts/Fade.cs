using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator _anim;
    private GameController _gameC;
    public int NumberRoom;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _gameC = FindObjectOfType<GameController>();
    }
    public void NextRoom()
    {
        _gameC.LoadNextRoom(NumberRoom);
    }
    public void FadeOn()
    {
        _anim.Play("FadeIn");
    }
}
