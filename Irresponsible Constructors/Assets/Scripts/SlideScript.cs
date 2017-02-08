using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : MonoBehaviour
{
    [SerializeField]
    float slideThreshold;

    [SerializeField]
    CubeManager cubeManager;

    ConstructorController constructorController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {/*
        if(constructorController)
        {
            Debug.Log("Dot: " + Vector2.Dot(constructorController.FloorController.RightDirection, Vector2.right));
            Debug.DrawRay(transform.position, constructorController.FloorController.RightDirection * 2, Color.red);
            Debug.DrawRay(transform.position, Vector2.right * 2, Color.blue);
            if (Vector2.Dot(constructorController.FloorController.RightDirection, Vector2.right) < slideThreshold)
            {
                constructorController.GoRight();
            }
            else if(Vector2.Dot(constructorController.FloorController.LeftDirection, Vector2.left) < slideThreshold)
            {
                constructorController.GoLeft();
            }
        }*/
    }

    public void OnEnable()
    {
        cubeManager.ConstructorControllerAddedEvent += OnConstructorControllerAssign;
        cubeManager.ConstructorControllerDeletedEvent += OnConstructorControllerDestroyed;
    }

    public void OnDisable()
    {
        cubeManager.ConstructorControllerAddedEvent += OnConstructorControllerAssign;
        cubeManager.ConstructorControllerDeletedEvent += OnConstructorControllerDestroyed;
    }

    private void OnConstructorControllerAssign(ConstructorController constructorController)
    {
        this.constructorController = constructorController;
    }

    private void OnConstructorControllerDestroyed()
    {
        constructorController = null;
    }

}
