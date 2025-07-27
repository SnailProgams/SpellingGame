using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Timeline;
using Unity.VisualScripting;

public class TimeKeeper : MonoBehaviour
{
    [Header("Inscribed")]
    public float startTime= 120f;
    private float _currentTime;

    public bool activateTime = true;
    public TextMeshProUGUI timerText;

    public float endGameTime=0;
    private bool pausedGame=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         _currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (activateTime)
        {
            
            if (_currentTime > 0)
            {
                
                //keep seconds
                _currentTime -= Time.deltaTime;
                UpdatesTime();

            }
            else
            {
                _currentTime = 0f;
                EndGameTime();
            }
        
        }
        
    }
    public void UpdatesTime()
    {
       
        //need string to read format 
        TimeSpan t= TimeSpan.FromSeconds(_currentTime);
        timerText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
   
    void EndGameTime()
    {
        
        
        if (_currentTime    == endGameTime)
        {
            Time.timeScale = 0f;
            Debug.Log("Timer has ended, and game is quitting.");
            SceneManager.LoadScene("CollectedScreen");
        }
    }
    public void PauseGame()
    {
        if (pausedGame)
        {
            Time.timeScale = 1f;
            pausedGame = false;
        }
        else
        {
            Time.timeScale = 0f;
            pausedGame = true;

        }

    }
}
