using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 vectorToMove;
    [SerializeField] private int speed = 1;
    [SerializeField] private float energy;
    private float currentpeso;
    [SerializeField] private float reposo = 5f;
    private bool reposando = false;

    void Start()
    {
        energy = 100;
    }
    void Update()
    {
        if (!reposando)
        {
            transform.position = Vector2.MoveTowards(transform.position, vectorToMove, speed * Time.deltaTime);
        }
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
        yield return new WaitForSeconds(reposo);
        energy = 100;
        reposando = false;
    }

    public void SetPeso(float peso)
    {
        currentpeso = peso;
    }
}
