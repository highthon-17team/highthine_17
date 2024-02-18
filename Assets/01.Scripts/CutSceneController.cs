using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject Txt;
    public void OffCutScene()
    {
        player.enabled = true;
        gameObject.SetActive(false);
        Txt.SetActive(true);
    }
}
