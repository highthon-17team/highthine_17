using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;
    public GameObject Player;
    public GameObject Dialogue;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);
    }

    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < 3f)
        {
            if(Input.GetKeyDown(KeyCode.F))
            { 
                Trigger();
                Dialogue.SetActive(true);
            }
        }
    }
}
