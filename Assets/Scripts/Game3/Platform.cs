using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    //public float moveSpeed = 10;

    private GameObject _player;

    private int _moveDirection;

    private bool _hasToMove = true;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _moveDirection = transform.position.x < _player.transform.position.x ? 1 : -1;
    }

    private void Update()
    {
        if (_hasToMove == true)
        transform.position += Vector3.right * _moveDirection * _moveSpeed * Time.deltaTime;
        //moveSpeed += 0.05f;
    }

    public void StopMovement() => _hasToMove = false;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
