using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;

    private Vector3 startPos;
    private float trackPercent = 0;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        trackPercent += direction * speed * Time.deltaTime;
        var x = (finishPos.x - startPos.x) * trackPercent + startPos.x;
        var y = (finishPos.y - startPos.y) * trackPercent + startPos.y;
        transform.position = new Vector3(x, y, startPos.z);

        if ((direction == 1 && trackPercent > .9f) || (direction == -1 && trackPercent < .1f))
            direction *= -1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, finishPos);
    }
}
