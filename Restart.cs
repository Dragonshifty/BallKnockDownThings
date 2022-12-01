using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
    //     GameAim.currentLevel;
    //     SceneManager.LoadScene(currentLevel);
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnCollisionEnter2D(Collision2D other) {
        
            SceneManager.LoadScene(GameAim.currentLevel);
        
    }
}

