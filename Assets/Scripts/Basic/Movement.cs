using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // что бы скомпенсировать задержку Фрэймов и сделать движения более плавными и при прогрузке игры, когда она залагает, что бы движения как бы просимулировалось, сделаем:
    [SerializeField] private float _speed; // скорость указывающая сколько юнитов (условных единииц) игрок преодолеет за одну секунду

        private void Update()
    {
        // при работе с клавой используется старая система, где каждый кадр проверяется не нажата ли кнопка
        // это делается с помощью фасада Input и 3-х основных методов

        //Input.GetKey(KeyCode.D); // возвращает true если клавиша зажата

        // на основе компонента transform будем двигать персонажа (менять позицию через метод translate)

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }
}