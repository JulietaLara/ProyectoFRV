using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO.Ports;

public class IAProfe : MonoBehaviour
{
    SerialPort serialport= new SerialPort("COM3",9600);
    public float time;
    public GameObject Roja;
    public  GameObject gameOver;
    public bool scanning = false;
    private Animator animator;
    private bool seTomaPosicionInicial = false;
    public float magnitude;
    public Vector3 x_final;
    public Vector3 x_inicial;
    private Vector3 resta;
    
    // Start is called before the first frame update
    void Start()
    {
        serialport.Open();
        serialport.ReadTimeout=1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(VoltearAlFrente());
        if (scanning) {
            Debug.Log("Escaneando...");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log(player.transform.position); 
            
            if (this.seTomaPosicionInicial == false) {
                x_inicial = player.transform.position; 
                Debug.Log("Tomando pos inicial...");
                this.seTomaPosicionInicial = true; 
            }
            x_final = player.transform.position; 
            resta = x_final - x_inicial;
            Debug.Log(resta.magnitude); 

            if(resta.magnitude > 0.0035f) {
                //game over, enviar la regla al jugador, que envie la señal al arduino y active el canva de game over
                Debug.Log("Perdiste manco");
                        if(serialport.IsOpen){

                            try{


                                serialport.WriteLine("1");
              
                            }
                            catch{

                             }
                        }        
                Invoke("canvas",time);
            }
          
        } 
    }

    IEnumerator VoltearAlFrente()
    {
        if (scanning == false) {
            yield return new WaitForSeconds(5);
            animator.SetBool("voltearFrente", true);
            animator.SetBool("volearAtras",false);
            Roja.SetActive(true);
            scanning = true;
            this.seTomaPosicionInicial = false;
            yield return new WaitForSeconds(5);
            animator.SetBool("volearAtras",true);
            animator.SetBool("voltearFrente", false);
            
            //yield return new WaitForSeconds(2);
            Roja.SetActive(false);
            scanning = false;
            this.seTomaPosicionInicial = false;
        }
    }

    public void canvas(){
        gameOver.SetActive(true);
    }
    

  
}
