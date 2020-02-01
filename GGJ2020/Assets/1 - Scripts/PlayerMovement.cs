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
        if(canMove && (Input.GetAxis("Horizontal") > 0))
        {
            transform.position = transform.position + (Vector3.right * movementSpeed * Time.deltaTime);
            AdjustCamera();
        }
        if(canMove && (Input.GetAxis("Horizontal") < 0))
        {
            transform.position = transform.position + (Vector3.left * movementSpeed * Time.deltaTime);
            AdjustCamera();
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
