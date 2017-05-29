using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCS : MonoBehaviour {

    public float velocity = 100;
    public float maximumVelocity = 20;
    public float rotationSpeed = 5;

    public float testVX = 0;
    public float testVY = 0;

    public bool sideScroller = false;
    public float boundTop, boundBottom, boundLeft, boundRight;
    public float boundTopCam, boundBottomCam, boundLeftCam, boundRightCam;
    public Camera mainCamera;
    public GameObject projectile;
    public Transform weaponSpawn;

    private Rigidbody2D rb2d;
    public float timeSinceLastFire;
    public float timeBetweenFiring = 10;
    public bool isDead = false;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        Physics.gravity = new Vector3(1f, 0f, 0f);
    }
	
	// Update is called once per frame. 
	void Update () {
        CheckInputs(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        CheckLocation();
        CheckCameraLocation();
        
    }

    private void CheckCameraLocation()
    {
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(rb2d.transform.position.x, rb2d.transform.position.y, mainCamera.transform.position.z);
            if (mainCamera.transform.position.x > boundRightCam)
            {
                mainCamera.transform.position = new Vector3(boundRightCam, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            if (mainCamera.transform.position.x < boundLeftCam)
            {
                mainCamera.transform.position = new Vector3(boundLeftCam, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            if (mainCamera.transform.position.y > boundTopCam)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, boundTopCam, mainCamera.transform.position.z);
            }
            if (mainCamera.transform.position.y < boundBottomCam)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, boundBottomCam, mainCamera.transform.position.z);
            }
            
        }
            
    }

    private void CheckLocation()
    {
        if(rb2d.position.x > boundRight)
        {
            rb2d.position = new Vector2(boundRight, rb2d.position.y);
        }
        if(rb2d.position.x < boundLeft)
        {
            rb2d.position = new Vector2(boundLeft, rb2d.position.y);
        }
        if (rb2d.position.y > boundTop)
        {
            rb2d.position = new Vector2(rb2d.position.x, boundTop);
        }
        if(rb2d.position.y < boundBottom)
        {
            rb2d.position = new Vector2(rb2d.position.x, boundBottom);
        }
    }

    private void CheckInputs(float horizontalInput, float verticalInput)
    {
        if (horizontalInput != 0)
        {
            if (sideScroller)
            {
                if (horizontalInput > 0)
                    rb2d.AddForce(-transform.right * horizontalInput * velocity);
                else
                    rb2d.AddForce(-transform.right * horizontalInput * velocity);
            }
            else
            {
                if (horizontalInput > 0)
                    rb2d.rotation -= rotationSpeed;
                else
                    rb2d.rotation += rotationSpeed;
            }
            
        }

        if (verticalInput != 0)
        {
            testVX = rb2d.velocity.x;
            testVY = rb2d.velocity.y;
            var bOk = true;
            if (rb2d.velocity.x > maximumVelocity)
                rb2d.velocity = new Vector2(maximumVelocity, rb2d.velocity.y);
            else if (rb2d.velocity.x < -maximumVelocity)
                rb2d.velocity = new Vector2(-maximumVelocity, rb2d.velocity.y);
            if (rb2d.velocity.y > Math.Abs(maximumVelocity))
                rb2d.velocity = new Vector2(rb2d.velocity.x, maximumVelocity);
            else if (rb2d.velocity.y < -(maximumVelocity))
                rb2d.velocity = new Vector2(rb2d.velocity.x, -maximumVelocity);
            if (bOk)
                rb2d.AddForce(-transform.up * verticalInput * velocity);
        }
        else
            rb2d.velocity = Vector2.zero;

        if (Input.GetButton("Jump") && CanFire())
            Fire();
        timeSinceLastFire += Time.deltaTime;
    }

    private bool CanFire()
    {
        return timeSinceLastFire >= timeBetweenFiring;
    }

    private void Fire()
    {
        timeSinceLastFire = 0;
        Instantiate(projectile, weaponSpawn);
    }
}
