using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour 
{

    GameObject Player;

	// Use this for initialization
	void Start () 
	{
        this.Player = GameObject.Find("cat");
        Vector3 playerPos = this.Player.transform.position;
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () 
	{
        Vector3 playerPos = this.Player.transform.position;
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
	}
}
