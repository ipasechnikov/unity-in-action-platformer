using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDevice : MonoBehaviour
{
    [SerializeField] Vector3 dPos;

    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if (open)
            return;

        transform.position -= dPos;
        open = true;
    }

    public void Deactivate()
    {
        if (!open)
            return;

        transform.position += dPos;
        open = false;
    }
}
