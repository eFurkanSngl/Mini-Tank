using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnTransform;
    private float _bulletSpeed = 15f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator FireRoutine()
    {
        GameObject bullets = Instantiate(_bullet,_bulletSpawnTransform.transform.position,Quaternion.identity);
        yield return bullets;
    }
}
