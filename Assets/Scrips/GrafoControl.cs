using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafoControl : MonoBehaviour
{
    public List<NodeControl> allNodesControl;
    public NodeControl currentNodeControl;
    [SerializeField] PlayerControl player;

    private void Start()
    {
        player.ChangeMovePosition(currentNodeControl.gameObject.transform.position);
        
    }




}
