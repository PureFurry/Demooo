using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormMovement : MonoBehaviour
{
    public float platformMoveSpeed;
    public void MovetoLeft(){
        Debug.Log("It's WOrk");
        transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(50,0), platformMoveSpeed);
    }
}
