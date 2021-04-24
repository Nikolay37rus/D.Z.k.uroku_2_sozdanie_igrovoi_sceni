using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _Ghost;

    [SerializeField]
    private Transform _spawnPoint;
    void Start()
    {
        Instantiate(_Ghost, _spawnPoint.position, Quaternion.identity);
    }

    
    void Update()
    {
        
    }
}
