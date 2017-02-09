using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grabber : MonoBehaviour
{
    [SerializeField]
    ConstructorController constructor;

    [SerializeField]
    Transform grabTransform;

    [SerializeField]
    KeyCode grabCode;

    Grabable grabbed;
    Grabable grabableInRange;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grabCode))
        {
            if (grabbed == null && grabableInRange != null)
                Grab(grabableInRange);
            else
                Drop();
        }
    }

    void Grab(Grabable grabbed)
    {
        if (this.grabbed == null && grabbed.transform.parent == null)
        {
            this.grabbed = grabbed;
            constructor.Mass += grabbed.Mass;
            grabbed.transform.parent = grabTransform;
            grabbed.transform.position = grabTransform.position;
            grabbed.Grab();
        }
    }

    void Drop()
    {
        if (grabbed != null)
        {
            grabbed.transform.parent = null;
            constructor.Mass -= grabbed.Mass;
            grabbed.Drop();
            grabbed = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Grabable grabable = collision.gameObject.GetComponent<Grabable>();

        if(grabable != null && grabable.transform.parent == null)
        {
            Debug.Log("Grabbable in sight!");
            grabableInRange = grabable;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Grabable grabable = collision.gameObject.GetComponent<Grabable>();

        if (grabable != null && grabable == this.grabableInRange)
        {
            grabableInRange = null;
        }
    }
}
