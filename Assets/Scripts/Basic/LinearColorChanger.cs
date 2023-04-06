using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearColorChanger : MonoBehaviour
{
    //public SpriteRenderer Target; // при определении публичных полей
    //[SerializeField] private float _duration; // или приватных с атрибутом SerializeField
    // они начинают отображатья в Inspector в Unity

    // поскольку значие в любом случае возьмётся (в методе Start) и это неявное поведение пишем иначе:
    //private SpriteRenderer Target; // так или
    [HideInInspector] public SpriteRenderer Target; // так (прячем поле)

    [SerializeField] private float _duration;


    [SerializeField] private Color _targetColor;

    private float _runningTime;

    private Color _startColor;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>(); // вызываем GetComponent (взять компонент с текущего объекта) для необходимого компонента и помещаем ссылку на него в наше поле
                                                 // если нужно автоматически брать значения, а не названачть вручную в самом Unity (ну драгендропом)

        _startColor = Target.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime; // аккумулируем время между кадрами (точнее даже между частями кадра)
                                            // короче отсчитали сколько времени прошло

            float normalizeRunningTime = _runningTime / _duration; // типа % пройденного пути

            //в таком цветовом пространстве цвет это 4-х компонентный вектор

            //Color newColor = new Color(_targetColor.r * normalizeRunningTime, _targetColor.g * normalizeRunningTime, _targetColor.b * normalizeRunningTime);
            //Target.color = newColor;
            // изменим что бы переходить от начального чвета, а не от созданного чёрного

            Target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
        }
    }
}
