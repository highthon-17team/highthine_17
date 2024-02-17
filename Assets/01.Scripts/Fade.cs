using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    public Image Panel;

    public void FadeIn()
    {
        Panel.DOFade(0, 3);
    }

    public void FadeOut()
    {
        Panel.DOFade(1, 3);
    }
}
