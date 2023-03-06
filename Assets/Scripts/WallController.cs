using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float speed = 5f;

    [SerializeField] Vector3 moveBackDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        /* test code
        if (Input.GetMouseButtonDown(0))
        {
            MoveBack();
        }
        */
    }

    void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void MoveBack()
    {
        transform.position = new Vector3(transform.position.x + moveBackDistance.x, transform.position.y + moveBackDistance.y, transform.position.z + moveBackDistance.z);
    }
}
