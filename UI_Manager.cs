using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System;


//need to add update gui

public class UI_Manager : MonoBehaviour
{
    public bool pausedGame = false;
   
    public bool isPressed = false;
   



    public void NewGame()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
    //quits game
    public void StartGame()
    {
        SceneManager.LoadScene("GameScreen");
    }
    public void QuitGame()
    {
            Application.Quit();
        Debug.Log("Quiting Game.");
        SceneManager.LoadScene("CollectedScreen");  //may need to swap back to endScreen
        
        
    }
   public void SendtoFinalScreen()
    {
        SceneManager.LoadScene("EndScreen");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScreen");
        
    }
}
