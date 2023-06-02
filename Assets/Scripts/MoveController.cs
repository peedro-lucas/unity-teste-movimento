using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidadeCorrida = 9;
    public float velocidadeSuper = 15;

    public new Camera camera;

    public Animator anim;
    private Rigidbody rb;

    [SerializeField]
    private float velocidadeAtual;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        velocidadeAtual = velocidade;
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");
        var camrot = camera.transform.rotation;
        Vector3 direcao = new Vector3(inputX, 0, inputZ);


        if (inputX != 0 || inputZ != 0) {
            {
                camrot.x = 0;
                camrot.z = 0;
                anim.SetBool("walk", true);
                transform.Translate(0, 0, velocidade * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcao) * camrot, 5 * Time.deltaTime);

                //transform.Translate(new Vector3(inputX, 0, inputZ) * Time.deltaTime * velocidadeAtual, Space.Self);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("run", true);
                    velocidadeAtual = velocidadeCorrida;

                }

                //else if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyUp(KeyCode.Space))
                //{
                //    anim.SetBool("walk", false);
                //    anim.SetBool("run", true);
                //    velocidadeAtual = velocidadeSuper;

                //}
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    anim.SetBool("walk", true);
                    anim.SetBool("run", false);
                    velocidadeAtual = velocidade;

                }
            }

        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }
    } 
