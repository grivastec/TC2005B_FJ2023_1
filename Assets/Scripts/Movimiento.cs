// estamos usando .NET
// aquí "importamos" namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// OJO 
// con esta directiva obligamos la presencia de un componente en el gameobject
// (todos tienen transform así que este ejemplo es redundante)
[RequireComponent(typeof(Transform))]
public class Movimiento : MonoBehaviour
{

    // va a haber situaciones en donde deba accedr a otro componente
    // voy a necesitar una referencia
    private Transform _transform;

    [SerializeField]
    private float _speed = 10;


    // ciclo de vida / lifecycle
    // - existen métodos que se invocan en momentos específicos de la vida del script
    
    // Se invoca una vez al inicio de la vida del componente 
    // otra diferencia - awake se invoca aunque objeto esté deshabilitado
    void Awake()
    {
        print("AWAKE");
    }

    // Se invoca una vez después que fueron invocados todos los awakes
    void Start()
    {
        Debug.Log("START");

        // como obtener referencia a otro componente

        // NOTAS:
        // - getcomponent es lento, hazlo la menor cantidad de veces posible
        // - con transform ya tenemos referencia (ahorita lo vemos)
        // - esta operación puede regresar nulo
        _transform = GetComponent<Transform>();
        
        // si tienes require esto ya no es necesario
        Assert.IsNotNull(_transform, "ES NECESARIO PARA MOVIMIENTO TENER UN TRANSFORM");
    }

    // Update is called once per frame
    // frame? cuadro?
    // fotograma
    // target mínimo - 30 fps
    // ideal - 60+ fps
    void Update(){
        //Debug.LogWarning("UPDATE");

        // SIEMPRE vamos a tratar que este sea lo más magro posible
        // update lo usamos para 2 cosas
        // 1 - entrada de usuario
        // 2 - movimiento

        // ahorita - vamos a hacer polling por dispositivo
        
        // true - cuando en el cuadro anterior estaba libre
        // y en este está presionada
        if(Input.GetKeyDown(KeyCode.Z))
        {
            print("KEY DOWN: Z");
        }

        // true - cuando en el cuadro anterior estaba presionada
        // y en el actual sigue presionada
        if(Input.GetKey(KeyCode.Z))
        {
            print("KEY: Z");
        }

        // true - estaba presionada
        // ya está libre
        if(Input.GetKeyUp(KeyCode.Z))
        {
            print("KEY UP: Z");
        }

        if(Input.GetMouseButtonDown(0))
        {
            print("MOUSE BUTTON DOWN");
        }

        if(Input.GetMouseButton(0))
        {
            print("MOUSE BUTTON");
        }

        if(Input.GetMouseButtonUp(0))
        {
            print("MOUSE BUTTON UP");
        }
        

        // vamos a usar ejes (después)
        // - mapeo de hardware a un valor abstracto llamado eje
        // rango [-1, 1]

        // hacemos polling a eje en lugar de hacerlo a hardware específico
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //print(horizontal + " " + vertical);

        // se pueden usar ejes como botones
        if(Input.GetButtonDown("Jump")){
            print("JUMP");
        }

        // como mover objetos 
        // 4 opciones 
        // 1 - directamente con su transform
        // 2 - por medio de character controller
        // 3 - por medio del motor de física
        // 4 - por medio de navmesh (AI)

        transform.Translate(_speed * Time.deltaTime, 0, 0, Space.World);
    }

    // fixed? - fijo
    // update que corre en intervalo fijado en la configuración del proyecto
    // NO puede correr más frecuentemente que update
    void FixedUpdate()
    {
        //Debug.LogError("FIXED UPDATE");
    }

    // corre todos los cuadros
    // una vez que los updates están terminados
    void LateUpdate()
    {
        //print("LATE UPDATE");
    }

    // CÓDIGO MUY ÚTIL
    // HOLA ESTOY EN EL REPO!
}
