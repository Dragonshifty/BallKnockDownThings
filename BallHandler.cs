using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{

    

    // [SerializeField] private Rigidbody2D currentBallRigidBody;
    // [SerializeField] private SpringJoint2D currentBallSpringJoint;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;

    [SerializeField] private float detachDelay = 0.15f;
    [SerializeField] private float respawnDelay;

    private Rigidbody2D currentBallRigidBody;
    private SpringJoint2D currentBallSpringJoint;

    private Camera mainCamera;
    private bool isDragging;
    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewBall();
    }


    void Update()
    {
        if (currentBallRigidBody == null){
            return;
        }

        if (!Touchscreen.current.primaryTouch.press.isPressed){
            if(isDragging){
                LaunchBall();
            }
            
            isDragging = false;
            return;
        }

        isDragging = true;

        currentBallRigidBody.isKinematic = true;

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        currentBallRigidBody.position = worldPosition;

        
        
    }

    private void LaunchBall(){
        currentBallRigidBody.isKinematic = false;
        currentBallRigidBody = null;

        // Invoke("DetachBall", detachDelay);
        Invoke(nameof(DetachBall), detachDelay);
    }

    private void DetachBall(){
        currentBallSpringJoint.enabled = false;
        currentBallSpringJoint = null;

        Invoke(nameof(SpawnNewBall), respawnDelay);
    }

    private void SpawnNewBall(){
        GameObject ballInstance =  Instantiate(ballPrefab, pivot.position, Quaternion.identity);

        currentBallRigidBody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();

        currentBallSpringJoint.connectedBody = pivot;
    }
}
