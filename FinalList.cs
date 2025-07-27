using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
public class FinalList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    Player p;
    public List<TextMeshPro> FINALLIST;
    public TextMeshProUGUI finalBoard;
    public GameObject playerPrefab;

    // Update is called once per frame
    private void Awake()
    {
        p = FindAnyObjectByType<Player>();

        if (p != null)
        {
            LoadFinalList();
        }




    }
    //void Update()
    //{
    //    if (p != null)
    //    {

    //        LoadFinalList();
    //    }
    //}
    void LoadFinalList()
    {
        string word = ""; 
        //FINALLIST = new List<TextMeshPro>();
        
        FINALLIST = p.collectedLetters;
        foreach (TextMeshPro f in FINALLIST)
        {
           
            word += f.text;
            
        }
        finalBoard.text = word.ToString();
    }
}
