using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestController : MonoBehaviour
{
    //
    public GameObject QuestUI;
    private Player _player;
    private bool _allQusetNightComplite = false;
    private string[,] _quest =
        //{ночь, 1/0, задание, id}
        {
            {"1","0","Осмотреть дом","0" }
        };
    private int _idThsiQuset;
    private int _night;
    public void SetQuest(int night)
    {
        _night = night;
        QuestUI.SetActive(true);
        for (int i = 0; i < _quest.GetLength(0); i++)
        {
            if (_quest[i, 0] == night.ToString() && _quest[i, 1] == "0")
            {
                QuestUI.transform.GetChild(0).GetComponent<TMP_Text>().text = _quest[i, 2];
                
                QuestInfo(int.Parse(_quest[i,3]));
                _idThsiQuset = int.Parse(_quest[i, 3]);
                break;
            }
        }
    }
    private void CompliteQuest()
    {
        for (int i = 0; i < _quest.GetLength(0); i++)
        {
            if (_quest[i, 3] == _idThsiQuset.ToString())
            {
                _quest[i, 1] = "1";
                _player.CanSleep = true;
                QuestUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Я могу лечь спать";
                break;
            }
        }

        for (int j = 0; j < _quest.GetLength(0); j++)
        {
            if (_quest[j, 0] == _night + 1.ToString() && _quest[j - 1, 1] == "1")
            {
                _allQusetNightComplite = true;
                
                break;
            }
        }

        if (!_allQusetNightComplite)
        {
            SetQuest(_night); 
        }
    }
    private void QuestInfo(int id)
    {
        switch (id)
        {
            case 0:
                CheckAllRoomQuest();
                break;
        }
    }
    private void CheckAllRoomQuest()
    {
        _player.CheckAllRoom = true;
        QuestUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "1/3";
    }
    public void CheckAllRoomCheck(int room)
    {
        
        
        QuestUI.transform.GetChild(1).GetComponent<TMP_Text>().text = room.ToString() + "/3";
        if (room == 3)
        {
            CompliteQuest();
            _player.CheckAllRoom = false;
            QuestUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "3/3";
            QuestUI.transform.GetChild(1).GetComponent<TMP_Text>().fontStyle= FontStyles.Strikethrough;
        }
    }
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        
    }
}
