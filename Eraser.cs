using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

using UnityEngine.UI;

public class Eraser : MonoBehaviour
{
    //public bool isErased = false;
    //Player p;
    //TextMeshPro tmp;
    //Eraser E;


    //private void Start()
    //{
    //    E = GetComponent<Eraser>();
    //    E = this;

    //    if (p == null)
    //    {
    //        p = FindAnyObjectByType<Player>();


    //    }
    //    if (tmp != null)
    //    {
    //        tmp = FindAnyObjectByType<TextMeshPro>();
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == 6)
    //    {
    //        Debug.LogError("letter should be erased");
    //        if (p.collectedLetters.Count > 0)
    //        {
    //            Debug.Log("Letter erased");

    //            p.collectedLetters.RemoveAt(p.collectedLetters.Count - 1);
    //            isErased = true;
    //            Destroy(E);
    //            NewUpdateGUI();
    //        }

    //    }
    //}
    //public void NewUpdateGUI()
    //{
    //    //rebuilds currentword from collected letters list

    //    if (isErased)
    //    {
    //        Debug.Log("new update works");
    //        p.currentWord = "";

    //        foreach (TextMeshPro letter in p.collectedLetters)
    //        {
    //            p.currentWord += letter.text;
    //            p.letterboard.text = p.letterboard + p.currentWord.ToString();
    //        }
    //        //update ui
            
    //    }
    //}


}
