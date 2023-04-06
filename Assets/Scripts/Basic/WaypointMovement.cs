using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;

    [SerializeField] private float _speed; // настройка скорости (из Unity логично) метры в секунду

    [SerializeField] private Transform[] _points;

    private int _currentPoint;

    // удалить весь Start, если порядок точек планируется задавать вручкую
    void Start()
    {
        _points = new Transform[_path.childCount]; // с начала создадим массив по размеру подходящий для хранения всех точек
        // а потом через цикл переберём Transform (есть 2 варианта):

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        /* нам нужно индексное взаимодейские, так что этот вариант нахрен
        foreach (var childe in _path)
        {

        }
        */
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        /*
        var direction = (target.position - transform.position).normalized; // получаем направление движения в виде нормализованного вектора (вектора единичной длины)
        transform.position += direction; // производим движение прибавляя направление ксвоимпозициям
        но это запарный вариант можно проще
        */

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        // нам вернётся вектор промежуточной позиции между текущей и итоговой, смещённый на, так называемую, магнитуду

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
