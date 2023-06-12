using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUnityChan : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private float velocityZ = 16f;
    private float velocityX = 10f;
    private float movableRange = 3.4f;
    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputVelocityX = 0;
        if(Input.GetKey(KeyCode.LeftArrow) &&  -this.movableRange < this.transform.position.x )
        {
            inputVelocityX = -this.velocityX;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            inputVelocityX = this.velocityX;
        }
        this.myRigidbody.velocity = new Vector3(inputVelocityX, 0, this.velocityZ);
    }
}
