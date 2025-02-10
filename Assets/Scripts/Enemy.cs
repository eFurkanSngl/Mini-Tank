using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject _player;

    private float _enemyHealt = 100f;
    private float _enemySpeed = 10f;
    private Quaternion _targetRotation;
    private bool _disableEnemy = false;
    private Vector2 _moveDirection;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        CheckGameOver();
    }


    private void CheckGameOver()
    {
        if (!_gameManager._isGameOver || !_disableEnemy)  // Oyun bitmediyse ve Enemy enable ise
        {
            RotateEnemy();
            MoveEnemey();
        }

    }

    private void RotateEnemy()
    { 
        _moveDirection = _player.transform.position - transform.position;
        _moveDirection.Normalize();

        _targetRotation = Quaternion.LookRotation(Vector3.forward, _moveDirection);

        if(transform.rotation != _targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, 200 * Time.fixedDeltaTime);
        }
    }

    private void MoveEnemey()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _enemySpeed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(DamageRotuine());

            _enemyHealt -= 40;
            
            if(_enemyHealt <= 0f)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject); // çarptýðýmýz nesneyi de yok ediyoruz.
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            _gameManager.GameOver();
        }
    }

    IEnumerator DamageRotuine()
    {
        _disableEnemy = true;

        yield return new WaitForSeconds(1);

        _disableEnemy = false;
    }
}
