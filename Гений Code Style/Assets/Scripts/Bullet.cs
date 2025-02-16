using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody = new();
    private Vector3 _direction = new();

    public void StartMoveCoroutine(Rigidbody rigidbody, Vector3 direction)
    {
        _rigidbody = rigidbody;
        _direction = direction;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        _rigidbody.transform.up = _direction;
        _rigidbody.velocity = _direction * _speed;

        yield return null;
    }
}
