using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Room = new GameObject[6];
    private QuestController _questC;
    private Fade _fade;
    private Player _player;
    public int ThisRoom=0;
    public int Night = 1;
    public void LoadNextRoom(int numberRoom)
    {
        int number = 0;
        Room[ThisRoom].SetActive(false);
        Room[numberRoom].SetActive(true);
        //Number=1 - мы вернулись обратно и должны встать в ту поз. откуда уходили
        //Number=0 - мы перешли в новую локу , след. должны встать на входе в эту локу
        if (ThisRoom > numberRoom)
            number = 1;
        else
            number = 0;
        var posSpawn = Room[numberRoom].transform.GetChild(number).transform.position;
        ThisRoom = numberRoom;
        _player.gameObject.transform.position = posSpawn;
    }
    
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _fade = FindObjectOfType<Fade>();
        _questC = FindObjectOfType<QuestController>();
        _questC.SetQuest(Night);
    }

    
    void Update()
    {
        
    }
}
