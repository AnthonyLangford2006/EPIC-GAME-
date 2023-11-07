using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Collectable : MonoBehaviour
{
    public TMP_Text textscore;
    public float score;


    private void Start()
    {
        score = 0f;
        textscore.text = score.ToString() + " Soul Coins";

    }

    private void Update()
    {
        textscore.text = score.ToString() + " Soul Coins";
    }






}
