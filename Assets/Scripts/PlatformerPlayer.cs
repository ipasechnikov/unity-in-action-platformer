using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 4.5f;
    public float jumpForce = 12.0f;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;

        var max = box.bounds.max;
        var min = box.bounds.min;
        var corner1 = new Vector2(max.x, min.y - .1f);
        var corner2 = new Vector2(min.x, min.y - .2f);
        var hit = Physics2D.OverlapArea(corner1, corner2);
        var grounded = hit != null;

        // Turn off gravity while standing on the ground
        body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0)) ? 0 : 1;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        var platform = hit != null ? hit.GetComponent<MovingPlatform>() : null;
        transform.parent = platform?.transform;

        anim.SetFloat("speed", Mathf.Abs(deltaX));

        var pScale = Vector3.one;
        if (platform != null)
            pScale = platform.transform.localScale;

        if (!Mathf.Approximately(deltaX, 0))
            transform.localScale = new Vector3(
                Mathf.Sign(deltaX) / pScale.x,
                1 / pScale.y,
                1 / pScale.z
            );
    }
}
