using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    WallController[] walls;
    
    // Start is called before the first frame update
    void Start()
    {
        walls = (WallController[]) FindObjectsOfType<WallController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<WallController>())
        {
            // call lose function
        }
        if (collision.gameObject.CompareTag("boxpowerup"))
        {
            foreach (WallController wall in walls)
            {
                wall.MoveBack();
            }
        }
    }
}
