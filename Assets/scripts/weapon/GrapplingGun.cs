using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, mainCamera;
    public GameObject player;
    public float maxDistance;
    SpringJoint joint;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }
    }
    void LateUpdate()
    {
        DrawRope();
    }
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin: mainCamera.position,
                                    direction: mainCamera.forward,
                                    out hit,
                                    maxDistance,
                                    whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(a: player.transform.position, b: grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        //If not grappling, dont draw rope
        if (!joint) return;

        lr.SetPosition(index: 0, gunTip.position);
        lr.SetPosition(index: 1, grapplePoint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint(){
        return grapplePoint;
    }

}
