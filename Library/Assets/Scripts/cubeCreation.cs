using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCreation : MonoBehaviour
{

    public GameObject cubePrefab;
    public GameObject audioManager;
    private GameObject[] cubeArray = new GameObject[512];
    public float maxScale;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        for (int i=0; i< 512; i++){
            GameObject cubePrefabInstance = (GameObject)Instantiate(cubePrefab);
            cubePrefabInstance.transform.position = this.transform.position;
            cubePrefabInstance.transform.parent = this.transform;
            cubePrefabInstance.transform.position = Vector3.right*i;
            cubePrefabInstance.name = "Sample "+i;
            cubeArray[i] = cubePrefabInstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i < 512; i++) {
            if (cubeArray != null) {
                cubeArray[i].transform.localScale = new Vector3(10, (audioManager.GetComponent<audioScript>().samples[i] * maxScale) +2, 10);
            }
        }
    }
}
