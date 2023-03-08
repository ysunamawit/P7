// Snake game code created by following the "How to make Snake in Unity (Complete Tutorial) 🐍🍎" tutorial by Press Start at https://www.youtube.com/watch?v=U8gUnpeaMbQ&t=38s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Snake : MonoBehaviour
{
    public Vector2 _direction = Vector2.right;
    public List<Transform> _segments;
    public Transform segmentPrefab;
    public int initialSize;
    private bool _isPaused = false;
    private Color originalColor;
    private int segmentCount = 3;

    WallController[] walls;

    AudioSource playerAudio;
    [SerializeField] AudioClip wallback;
    [SerializeField] AudioClip monch;
    [SerializeField] AudioClip die;

    private Color[] rainbowColors = new Color[] {
        new Color(1f, 0.5f, 0.5f),     
        new Color(1f, 0.75f, 0.5f),    
        new Color(1f, 1f, 0.5f),       
        new Color(0.5f, 1f, 0.5f),    
        new Color(0.5f, 0.5f, 1f),    
        new Color(0.75f, 0.5f, 1f),   
        new Color(1f, 0.5f, 1f)
    };

    private int colorIndex = 0;

    private void Start(){
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        for(int i = 1; i < this.initialSize; i++){
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        walls = (WallController[])FindObjectsOfType<WallController>();

        playerAudio = GetComponent<AudioSource>();

        originalColor = GetComponent<SpriteRenderer>().color;
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
        if (!_isPaused) {
            for(int i = _segments.Count - 1; i > 0; i--){
                _segments[i].position = _segments[i-1].position;
            }
            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + _direction.x,
                Mathf.Round(this.transform.position.y) + _direction.y,
                0.0f
            );
        } 
        else {
            foreach(Transform segment in _segments){
                segment.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segmentCount++;
        if (segmentCount % 4 == 0) {
            colorIndex++;
            if (colorIndex >= rainbowColors.Length) {
                colorIndex = 0;
            }
        }
        segment.GetComponent<SpriteRenderer>().color = rainbowColors[colorIndex];
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Food"){
            playerAudio.PlayOneShot(monch);
            Grow();
            Food gridArea = FindObjectOfType<Food>();
            gridArea.gridAreaOriginal();
            
        }
        else if(other.tag == "Obstacle"){
            playerAudio.PlayOneShot(die);
            StartCoroutine(ShowSnakeSizeAndLose());
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

    IEnumerator ShowSnakeSizeAndLose() {
        _isPaused = true; 
        yield return new WaitForSeconds(2.0f); 
        _isPaused = false; 
        SceneManager.LoadScene("Snake");
    }
}


