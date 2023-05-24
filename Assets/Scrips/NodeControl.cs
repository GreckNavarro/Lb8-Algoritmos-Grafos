using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listaNodeAdyacentes;
    public List<float> listapesos;
    

    public (NodeControl,float) SelectNextNode()
    {
        int nodeSelected = Random.Range(0, listaNodeAdyacentes.Count);
        return (listaNodeAdyacentes[nodeSelected], listapesos[nodeSelected]);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            (NodeControl currentNode, float peso) = SelectNextNode();
            collision.GetComponent<PlayerControl>().SetPeso(peso);
            collision.GetComponent<PlayerControl>().ChangeMovePosition(currentNode.transform.position);


        }
    }
}
