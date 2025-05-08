using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    [Tooltip("Populate with sequence of images")]
    public List<Texture2D> myTextures = new List<Texture2D>();
    [Tooltip("Speed of sequence of images")]
    public float speed = .1f;
    [Tooltip("Start sequence at frame")]
    public int startingFrame;
    private int counter;
    private bool isTalking;
    public GameObject angel;
    //public GameObject player;

    //private int timesMoved;

    // Start is called before the first frame update
    //THISISBROKEN 
    void Start()
    {
        counter = startingFrame;
        InvokeRepeating("ImageCycler", 0, speed);
        isTalking = false;
        //player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
       //angel.transform.LookAt(player.transform);
       //Debug.Log(counter);
    }
    public void ImageCycler()
    {
        if(isTalking){ // NEED TO MAKE IT SO THE COUNTER IS SET TO 2 in the first place 
            if (counter < myTextures.Count-1 && counter > 1)
                counter++;
            else counter = 2;
        }
        else{
            if (counter < myTextures.Count - 3 )
                counter++;
            else counter = 0;
        }
       
        this.gameObject.transform.GetComponent<Renderer>().material.SetTexture("_MainTex", myTextures[counter]);
    }

    public void EndCutscene(bool talk){
        isTalking = talk;
        counter = 2;
    }

    public void setCounter(int count){
        counter = count;
    }

    
    //Vector3(-20.7999992,4.40757513,28.2700005)

}
