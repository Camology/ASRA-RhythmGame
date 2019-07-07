using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSpawnScript : MonoBehaviour
{
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.Find("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other) {
         if (other.tag == "Player")
            moveFloor();
     }

     void moveFloor() {
         
         floor.transform.position = new Vector3(gameObject.transform.position.x+10,
                                                     gameObject.transform.position.y, 
                                                     gameObject.transform.position.z);
                                               
     }

}
