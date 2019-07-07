using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardScript : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private Rigidbody rigidBody;
    public AudioSource crashSound;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody =  GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(-acceleration, 0f, 0f, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            crashSound.Play(0);
            Destroy(gameObject);    
    }
}
