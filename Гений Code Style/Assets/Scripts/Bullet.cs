using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public IEnumerator Move(Rigidbody rigidbody, Vector3 direction)
    {
        rigidbody.transform.up = direction;
        rigidbody.velocity = direction * _speed;
        yield return null;
    }
}
