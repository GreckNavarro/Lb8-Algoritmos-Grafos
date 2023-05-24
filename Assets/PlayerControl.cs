using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 vectorToMove;
    [SerializeField] private int speed = 1;
    [SerializeField] private float reposo = 5f;

    private float energy;
    private float currentpeso;

    private bool reposando = false;

    private SpriteRenderer sp;
    private Color colorInicial;

    void Start()
    {
        energy = 100;
        sp = GetComponent<SpriteRenderer>();
        colorInicial = sp.color;
    }
    void Update()
    {
        if (!reposando)
        {
            transform.position = Vector2.MoveTowards(transform.position, vectorToMove, speed * Time.deltaTime);
        }
    }
    public void SetPeso(float peso)
    {
        currentpeso = peso;
    }
    public void ChangeMovePosition(Vector2 destiny)
    {
        vectorToMove = destiny;
        energy -= currentpeso;
        Debug.Log(energy);
        if(energy <= 0)
        {
            StartRestTime();
        }

    }
    private void StartRestTime()
    {
        if (!reposando)
        {
            StartCoroutine(RestartCoroutine());
        }
    }

    private  IEnumerator RestartCoroutine()
    {
        reposando = true;
        sp.color = Color.red;
        yield return new WaitForSeconds(reposo);
        energy = 100;
        reposando = false;
        sp.color = colorInicial;
    }


}
