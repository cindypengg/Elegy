using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelMover : MonoBehaviour
{
    public ChangeTexture angel; 
    //public KeyboardMoveCharacter character;
    public int timesMoved;
    public ElegyController controller;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other){
        moveAngel(timesMoved);
        //timesMoved++;
    }

    public void moveAngel(int timesMoved){
        if(timesMoved==0){
            //angel.transform.position =- angel.transform.position;
            angel.transform.localPosition = new Vector3(-3f,3f,20f);
            angel.transform.eulerAngles = new Vector3(0,10,0);
            //Debug.Log("new Position:" + angel.transform.position);
        }
        else if (timesMoved ==1){
            controller.addLine();
            Debug.Log("hello");
            //character.transform.localPosition = new Vector3(-24f,0.37f,11f);
            angel.transform.localPosition = new Vector3(-48f,1.7f,30f);
            //character
        }
        else if (timesMoved ==2){
            //character.transform.localPosition = new Vector3(-24f,0.37f,11f);
            angel.transform.localPosition = new Vector3(2f,-1.86f,18f);
            //character
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
