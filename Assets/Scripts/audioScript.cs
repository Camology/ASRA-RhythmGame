using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class audioScript : MonoBehaviour
{
    public GameObject hazard;
    [SerializeField] private int spawnDistance;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bpmScript processor = FindObjectOfType<bpmScript>();
        processor.onBeat.AddListener (onOnbeatDetected);
        audioSource = FindObjectOfType<AudioSource>();
        spawnDistance = 10;
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
    
    // Update is called once per frame
    void Update()
    {
    }

    void createHazard() {
        GameObject hazardInstance = (GameObject)Instantiate(hazard);
        hazardInstance.transform.position = new Vector3(hazardInstance.transform.position.x + spawnDistance,
                                                        -0.15f,
                                                        0);
    }
}
