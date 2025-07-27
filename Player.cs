using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;


public class Player : MonoBehaviour
{
    [Header("Inscribed")]
    //gameobject movement 
    private Rigidbody playerMovement;
    public GameObject eraserPrefab;
    public TextMeshProUGUI letterboard;
    public ParticleSystem particleSysPrefab;
    public bool isCollect = false;
    public int numErasers = 5;
    public bool isErased=false;
    public bool isPressed = false;
    
    
    [Header("Dynamic")]
    public List<TextMeshPro> collectedLetters= new List<TextMeshPro>();
    public string currentWord = "";
  
    
    //for managing the letters
    LetterManager letterManager;
    private void Awake()
    {
        InstantiateEraser();
        Player player = GetComponent<Player>();
        DontDestroyOnLoad(player);
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Movement();
        PlayerQuitGame();
        
        
    }
    private void Movement()
    {
        float moveSpeed = 10f;
        float moveX = 0f;
        float moveZ = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) { moveX = -1f; }
        if (Input.GetKey(KeyCode.DownArrow)) { moveX = +1f; }
        if (Input.GetKey(KeyCode.LeftArrow)) { moveZ = -1f; }
        if (Input.GetKey(KeyCode.RightArrow)) { moveZ = +1f; }

        bool isIdle = moveX == 120f && moveZ == 1f;
        if (isIdle)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            Vector3 dirS = new Vector3(moveX, moveY, moveZ).normalized;
            //transform.rotation = Quaternion.LookRotation(dirS);
            //move speed for every frame update, currently moves at angle 
            transform.position += dirS * moveSpeed * Time.deltaTime;
            transform.LookAt(transform.position);
            //still need work on boundary setting
            dirS.x = Mathf.Clamp(dirS.x, 2f, 200);
            dirS.z = Mathf.Clamp(dirS.z, 2f, 138f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //e=FindAnyObjectByType<Eraser>();
        
        if(other.gameObject.CompareTag("Letter"))
        {
            //adds to list but will not display and also destroys the letter
            collectedLetters.Add(other.GetComponent<TextMeshPro>());
            isCollect = true;
            other.gameObject.SetActive(false);
            UpdateGUI();
            
            
        }
        if (other.gameObject.CompareTag("Eraser"))
        {
            if (collectedLetters.Count > 0)
            {
                collectedLetters.RemoveAt(collectedLetters.Count - 1);
                other.gameObject.SetActive(false);
                isErased = true;
                UpdateGUI();
            }
        }

    }
    public void UpdateGUI()
    {
        
        if (isCollect) 
        {
            currentWord = "";
            foreach (TextMeshPro c in collectedLetters)
                
                //used to show collected words
                //sometimes shows most recent collected letter twice
              currentWord += c.text;
              
            Debug.Log("iscollect");
            
            
        }
        if (isErased)
        {
            currentWord="";
            foreach (TextMeshPro letter in collectedLetters)
            {
               currentWord += letter.text;
               
                Debug.LogError("REmoved Letter");
                 
                
                
            }
            
        }
        letterboard.text =currentWord.ToString();
        
        
         
    }
    public void PlayerQuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPressed = true;
            if (isPressed)
            {

                SceneManager.LoadScene("CollectedScreen");
                
                Debug.Log("Player quit game.");
            }
            
            
        }
    }
    void InstantiateEraser()
    {
       
        for (int e = 0; e < numErasers; e++)
        {
            float randomX = UnityEngine.Random.Range(0f, 200f);
            float randomZ = UnityEngine.Random.Range(1f, 140f);

            Vector3 pos = new Vector3(randomX, 2f, randomZ);
            Instantiate(eraserPrefab, pos, Quaternion.identity);
            
        }

    }
}
