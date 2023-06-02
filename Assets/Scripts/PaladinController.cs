using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinController : MonoBehaviour
{
    public static float velocidade = 5;



    public new Camera camera;

    public Animator anim;
    private Rigidbody rb;

    [SerializeField]

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");
        var camrot = camera.transform.rotation;
        Vector3 direcao = new Vector3(inputX, 0, inputZ);


        if (inputX != 0 || inputZ != 0) {
            
                camrot.x = 0;
                camrot.z = 0;
                transform.Translate(0, 0, velocidade * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcao) * camrot, 5 * Time.deltaTime);
                anim.SetBool("idle", false);
                anim.SetBool("run", true);
                anim.SetBool("attack", false);
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("idle", true);
            anim.SetBool("attack", false);
        }
    }
    } 
