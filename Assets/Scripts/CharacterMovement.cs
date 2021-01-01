using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 p1EndPosition;
    private Vector3 p2EndPosition;

    private float speed = 10f;
    private bool moving = false;

    private GameObject player1;
    private GameObject player2;

    public void initializePlayers(GameObject p1, GameObject p2)
    {
        player1 = p1;
        player2 = p2;
    }
    
    void Start()
    {
        p1EndPosition = new Vector3(2, 0, -4);
        p2EndPosition = new Vector3(-2, 0, -4);
    }
    
    void Update()
    {
        if (moving)
        {
            float step = speed * Time.deltaTime;

            player1.transform.position = Vector3.MoveTowards(player1.transform.position, p1EndPosition, step);
            player2.transform.position = Vector3.MoveTowards(player2.transform.position, p2EndPosition, step);

            if (player1.transform.position == p1EndPosition && player2.transform.position == p2EndPosition)
                moving = false;
        }
        
    }

    public void MoveToEndPosition()
    {
        moving = true;
    }

    public void StopMovement()
    {
        moving = false;
    }

}
