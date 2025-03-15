using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneTransition.SwitchToScene("MenuScene");
        }
    }

    public void GoToGame()
    {
        SceneTransition.SwitchToScene("SampleScene");
    }
}
