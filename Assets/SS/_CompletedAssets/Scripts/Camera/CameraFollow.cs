using UnityEngine;
using System.Collections;
// camera theo doi va di chuyen theo doi tuong
namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // vi tri ma camera do theo doi
        public float smoothing = 5f;        // toc do camera


        Vector3 offset;                    


        void Start ()
        {
            
            offset = transform.position - target.position;
        }


        void FixedUpdate ()
        {
            // vi tri may anh huong toi so vs muc tieu
            Vector3 targetCamPos = target.position + offset;

            //lam muot
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}