using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpAcceleration;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        AsyncMove();
        AsyncJumb();
    }

    private void AsyncMove()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
        Move(dir.normalized * _moveSpeed * Time.deltaTime);
    }

    private void AsyncJumb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Move(Vector3 moveVector)
    {
        _rigidBody.MovePosition(_rigidBody.position + moveVector);
    }

    public void Jump()
    {
        _rigidBody.AddForce(Vector3.up * _rigidBody.mass * _jumpAcceleration);
    }
}
