// Snake game code created by following the "How to make Snake in Unity (Complete Tutorial) 🐍🍎" tutorial by Press Start at https://www.youtube.com/watch?v=U8gUnpeaMbQ&t=38s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int initialSize;

    WallController[] walls;

    AudioSource playerAudio;
    [SerializeField] AudioClip wallback;

    private void Start(){
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        for(int i = 1; i < this.initialSize; i++){
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        walls = (WallController[])FindObjectsOfType<WallController>();

        playerAudio = GetComponent<AudioSource>();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            _direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            _direction = Vector2.right;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            _direction = Vector2.left;
        }
    }


    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--){
            _segments[i].position = _segments[i-1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

    }

    private void Reset(){
        for(int i = 1; i < _segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for(int i = 1; i < this.initialSize; i++){
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Food"){
            Grow();
        }
        else if(other.tag == "Obstacle"){
            Reset();
        }
        else if (other.gameObject.CompareTag("boxpowerup"))
        {
            playerAudio.PlayOneShot(wallback);
            foreach (WallController wall in walls)
            {
                wall.MoveBack();
            }
        }
    }
}


