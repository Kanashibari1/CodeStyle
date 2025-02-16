using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _places;

    private float _speed = 2f;
    private int _index;
    private const float Threshold = 0.1f;

    private void Update()
    {
        transform.LookAt(_places[_index].position);
        transform.position = Vector3.MoveTowards(transform.position, _places[_index].position, _speed * Time.deltaTime);

        if (HasReachedTarget(_places[_index]))
            NextPlace();
    }

    private void NextPlace()
    {
        _index = ++_index % _places.Length;
        transform.forward = _places[_index].position;
    }

    public bool HasReachedTarget(Transform position)
    {
        return (position.position - transform.position).sqrMagnitude > Threshold * Threshold;
    }
}
