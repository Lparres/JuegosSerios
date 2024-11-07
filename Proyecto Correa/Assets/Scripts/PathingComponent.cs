using System.Collections;
using UnityEngine;

public class PathingComponent : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _path;
    [SerializeField] private float _timeToWait;

    private int nextNum_;
    private int direction = 1;  // Dirección: 1 para avanzar, -1 para retroceder

    void Start()
    {
        nextNum_ = 0;
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        while (true)
        {
            // Mover hacia el punto de destino
            while (transform.position != _path[nextNum_].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _path[nextNum_].position, Time.deltaTime * _moveSpeed);
                yield return null;
            }

            yield return new WaitForSeconds(_timeToWait);

            // Generar el próximo punto en la ruta
            GenerateNextPoint();
        }
    }

    private void GenerateNextPoint()
    {
        if (nextNum_ == 0)
        {
            direction = 1;  // Cambiar dirección a avanzar
            Debug.Log("Empiezo / NextNum: " + nextNum_);
        }
        else if (nextNum_ == _path.Length - 1)
        {
            direction = -1;  // Cambiar dirección a retroceder
            Debug.Log("Vuelvo / NextNum: " + nextNum_);
        }

        // Avanzar o retroceder el punto de acuerdo a la dirección
        nextNum_ += direction;
        Debug.Log("Siguiente Pos: " + nextNum_);
    }
}
