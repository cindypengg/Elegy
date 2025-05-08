using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshPro dialogue;
    private string[] activeText; 
    private string[] scene2;
    private string[] scene3;
    private string[] scene4;
    private string[] scene5;
    private string[] scene6;
    public int sceneCounter;
    private int lineNum;
    public bool inCutscene;
    public int lineIndex; 
    public KeyboardMoveCharacter character;
    public ChangeTexture angel;
    public GameObject collider;
    public ElegyController elegy;

    // Start is called before the first frame update
    void Start()
    {
        //sceneCounter =1; 
        dialogue.gameObject.SetActive(false);
        activeText = new string[]{
            "Hi! I’ve been waiting for you!",
            "My name is R., I’ll be your elegy angel today. I heard you want to write an elegy for someone, or something.",
            "Just to start off, a lot of people think that it has to be a poem of... lament for the dead.",
            "But really, it's not! I mean it can be, but more precisely it's a poem of serious reflection. They are usually pretty sad though",
            "Yada yada, corporate wants me to say that. But if we're talking as friends, it can be anything you want.",
            "Let's get started! We’re going to go around and find some words for you to use in your message, okay?",
            "Collect as many or as few words as you want, just by walking in front of them in the order you want them to be written.",
            "Be gentle! They scare easily, and you might collect a word you don’t intend if you’re not careful.",
            "A bakery is the first location... where are all the cakes?",
            "I used to love cakes... and bread too! If I could still eat I would get some for us. There are only words now though...",
            "There are gonna be three locations in total. How corporate chooses them is a mystery to me, but maybe they'll mean something to you.",
            "Just meet me behind the counter when you’re done and I’ll take you to the next location."
        };
        
        scene2 = new string[]{
            "Nice first line...",
            "Oh, my outfit? Thanks!! I used to be pretty well known for my fashion...",
            "This place is kinda creepy... reminds me of a place I used to go to. I had some good memories there but...",
            "It looked really different back then. So it goes.",
            "Haha, the best words come from places like these though. Stay safe, okay?",
            "Not feeling too well, so I'll meet you in the bathroom..."
        };

        scene3 = new string[]{
            "Wow, the beach!!! Beautiful. I missed this place.",
            "I would stay here forever if I could...",
            "Okay, this is the last spot. Make your last words good! I mean, not your last words but... you know what I mean.",
        };

        scene4 = new string[]{
            "Okay, you're done! Nice job... can I read it? Yeah? Yay, thanks, this is my favorite part!",
            "... Wow... that's a really good one! If someone wrote this for me I would love it!",
            "Okay... I've got it. I'm gonna send your elegy off now okay?",
            "Hmm... I really wanna soak in this beach while I'm still here though. Don't know when I'll see it again.",
            "I'm gonna go sit by the water for a bit, come join me!"
        };
        scene5 = new string[]{
            "Ahhh... I forgot how good the sun feels on the beach! And the shells in the sand... so pretty.",
            "I hope I don't forget this when I go back.",
            "Wait, why are you crying?? Was the elegy you wrote that moving to you?",
            "It's because... of the places we just went? Why?",
            "Are you saying that we've met before? And I took you to all those places back then?",
            "I don't quite remember... I don't even know your name!",
            "There's a lot of things I don't remember.",
            "...",
            "I don't quite know what to say.",
            "I mean you know we'll see each other again, right?",
            "You don't even know if I'm real? I don't talk like I used to?",
            "I mean... I feel real to me! And does it even matter?",
            "You're sorry? I mean, I don't know what you did to me... or if you even did anything. So I can't... forgive you for that.",
            "Either way, even if I really do just live in your head... I hope that you'll be okay.",
            "But I mean, if it makes you feel better, I'll always be here... even if its just because you fabricated me.",
            "...",
            "Okay, I need to go now, alright? I'll help you out whenever you need to write another elegy, but I'm not going to remember you.",
            "Or remember the conversation we're having right now.",
            "I'm having more trouble remembering anything these days anyways.",
            "So I guess I'm not really ever coming back. In the way you wish I would.",
            "I'm really leaving now. Don't be silly, you can't come with me.",
            "Goodbye...",
            "Is that the first time we've said that to each other?",
            "...",
            "I'll see you around."
        };

        scene6 = new string[]{
            
        };


        if(sceneCounter ==2){
            activeText = scene2;
        }

        else if (sceneCounter == 3){
            activeText = scene3;
        }
        else if (sceneCounter == 4){
            activeText = scene4;
        }
        else if (sceneCounter ==5){
            activeText = scene5;
        }
         dialogue.text = activeText[0];
        lineIndex = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {

        if(inCutscene && Input.GetMouseButtonDown(0)){

            showNextDialogue(); 
        }
    }

    void OnTriggerEnter(Collider other){
        character.setMove(false);
        inCutscene = true;
        dialogue.gameObject.SetActive(true);
        if(!dialogue.text.Equals("...")){
            angel.EndCutscene(true);
        }
        
        }

    void showNextDialogue(){
        if(lineIndex < activeText.Length){
            dialogue.text = activeText[lineIndex];
            lineIndex++;
        }
        else{
            if(activeText == scene4 || activeText == scene5){
                angel.gameObject.SetActive(false);
            GameObject secondAngel = GameObject.FindGameObjectWithTag("sitting");
            if (secondAngel != null){
                 MeshRenderer secondAngelRenderer = secondAngel.GetComponent<MeshRenderer>();
                secondAngelRenderer.enabled = true; // Make it visible
            }
            else{
                Debug.LogWarning("Second Angel not found!");
            }
            }
            EndCutscene();
        }
    }

    void switchSceneDialogue(){
        
    }

    void EndCutscene(){
        character.setMove(true);
        dialogue.gameObject.SetActive(false);
        inCutscene = false;
        lineIndex = 0;
        sceneCounter++;
        //switchSceneDialogue();
        angel.EndCutscene(false);
        collider.SetActive(false);
        //angel.setCounter(0);
    }
}

