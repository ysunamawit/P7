using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISnake : MonoBehaviour
{
    [SerializeField] Snake realSnake;
    public Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int size;

    private void Start()
    {

    }

    private void Update()
    {
        size = realSnake._segments.Count;
    }


    public void CreateUISnake()
    {
        _segments = new List<Transform>();
        for (int i = 0; i < size; i++)
        {
            Debug.Log("I am creating UI snake segments bruh");
            Transform tempSeg = Instantiate(segmentPrefab, transform);
            _segments.Add(tempSeg);
        }
        for (int i = 0; i < _segments.Count; i++)
        {
            _segments[i].position = new Vector3(-i, 0);
        }
        /*
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        for (int i = 1; i < this.size; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
        */
    }

}
