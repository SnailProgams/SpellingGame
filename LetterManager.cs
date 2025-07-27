using NUnit.Framework;
using TMPro;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class LetterManager : MonoBehaviour
{

    //list for letter game objects, creates a list for the inspector plane for letters 
    [Header("Inscribed")]
    public List<TextMeshPro> LETTERLIST;
    public List<TextMeshPro> COMMONLIST;    //for top ten commonly used letters
   
    
        
    
    private void Start()
    {
      
        InstantiateLetters();           //instantiates list but all at same coordinates at the moment
        InstantiateCommonLetters();
    }
       
    void InstantiateLetters()
    {
        LETTERLIST = new List<TextMeshPro>(Resources.LoadAll<TextMeshPro>("Letters"));
        //goes through each element 
        foreach (TextMeshPro l in LETTERLIST)
        {
            //for bounds for letters, and at different places  
            float randomX = UnityEngine.Random.Range(0f, 200f);
            float randomZ = UnityEngine.Random.Range(1f, 140f);
            Vector3 randomPos = new Vector3(randomX, 2f, randomZ);
            Instantiate(l, randomPos, Quaternion.Euler(0, -100f, 0));
       
        }
    }
   void InstantiateCommonLetters()
    {
        COMMONLIST = new List<TextMeshPro>(COMMONLIST);
        foreach(TextMeshPro cl in COMMONLIST)
        {
            float randomX = UnityEngine.Random.Range(0f, 200f);
            float randomZ = UnityEngine.Random.Range(1f, 140f);
            Vector3 randomPos = new Vector3(randomX, 2f, randomZ);
            Instantiate(cl, randomPos, Quaternion.Euler(0, -100f, 0));
        }
    }
   

}
