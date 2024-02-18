using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtSentence;
    public GameObject panel;

    Queue<string> sentences = new Queue<string> ();

    public void Begin(Dialogue info)
    {
        sentences.Clear ();

        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue (sentence);
        }

        Next();
    }

    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
        }

        txtSentence.text = sentences.Dequeue ();
    }

    private void End()
    {
        panel.SetActive(false);
    }
}
