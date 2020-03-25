﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{
    public static DialogueManager Instance;
    public CanvasGroup dialogueCanvas;
    public float letterDelay;
    public float dialogueDelay;
    public float dialogueAfterDelay;
    public Image image;
    public Text title;
    public Text textbox;
    private Queue<DialogueLine> lines;
    
    void Awake(){
        Instance = this;
    }

    void Start(){
        lines = new Queue<DialogueLine>();
        StartCoroutine(EndDialogue());
    }

    public void StartDialogue(Dialogue dialogue){
        lines.Clear();
        dialogueCanvas.alpha = 1;

        foreach(DialogueLine line in dialogue.lines){
            lines.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(lines.Count==0){
            StartCoroutine(EndDialogue());
            return;
        }

        DialogueLine line = lines.Dequeue();
        image.sprite = line.sprite;
        title.text = line.name;
        StopAllCoroutines();
        StartCoroutine(TypeText(line.sentence));

        //StartCoroutine(ContinueToNextSentence()); in TypeText()
    }
    IEnumerator TypeText(string text){
        textbox.text = "";
        foreach(char c in text.ToCharArray()){
            textbox.text += c;
            yield return new WaitForSeconds(letterDelay);
        }
        StartCoroutine(ContinueToNextSentence());
    }
    IEnumerator ContinueToNextSentence(){
        yield return new WaitForSeconds(dialogueDelay);
        DisplayNextSentence();
    }
    

    IEnumerator EndDialogue(){
        yield return new WaitForSeconds(dialogueAfterDelay);
        dialogueCanvas.alpha = 0;
    }
}
