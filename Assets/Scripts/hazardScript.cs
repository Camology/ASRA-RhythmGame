using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardScript : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private Rigidbody rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody =  GetComponent<Rigidbody>();
        acceleration = 8;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(-acceleration, 0f, 0f, ForceMode.Acceleration);
        if (gameObject.transform.position.x < -10) {
            Destroy(gameObject);
        }
    }
}
