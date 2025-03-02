using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;

public class Carr_Controller : MonoBehaviour
{

    public WheelCollider[] wheels = new WheelCollider[4];
    public float torque = 200;
    public float steeringMax = 4;

    bool canPlay = true;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Game_Controller.instance.isPlaying)
        {
            if (Input.GetKey(KeyCode.W))
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = torque;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = -torque;
                }
            }
            else
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = 0;
                }
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                for (int i = 0; i < wheels.Length - 2; i++)
                {
                    wheels[i].steerAngle = Input.GetAxis("Horizontal") * 4;
                }
            }
        }


    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Starting"))
        {
            col.isTrigger = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Finish"))
        {
            Game_Controller.instance.endGame();
        }
    }


}
