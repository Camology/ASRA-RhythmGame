using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (AudioSource))]
public class audioScript : MonoBehaviour
{
    public GameObject hazard;
    [SerializeField] private int spawnDistance;
    private AudioSource audioSource;

    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        bpmScript processor = FindObjectOfType<bpmScript>();
        processor.onBeat.AddListener (onOnbeatDetected);
        audioSource = FindObjectOfType<AudioSource>();
        restartButton.onClick.AddListener(restartScene);
        restartButton.gameObject.SetActive(false);
    }


    //this event will be called every time a beat is detected.
	//Change the threshold parameter in the inspector
	//to adjust the sensitivity
	void onOnbeatDetected ()
	{
        createHazard();

	}

	//This event will be called every frame while music is playing
	void onSpectrum (float[] spectrum)
	{
		
	}

    void restartScene() {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else {
            restartButton.gameObject.SetActive(false);
        }
    }

    void createHazard() {
        GameObject hazardInstance = (GameObject)Instantiate(hazard);
        hazardInstance.transform.position = this.transform.position;
        hazardInstance.transform.position = new Vector3(hazardInstance.transform.position.x + spawnDistance,
                                                        -0.5f,
                                                        0);
    }
}
