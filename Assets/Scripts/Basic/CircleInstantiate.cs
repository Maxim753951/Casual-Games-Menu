using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    public GameObject Template;

    public int Count;

    public float Radius;

    private void Start()
    {
        int angleStep = 360 / Count;

        for (int i = 0; i < Count; i++)
        {
            GameObject newObject = Instantiate(Template, new Vector3(0, 0, 0), Quaternion.identity); // вернули ссылку на созданный объект
            // можно передать созданный объект, тогда он склонируется, или компонент - он скопируется
        
            Transform newObjectTransform = newObject.GetComponent<Transform>();

            newObjectTransform.position = new Vector3(Radius * Mathf.Cos(angleStep * (i + 1) * Mathf.Deg2Rad), Radius * Mathf.Sin(angleStep * (i + 1) * Mathf.Deg2Rad), 0);
            // косинус работает на радианах
        }

    }
}
