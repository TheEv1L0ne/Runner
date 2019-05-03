using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED!");
        SceneManager.LoadScene(2);
    }
}
