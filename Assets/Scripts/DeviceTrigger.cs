using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        NotifyTargets("Activate");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        NotifyTargets("Deactivate");
    }

    private void NotifyTargets(string message)
    {
        foreach (var target in targets)
            target.SendMessage(message);
    }

}
