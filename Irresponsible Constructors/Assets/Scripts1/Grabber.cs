using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grabber : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rigidBody;

    [SerializeField]
    Transform grabTransform;

    Grabable grabbed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Drop();
        }
    }

    void Grab(Grabable grabbed)
    {
        if (this.grabbed == null && grabbed.transform.parent == null)
        {
            this.grabbed = grabbed;
            rigidBody.mass = rigidBody.mass + grabbed.Mass;
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
            grabbed.Drop();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Grabable  grabable = collision.gameObject.GetComponent<Grabable>();

        if(grabable != null)
        {
            Grab(grabable);
        }
    }
}
