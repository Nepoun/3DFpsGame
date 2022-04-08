using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform referenceTransform;

    //To prevent Camera from clipping through Objects
    public float collisionOffset = 0.3f;

    //How fast the Camera should snap into position if there are no obstacles
    public float cameraSpeed = 15f;

    Vector3 defaultPos;

    public Vector3 zoomOutPosition, zoomInPosition;
    Vector3 directionNormalized;
    Transform parentTransform;
    float defaultDistance;
    bool isAiming = false;
    void Start()
    {
        defaultPos = transform.localPosition;
        directionNormalized = defaultPos.normalized;
        parentTransform = transform.parent;
        defaultDistance = Vector3.Distance(defaultPos, Vector3.zero);

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
            Vector3 currentPos = defaultPos;
            RaycastHit hit;
            Vector3 dirTmp = parentTransform.TransformPoint(defaultPos) - referenceTransform.position;
            if (Physics.SphereCast(referenceTransform.position, collisionOffset, dirTmp, out hit, defaultDistance))
            {
                currentPos = (directionNormalized * (hit.distance - collisionOffset));

                transform.localPosition = currentPos;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * cameraSpeed);
            }
    }

    public void ZoomIn(){
        
    }
    public void ZoomOut(){

    }


}