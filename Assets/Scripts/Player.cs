using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    private CharacterController _cController;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _lookSensitivity = 50f;
    [SerializeField] private float _runSpeed = 16;
    [SerializeField] private float _runTime = 2f;
    [SerializeField] private float _jumpForce = 10f;
    
    private float _startRunTime;
    public bool _isRun = false;
   
    private Camera _fpscam;
    private float _lookX = 0f;
    private float _lookY = 0f;
    float _horizontalInput;
    float _verticalInput;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _cController = GetComponent<CharacterController>();
        _fpscam = Camera.main;

    }//Awake
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        _startRunTime = _runTime;
        
        

    }//Start

    // Update is called once per frame
    private void Update()

    {
        PlayerMove();
        PlayerLookY();
        PlayerLookX();
        Run();
        
        
        
    }//Update
    private void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(_verticalInput <= 0 ) 
            {
                _isRun = false;

                return;
            }
            
            _isRun = true;

        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRun = false;
            

        }
        if(_isRun == true)
        {
            _runTime -= Time.deltaTime;
            if(_runTime < 0)
            {
                _runTime = 0;
                _isRun = false;
            }
        }
        else
        {
            _runTime += Time.deltaTime;
            if(_runTime >= _startRunTime)
            {
                _runTime = _startRunTime;
            }

        }
    }//run
    private void PlayerMove()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if(_isRun == false)
        {
            Vector3 moveDirection =new Vector3(_horizontalInput,0f,_verticalInput);
            Vector3 velocity = moveDirection * _moveSpeed;
            velocity.y -= _gravity;
            velocity = transform.transform.TransformDirection(velocity);
            _cController.Move(velocity*Time.deltaTime); 
        }
        else
        {
            Vector3 moveDirection =new Vector3(_horizontalInput,0f,_verticalInput);
            Vector3 velocity = moveDirection * _runSpeed;
            velocity.y -= _gravity;
            velocity = transform.transform.TransformDirection(velocity);
            _cController.Move(velocity*Time.deltaTime);
             
        }
        
        
    }//PlayerMove
    private void PlayerLookY()
    {
        
        _lookY += Input.GetAxis("Mouse X") * _lookSensitivity * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0f,_lookY,0f);

    }//PlayerLookY
    private void PlayerLookX()
    {
        
        _lookX -= Input.GetAxis("Mouse Y") * _lookSensitivity * Time.deltaTime;
        _lookX = Mathf.Clamp(_lookX,-55f,40f);
   
         _fpscam.transform.localEulerAngles = new Vector3(_lookX,0f,0f);
       
    }//PlayerLookX
    private void PlayerJump()
    {
        

    }//PlayerJump

    
}//Class
