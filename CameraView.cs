using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;



//as of 7/16
//need to possibly work on this more, if want a better feel. right now camera is not working but part of prefab
//
public class CameraView : MonoBehaviour
{
    public Transform playerObject;
    public Vector3 offset;
    public float camSpeed=25f;
    private float yaw;
    private float pitch;
    public Transform camObject;

    private void Update()
    {
         float mouseX = Input.GetAxis("Mouse X") * camSpeed * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * camSpeed * Time.deltaTime;

        yaw += mouseX;
        pitch += mouseY;
        pitch = Mathf.Clamp(10f, 0f, 100f);     //makes the camera stop at these points
        
        if(playerObject !=null)
        {
            camObject.transform.rotation = Quaternion.Euler(0f, -85f, 0f);
            transform.position = playerObject.position;             //save for the camera rotation on
            //currently at the back of player, but player wont rotate with camera,
            //only when part of the player prefab                                                      //on player object
            //camObject.transform.rotation = Quaternion.Euler(13f, -95f, 0f);     //;Euler(120f,6f, 0f);
            transform.Translate(Vector3.left*10f, playerObject);
            transform.rotation= camObject.transform.rotation;
            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
            
            
            
        }
        //playerObject.
     
        transform.position = playerObject.position + offset;
        transform.rotation = camObject.transform.rotation;
        
        //

        
    }



    //public Transform playerCam;
    //public float speed = 50f;       //speed of camera 
    //private float yaw = 0f;
    //private float pitch = 0f;

    //private void Update()
    //{
    //   

    //    yaw += mouseX;
    //    pitch -= mouseY;
    //    pitch = Mathf.Clamp(pitch, -200f, 200f);

    //    if (playerCam != null)
    //    {
    //        transform.position = new Vector3(124,4,114);
    //        transform.rotation = Quaternion.Euler(12,-95,-4);
    //        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    //        transform.Translate(Vector3.right * 10f);
    //    }
    //    else
    //    {
    //        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    //    }
    //}
}
