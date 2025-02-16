using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private float _timeWaitShooting;

    private Transform _object;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new(_timeWaitShooting);
    }

    void Start()
    {
        StartCoroutine(FireBullets());
    }

    private IEnumerator FireBullets()
    {
        while (enabled)
        {
            Vector3 direction = (_object.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefabBullet, transform.position + direction, Quaternion.identity);

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();

            rigidbody.transform.up = direction;
            rigidbody.velocity = direction * _speed;

            yield return _waitForSeconds;
        }
    }
}
