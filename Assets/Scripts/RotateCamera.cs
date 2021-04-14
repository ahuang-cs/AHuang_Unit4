using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 30f;
    private float rotateInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * speed * Time.deltaTime);
    }
}
