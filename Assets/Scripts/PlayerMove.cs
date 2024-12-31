using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private float _speed = 5f;
    private Vector2 _position;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] GameObject _bullet;
    private Transform _bulletTransform;
    Vector2 _mousePos;
    Vector2 _mouseOffset;
    Camera _mainCam;
    private bool _isShooting;
    private float _bulletSpeed = 15f;


    private void Start()
    {
        if(_rb != null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        gameManager = FindAnyObjectByType<GameManager>();
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

        PlayerMovement();
        //RotatePlayer();

        if (_isShooting)
        {
   //         StartCoroutine();
        }
    }

    private void PlayerMovement()
    {
        if(_position.magnitude > 0)
        {
            _rb.velocity = _position * _speed;
        }
        else
        {
            _position = Vector2.zero;
            _rb.velocity = _position;
        }
        
    }

    private void RotatePlay()
    {
        _mousePos = Input.mousePosition;
        Vector3 screenPoint = _mainCam.WorldToScreenPoint(transform.localPosition);
        _mouseOffset = new Vector2(_mousePos.x - screenPoint.x, _mousePos.y - screenPoint.y).normalized;  // KOnumunu yüksek sayýlardan normal vector deðerinde döndürür.
        // normalized kullanmazsak = 523.434 -- Kullanýrsak 0.3.-1.0;

    }



}
