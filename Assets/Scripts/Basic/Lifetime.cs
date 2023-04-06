using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[" + Time.time + "] Start - " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("[" + Time.time + "] Update - " + gameObject.name);
    }
}

