using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _target;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new(_timeWaitShooting);
        _target = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        if (_target == null)
        {
            yield break;
        }

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefabBullet, transform.position + direction, Quaternion.identity);

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                bullet.StartMoveCoroutine(rigidbody, direction);
            }

            yield return _waitForSeconds;
        }
    }
}
