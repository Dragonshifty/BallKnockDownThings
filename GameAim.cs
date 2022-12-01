using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAim : MonoBehaviour
{
    // private void Start(){
    //     SceneManager.LoadScene(0);
    // }

    public int timer = 10;
    public static int currentLevel = 0;

    // void Start(){
    //     SceneManager.LoadScene(currentLevel);
    // }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("top")){
            Invoke(nameof(NewScene), 1);
        }

        
    }
    
    // gaffa tape solution
    private void NewScene(){
        try {
            SceneManager.LoadScene(++currentLevel);
        } catch {
            SceneManager.LoadScene(0);
            currentLevel = 0;
        }
        
        // if (currentLevel < 7){
        // SceneManager.LoadScene(++currentLevel);
        // } else {
        //     SceneManager.LoadScene(0);
        //     currentLevel = 0;
        // }
    }

    
    
}
