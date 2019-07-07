using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class audioScript : MonoBehaviour
{
    public float[] samples;
    public AudioSource audioSource;
    public float audioCutOff;
    public GameObject hazard;
    [SerializeField] private int spawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        samples = new float[512];
    }

    // Update is called once per frame
    void Update()
    {
        getSpectrumAudioSource();
        foreach (float f in samples) {
            if (f > audioCutOff){
                createHazard(f);
            }

        }
    }

    void getSpectrumAudioSource() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void createHazard(float f) {
        GameObject hazardInstance = (GameObject)Instantiate(hazard);
        hazardInstance.transform.position = this.transform.position;
        int randDist = Random.Range(10,30);
        hazardInstance.transform.position = new Vector3(hazardInstance.transform.position.x + spawnDistance + randDist,
                                                        0,
                                                        0);  
        hazardInstance.transform.parent = this.transform;
        hazardInstance.name = "Hazard "+f;
    }
}
