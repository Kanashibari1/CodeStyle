using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform AllPlaces;
    [SerializeField] private Transform[] arrayPlaces;

    private float _speed = 2f;
    private int _currentPosition;

    void Start()
    {
        arrayPlaces = new Transform[AllPlaces.childCount];

        for (int i = 0; i < AllPlaces.childCount; i++)
            arrayPlaces[i] = AllPlaces.GetChild(i);
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, arrayPlaces[_currentPosition].position, _speed * Time.deltaTime);

        if (transform.position == arrayPlaces[_currentPosition].position) 
            NextPlace();
    }
    public void NextPlace()
    {
        _currentPosition = ++_currentPosition % arrayPlaces.Length;
    }
}
