using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElegyController : MonoBehaviour
{
    private string[,] elegy; 
    public TextMeshProUGUI elegyLine;  

    // Start is called before the first frame update
    void Start()
    {
        elegy = new string[3,1];
        //elegyLine = " ";
    }

    //called in the Word class
    public void addToElegy(string textAdd, int sceneNum){
        elegy[sceneNum,0] = elegy[sceneNum,0] + textAdd;
        //below should also display on screen
        elegyLine.text = elegy[sceneNum,0];
        }

    // called in objectmover
    public void addLine(){
        elegyLine.text = elegyLine.text +"f";
    }

    public string returnElegy() {
    string result = ""; // Store all rows

    for (int row = 0; row < elegy.GetLength(0); row++) {
        string line = "";
        
        for (int col = 0; col < elegy.GetLength(1); col++) {
            line += elegy[row, col] + " "; // Append words from the row
        }
        
        result += line.Trim() + "\n"; // Add each row to the result
    }

    return result.Trim(); // Remove trailing newline
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
