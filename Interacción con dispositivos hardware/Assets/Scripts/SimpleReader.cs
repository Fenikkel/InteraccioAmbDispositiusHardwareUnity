using UnityEngine;
//using System;
//using System.Collections;
using System.IO.Ports;
//using System.Collections.Generic;

public class SimpleReader : MonoBehaviour {


    private SerialPort stream = new SerialPort("COM4", 9600);
    
	private string arduinoResponse= "Quiet";
    private Rigidbody rb;
    public float speed;
    float moveHorizontal = 0.0f;
    float moveVertical = 0.0f;



    public void Start () { 
        stream.ReadTimeout = 100;
        stream.Open();
        rb = GetComponent<Rigidbody>();

    }

	

	
	// Update is called once per frame
	void Update () {
		arduinoResponse = stream.ReadLine();

		Debug.Log(arduinoResponse);
	}


    void FixedUpdate()
    {
        

        if (arduinoResponse.Equals("Derecha"))
        {
            moveHorizontal = -1;
        }else if (arduinoResponse.Equals("Izquierda"))
        {
            moveHorizontal = 1;
        }
        else if (arduinoResponse.Equals("Quiet") //Si falla es por culpa de este else if que lo he puesto a hojo que no encuentro el archivo donde hice estas modificaciones (y ahora no tengo el arduino para comprobarlo)
        {
            moveHorizontal = 0;
        }

        if(arduinoResponse.Equals("Atras"))
        {
            moveVertical = 1;
        }else if (arduinoResponse.Equals("Delante"))
        {
            moveVertical = -1;
        }
        else if(arduinoResponse.Equals("Quiet")) //Si falla es por culpa de este else if que lo he puesto a hojo que no encuentro el archivo donde hice estas modificaciones (y ahora no tengo el arduino para comprobarlo)
        {
            moveVertical = 0;
        }

        //moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Debug.Log(moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
