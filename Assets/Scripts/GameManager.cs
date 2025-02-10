using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _isGameOver = false;
    [SerializeField] private GameObject _player;

   public void GameOver()
    {
        _isGameOver = true;
        if (_isGameOver)
        {
            Time.timeScale = 0f;
            _player.SetActive(false);
        }
    }
}
