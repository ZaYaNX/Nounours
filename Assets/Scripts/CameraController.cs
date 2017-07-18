using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    Vector3 offset;
    GameObject Player;
    [SerializeField]
    float minPosX;
    [SerializeField]
    float maxPosX;
    [SerializeField]
    float minPosY;
    [SerializeField]
    float maxPosY;
    
    void Start ()
    {
        Player = GameObject.Find("Player");
        offset = transform.position - Player.transform.position;
	}
	
	void Update ()
    {
		
	}

    void LateUpdate()
    {
        Vector3 CameraPosition = Player.transform.position + offset;
        if (CameraPosition.y < minPosY)
        {
            CameraPosition.y = minPosY;
        }
        if (CameraPosition.y > maxPosY)
        {
            CameraPosition.y = maxPosY;
        }
        if (CameraPosition.x < minPosX)
        {
            CameraPosition.x = minPosX;
        }
        if (CameraPosition.x > maxPosX)
        {
            CameraPosition.x = maxPosX;
        }
        transform.position = CameraPosition;
    }
}
