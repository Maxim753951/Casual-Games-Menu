using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // С рейкастами работаем через специальный фасад Физикс
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up); // передавая Vector2.up работали глобальные координаты и луч всегда святил из точки в верх
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        // для отладки и просмотра куда летит луч
        Debug.DrawRay(transform.position, transform.up * 10, Color.red);

        if (hit)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
