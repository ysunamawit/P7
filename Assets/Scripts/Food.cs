// Snake game code created by following the "How to make Snake in Unity (Complete Tutorial) 🐍🍎" tutorial by Press Start at https://www.youtube.com/watch?v=U8gUnpeaMbQ&t=38s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start(){
        RandomizePosition();
    }

    private void RandomizePosition(){
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            RandomizePosition();
        }
    }
}
