using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;

    private float fwdInput;
    private float fwdMagnitude;
    private float colorMagnitude;
    private Rigidbody rb;
    private GameObject focalPoint;
    private Renderer rndr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        rndr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        fwdInput = Input.GetAxis("Vertical");
        fwdMagnitude = fwdInput * speed * Time.deltaTime;
        colorMagnitude = Mathf.Abs(fwdInput);
        rb.AddForce(focalPoint.transform.forward * fwdMagnitude, ForceMode.Force);
        rndr.material.color = new Color(1f - colorMagnitude, 1f,1f - colorMagnitude);
    }
}
