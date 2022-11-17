using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class conectar : MonoBehaviour
{
    public GameObject Joystick;
	public float RotY = 90f;
 
 
	public float PosIni = 0.5f; 
    SerialPort serialport= new SerialPort("COM5",9600);
    public float smooth = 20.0F;
    // Start is called before the first frame update
    void Start()
    {
        serialport.Open();
        serialport.ReadTimeout=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(serialport.IsOpen){

            try{
                string value = serialport.ReadLine();
                print(value);
                string[] vec6=value.Split(',');
               //Quaternion target = Quaternion.Euler(Convert.ToInt32(vec6[4]), 0, Convert.ToInt32(vec6[5]));
               //Joystick.transform.localRotation = Quaternion.Slerp(Joystick.transform.localRotation, target, Time.deltaTime * smooth);
            }
            catch{

            }
        }
    }
}
