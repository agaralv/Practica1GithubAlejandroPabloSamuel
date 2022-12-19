using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class Pelota : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float _incrementVelocity = 1f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocityPrev;
    private const float _effectAngle = 15;

    // DEBUG public float iniX, iniY; 

    private void Awake()
    {
        GameManager.Instance.Ball = this;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch()
    {
        float v = Random.Range(0.4f, 1f);
        // cara o cruz --> (Random.Range(0, 2) == 0 ? -1 : 1)
        float x = v * (Random.Range(0, 2) == 0 ? -1 : 1);
        //v = Random.Range(0.4f, 1f);
        float y = v * (Random.Range(0, 2) == 0 ? -1 : 1);
        transform.position = Vector2.zero;
        _rigidbody2D.velocity = velocity * (new Vector2(x, y)).normalized;
        _velocityPrev = _rigidbody2D.velocity;
        // DEBUG max speed for ghost _rigidbody2D.velocity = new Vector2(x * velocity * 5, 0);
        // DEBUG effect _rigidbody2D.velocity = new Vector2(iniX, iniY);
    }

    private void FixedUpdate()
    {
        _velocityPrev = _rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // rebote en dirección de la fuerza de repulsión con incremento de velocidad
            //_rigidbody2D.velocity = col.relativeVelocity + Accelerate(col.relativeVelocity);
            // cambio de dirección del rebote artificial horizontal
            //_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -_rigidbody2D.velocity.y);

            // rebote en dirección opuesta a la última velocidad prevía al choque, con incremento de velocidad (con independencia de la velocidad de la pala)
            _rigidbody2D.velocity = _velocityPrev + Accelerate(_velocityPrev);
            // cambio de dirección del rebote artificial horizontal
            _rigidbody2D.velocity = new Vector2(-_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);

            // cambios de ángulo con col.collider.sharedMaterial.name
            Vector2 v = _rigidbody2D.velocity;
            switch (col.collider.sharedMaterial.name)
            {
                case "mid":
                    break;
                case "top":
                    // Incrementa el "efecto" hacia los lados: rotación de la velocidad "hacia afuera"
                    if (_velocityPrev.y > 0)
                    {
                        if (_velocityPrev.x > 0)
                        {
                            v = Quaternion.AngleAxis(-_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                        else
                        {
                            v = Quaternion.AngleAxis(_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                    }
                    else
                    {
                        if (_velocityPrev.x > 0)
                        {
                            v = Quaternion.AngleAxis(_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                        else
                        {
                            v = Quaternion.AngleAxis(_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                    }
                    // TODO: corregir angulo minimo de salida
                    _rigidbody2D.velocity = v;
                    break;
                case "bot":
                    // Incrementa el "efecto" hacia los lados: rotación de la velocidad "hacia afuera"
                    if (_velocityPrev.y > 0)
                    {
                        if (_velocityPrev.x > 0)
                        {
                            v = Quaternion.AngleAxis(_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                        else
                        {
                            v = Quaternion.AngleAxis(-_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                    }
                    else
                    {
                        if (_velocityPrev.x > 0)
                        {
                            v = Quaternion.AngleAxis(-_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                        else
                        {
                            v = Quaternion.AngleAxis(-_effectAngle, Vector3.forward) * _rigidbody2D.velocity;
                        }
                    }
                    _rigidbody2D.velocity = v;
                    break;
            }
            Debug.Log(col.collider.sharedMaterial.name);
        }
        if (col.gameObject.CompareTag("suelo") || col.gameObject.CompareTag("techo"))
        {
            // rebote genérico en dirección de la fuerza de repulsión
            //_rigidbody2D.velocity = col.relativeVelocity;
            // cambio de dirección del rebote artificial vertical
            //_rigidbody2D.velocity = new Vector2(-_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);

            // rebote en dirección opuesta a la última velocidad prevía al choque (con independencia de la velocidad de la pala)
            _rigidbody2D.velocity = _velocityPrev;
            // cambio de dirección del rebote artificial vertical
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -_rigidbody2D.velocity.y);
        }
    }

    private Vector2 Accelerate(Vector2 velocity)
    {
        return _incrementVelocity * velocity.normalized;
    }

    private void OnDrawGizmos()
    {
        // DEBUG
        Gizmos.color = Color.red;
        if (_rigidbody2D != null)
        {
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + _rigidbody2D.velocity);
        }
    }
}
