using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    private Vector3 _offset;
    private float _smoothSpeed = 0.125f;

    private void Start()
    {
        _offset = transform.position - _targetTransform.position;
    }

    private void FixedUpdate()
    {
        Vector3 _pos = Vector3.Lerp(transform.position, _offset + _targetTransform.position, _smoothSpeed);
        transform.position = _pos;
    }
    
}
