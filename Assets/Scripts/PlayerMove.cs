using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private float _speed = 5f;
    private Vector2 _position;
    [SerializeField] private Rigidbody2D _rb;
 
    Vector2 _mousePos;
    Vector2 _mouseOffset;
    Camera _mainCam;
    private bool _isShooting;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnTransform;
    private float _bulletSpeed = 20f;


    private void Start()
    {
        if(_rb != null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        _gameManager = FindAnyObjectByType<GameManager>();
        _mainCam = Camera.main;

    }
    private void Update()
    {
        _position = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetMouseButtonDown(0))
        {
            _isShooting = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
        if (_isShooting)
        {
            StartCoroutine(FireRoutine());
        }
    }

    private void RotatePlayer()
    {
        _mousePos = Input.mousePosition;  // mouse Posizyonunu aldýk.
        Vector3 screenPoint = _mainCam.WorldToScreenPoint(transform.localPosition);
        _mouseOffset = new Vector2(_mousePos.x - screenPoint.x , _mousePos.y - screenPoint.y).normalized;

        float angle = Mathf.Atan2(_mouseOffset.y, _mouseOffset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }

    private void MovePlayer()
    { 
        if(_position.magnitude > 0)
        {
            _rb.velocity = _position * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    IEnumerator FireRoutine()
    {
        
        if (_isShooting)
        {
             _isShooting = false;
             GameObject bullets = Instantiate(_bullet, _bulletSpawnTransform.transform.position, Quaternion.identity);
             bullets.GetComponent<Rigidbody2D>().velocity = _mouseOffset * _bulletSpeed;
             yield return new WaitForSeconds(3f);
             Destroy(bullets);
        }
        
      
    }
}

