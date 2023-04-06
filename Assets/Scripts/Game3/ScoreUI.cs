using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _field;

    private int _score = 0;

    //private Platform test;

    private void Awake()
    {
        _field = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _field.text = _score.ToString();

        //test = GetComponent<Platform>();
    }

    public void IncreaseScore()
    {
        _score += 1;
        _field.text = _score.ToString();
        //test.moveSpeed += 1f;
    }
}
