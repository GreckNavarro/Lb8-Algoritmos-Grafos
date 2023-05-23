using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listaNodeAdyacentes;
    public List<float> listapesos;
    void Start()
    {
        
    }

    void Update()
    {
      
    }

    public (NodeControl,float) SelectNextNode()
    {
        int nodeSelected = Random.Range(0, listaNodeAdyacentes.Count);
        return (listaNodeAdyacentes[nodeSelected], listapesos[nodeSelected]);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            NodeControl currentNode = SelectNextNode().Item1;
            collision.GetComponent<PlayerControl>().ChangeMovePosition(currentNode.transform.position);
            collision.GetComponent<PlayerControl>().SetPeso(SelectNextNode().Item2);
        }
    }
}
