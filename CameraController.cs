using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float followSpeed = 2f;
    public float yOffset = 2f;
    public float xOffset = 2f;
    private Vector3 lastPlayerPos;
    private float distanceToMovex;
    private float distanceToMovey;

    // Start is called before the first frame update
    void Start()
    {
        /*        lastPlayerPos = player.transform.position;
                transform.position = new Vector3(lastPlayerPos.x + 2f, transform.position.y, transform.position.z);*/
    }

    // Update is called once per frame
    void Update()
    {
        OldCamera();
        //LerpCamera();
    }

    void OldCamera()
    {
        distanceToMovex = player.transform.position.x - lastPlayerPos.x;
        distanceToMovey = player.transform.position.y - lastPlayerPos.y;
        transform.position = new Vector3(transform.position.x + distanceToMovex, transform.position.y + distanceToMovey, transform.position.z);
        lastPlayerPos = player.transform.position;
    }

    void LerpCamera()
    {
        Vector3 newPos = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, -1f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}