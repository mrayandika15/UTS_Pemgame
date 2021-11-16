using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

  //Variabel
    private float speed = 7f;
    public float x;
    public float z;

    [SerializeField] public float rotationSpeed;

    

    [SerializeField] private float gravitasi = -9.81f;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float speed_jump = 1f ;

    public bool isGrounded ;

     Vector3 velocity;
    
    
    //Referensi
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bergerak();
        gravity();
        lompat();
   
    }

      private void gravity ()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position , groundDistance , groundMask);
        
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
      
    }

    private void bergerak() 
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 gerakan = transform.right * x + transform.forward * z;
        controller.Move(gerakan * speed * Time.deltaTime);
        
        if (gerakan != Vector3.zero)
        {
            Quaternion muter = Quaternion.LookRotation(gerakan, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, muter, rotationSpeed * Time.deltaTime);
        }
        
    }

     private void lompat ()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(speed_jump * -2f * gravitasi);
        }
        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }



}
