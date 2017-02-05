using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawMechanic : MonoBehaviour
{
    [SerializeField]
    List<MassObject> objectsOnSeeSaw;

    [SerializeField]
    Vector3 centerPoint;

    [SerializeField]
    Rigidbody2D rb;

    float gravity = 9.8f;

    void Awake()
    {
        objectsOnSeeSaw = new List<MassObject>();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        List<MassObject> leftObjects = new List<MassObject>();
        List<MassObject> rightObjects = new List<MassObject>();

        float left = 0;
        float right = 0;
        int i = 0;
        foreach(var massObject in objectsOnSeeSaw)
        {
            i++;
            Vector2 distanceVector = ((Vector2)massObject.transform.position - (Vector2)centerPoint);
            distanceVector.Scale(Vector2.right);
            Debug.Log(string.Format("Distance vector {0}: {1}", i, distanceVector));
            if (distanceVector.x < 0) {
                left += distanceVector.magnitude * massObject.Mass * gravity;
            }
            else if(distanceVector.x > 0)
            {
                right += distanceVector.magnitude + massObject.Mass * gravity;
            }
        }

        float turn = left - right;
        Debug.Log("left: " + left);
        Debug.Log("right: " + right);
        Debug.Log("turn: " + turn);
        transform.Rotate(0, 0, turn * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        MassObject massObject = collision.gameObject.GetComponent<MassObject>();

        if (massObject != null)
        {
            objectsOnSeeSaw.Add(massObject);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        MassObject massObject = collision.gameObject.GetComponent<MassObject>();

        if (massObject != null)
        {
            objectsOnSeeSaw.Remove(massObject);
        }
    }
}
