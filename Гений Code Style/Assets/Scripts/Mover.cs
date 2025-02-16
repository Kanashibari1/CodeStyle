using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _allPlaces;
    [SerializeField] private Transform[] _arrayPlaces;

    private float _speed = 2f;
    private int _currentPosition;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlaces.childCount];

        for (int i = 0; i < _allPlaces.childCount; i++)
            _arrayPlaces[i] = _allPlaces.GetChild(i);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _arrayPlaces[_currentPosition].position, _speed * Time.deltaTime);

        if (transform.position == _arrayPlaces[_currentPosition].position) 
            NextPlace();
    }

    private void NextPlace()
    {
        _currentPosition = ++_currentPosition % _arrayPlaces.Length;
    }
}
