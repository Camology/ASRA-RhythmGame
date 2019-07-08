using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScript : MonoBehaviour
{
    [SerializeField] private Vector3 jumpVelocity ;
    public bool onGround;
    private Rigidbody rigidBody;
    public AudioSource crashSound;

    private int score;
    public TextMeshProUGUI scoreText;
    public bool gamePaused;

    // Start is called before the first frame update
    void Start() {
        rigidBody =  GetComponent<Rigidbody>();
        gamePaused = false;
        jumpVelocity = new Vector3(1,9,0);   
    }

    // Update is called once per frame
    void FixedUpdate() {
        scoreUpdate();
    }

    void Update() {
        if (onGround && Input.GetButtonDown("Jump")) {
            rigidBody.AddForce(jumpVelocity, ForceMode.VelocityChange);
            onGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {
                Time.timeScale = 1;
                Camera.main.GetComponent<AudioSource>().UnPause();
                gamePaused=false;
            }
            else {
                Time.timeScale = 0;
                Camera.main.GetComponent<AudioSource>().Pause();
                gamePaused = true;
            }
        }        
    }

    void scoreUpdate(){
        score+=1;
        scoreText.text = "Score: " + score.ToString();
        if (score < 0) {
            score = 0;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor")
            onGround = true; 
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Floor")
            onGround = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Hazard") {
            crashSound.Play(0);
            Destroy(other.gameObject);
            score-=50;
        }   
    }
}
