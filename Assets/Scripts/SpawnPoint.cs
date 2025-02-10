using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoint;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

   IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int randomSpawnPoint = UnityEngine.Random.Range(0, _spawnPoint.Length);
            Instantiate(_prefab, _spawnPoint[randomSpawnPoint].transform.position,Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }
}
