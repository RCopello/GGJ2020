using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe que controla a movimentação do player
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public bool canMove = true;

    public float baseCameraSpeed = 1.0f;
    [Tooltip("A distância até qual a camera tolera estar distante do player")]
    public float cameraDistanceTolerance = 1.0f;
    private Transform camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && (Input.GetAxis("Horizontal") > 0.5))
        {
            Vector3 movement = (Vector3.right * movementSpeed * Time.deltaTime);
            transform.position = transform.position + movement;
            if(this.transform.position.x - camera.position.x > cameraDistanceTolerance)
            {
                camera.position = camera.position + movement;
            }
        }
        if(canMove && (Input.GetAxis("Horizontal") < -0.5))
        {
            Vector3 movement = (Vector3.left * movementSpeed * Time.deltaTime);
            transform.position = transform.position + movement;
            if(camera.position.x - this.transform.position.x > cameraDistanceTolerance)
            {
                camera.position = camera.position + movement;
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    //função auxiliar para ajustar a câmera conforme a movimentação do player
    private void AdjustCamera()
    {
        float offsetToPlayer = this.transform.position.x - camera.position.x;
        if(Mathf.Abs(offsetToPlayer) > cameraDistanceTolerance) //threshold hardcoded arbitrário
        {
            float posX = camera.position.x + Mathf.Sign(offsetToPlayer)*baseCameraSpeed;
            camera.position = new Vector3(posX, camera.position.y, camera.position.z);
        }
    }
}
