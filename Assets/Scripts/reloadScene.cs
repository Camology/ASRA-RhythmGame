using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void reload() {
         SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
}
