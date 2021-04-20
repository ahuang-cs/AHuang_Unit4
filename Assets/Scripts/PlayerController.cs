using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    public float powerUpSpeed = 10f;
    public float powerUpSecs = 8f;
    public GameObject powerUpIndicator;

    private float fwdInput;
    private float fwdMagnitude;
    private float colorMagnitude;
    private Rigidbody rb;
    private GameObject focalPoint;
    private Renderer rndr;
    

    private bool isPoweredUp = false;

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
        
        powerUpIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            isPoweredUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpTimer());
            powerUpIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isPoweredUp && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with " + collision.gameObject + " while Powered Up");
            
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 repulsionDirection = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(repulsionDirection * powerUpSpeed, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerUpTimer()
    {
        Debug.Log("PowerUpTimer started for " + powerUpSecs + " secs!");
        yield return new WaitForSeconds(powerUpSecs);
        isPoweredUp = false;
        powerUpIndicator.SetActive(false);
    }
}
