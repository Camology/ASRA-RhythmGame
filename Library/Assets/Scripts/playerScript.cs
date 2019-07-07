using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private Vector3 jumpVelocity;
    public bool onGround;
    private Rigidbody rigidBody;
    public float distance;
    // Start is called before the first frame update
    void Start() {
        rigidBody =  GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate() {
		if (onGround) {
            rigidBody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

    void Update() {
        if (onGround && Input.GetButtonDown("Jump")) {
            rigidBody.AddForce(jumpVelocity, ForceMode.VelocityChange);
            onGround = false;
        }
        distance = transform.localPosition.x;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor")
            onGround = true;    
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Floor")
            onGround = false;
    }
}
