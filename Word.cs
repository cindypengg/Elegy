using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.IO;
using JetBrains.Annotations;

public class Word : MonoBehaviour
{
    public TextMeshPro word; 

    //noun = 1, verb, adj, adv, conju
    public int wordNum;
    public ElegyController controller;
    private List<string> words = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

        //word = GetComponent<TextMeshPro>();
        //word.text="hi";
        LoadWords();
        //elegy = null;

        if(words.Count>0){
            System.Random random = new System.Random();
            string RandomWord = words[random.Next(words.Count)];
            word.text = RandomWord;
        }
    }

    void LoadWords(){

        //assign type of word based on the number input in
        String wordType = null;
        switch (wordNum){
            case 1:
                wordType = "nouns";
                break;
            case 2:
                wordType = "verbs";
                break;
            case 3:
                wordType = "adjectives";
                break;
            case 4:
                wordType = "adverbs";
                break;
            case 5: 
                wordType = "conjunctions";
                break;
            default:
                Console.WriteLine("nouns");
                break;
        }
        
        string path = Path.Combine(Application.streamingAssetsPath, wordType +".txt");

        if(File.Exists(path)){
            words.AddRange(File.ReadAllLines(path));
        }
        else{
            Debug.LogError("poo");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player"){
            word.gameObject.SetActive(false);
             string currentText = word.text; 
             //only applies to first scene;
             controller.addToElegy(currentText + " ",1);
            //add to the elegy file 

            //ElegyController.elegy = ElegyController.elegy + " " + currentText;
            //Debug.LogError(Housekeeping.elegy);
            //GlobalVariables.elegy= GlobalVariables.elegy + " " + currentText;
            /*
            string elegyPath = Path.Combine(Application.streamingAssetsPath, "elegy.txt");
            using (StreamWriter writer = new StreamWriter(elegyPath, true))
        {
            writer.WriteLine("\n"+currentText);
        }*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
