using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] Text Score;
    int score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "deck")
        {
            Destroy(other.gameObject);
            score ++;
            Score.text = score.ToString();
        }
    }
}
