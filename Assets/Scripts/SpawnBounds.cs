using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBounds : MonoBehaviour
{
    public Transform boundSpace;
    [SerializeField] float sizeAdjustAmt = 1f;
    public Vector3 originalSize;
    // Start is called before the first frame update
    void Start()
    {
        boundSpace = gameObject.GetComponent<Transform>();
        originalSize = boundSpace.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustSize();
    }

    void AdjustSize()
    {
        boundSpace.localScale -= new Vector3(sizeAdjustAmt * Time.deltaTime, sizeAdjustAmt * Time.deltaTime);
    }
}
