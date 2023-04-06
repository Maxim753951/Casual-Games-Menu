using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOnClick : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown() // вызывается при клике на объект/экран мышкой/Тачем
    {
        _animator.SetTrigger("Alarm");
    }
}
