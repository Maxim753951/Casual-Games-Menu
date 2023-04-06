using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlocks : MonoBehaviour
{
    private void Start()
    {
        // ищем какие-то компонен6ты по определённому шаблону
        //var camera = GameObject.FindObjectOfType<Camera>(); // найти компонент с типом Камера

        GameObject block1 = GameObject.Find("Block1");

        Destroy(block1); // можем передать и => удалить компонент или целиком объект

        // так же можно искать по тегу (сделаем сразу для нескольких объектов)
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("BlockToDelete");

        foreach (GameObject block in blocks)
        {
            //Destroy(block);
            block.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}