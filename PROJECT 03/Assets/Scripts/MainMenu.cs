using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainMenuSwitch("MainMenu"));
    }
    

    IEnumerator MainMenuSwitch(string sceneName)
    {
        // Wait for 5 seconds before returning
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneName);
    }
}
