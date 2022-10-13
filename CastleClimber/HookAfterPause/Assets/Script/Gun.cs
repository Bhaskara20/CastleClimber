using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Scripts Reference:")]
    public Rope GrappleRope;
    [Header("Layers Settings:")]
    [SerializeField] private bool Grapple2ALL = false;
    [SerializeField] private int GrappleLayerNum = 9;
    [Header("Main Camera:")]
    public Camera mainCamera;
    [Header("Transform Ref:")]
    public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;
    [Header("Physics Ref:")]
    public SpringJoint2D springJoint;
    public Rigidbody2D rb;
    [Header("Rotation:")]
    [SerializeField] private bool RotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float RotationSpeed = 4;
    [Header("Distance:")]
    [SerializeField] private bool HasMaxDistance = false;
    [SerializeField] private float MaxDistance = 20;


    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    [Header("Launching:")]
    [SerializeField] private bool Launch2Point = true;
    [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
    [SerializeField] private float LaunchSpeed = 1;
    [Header("No Launch To Point")]
   

    
    [HideInInspector] public Vector2 grapplePoint;

    [HideInInspector] public Vector2 grappleDistanceVector;

    void Start()
    {
        GrappleRope.enabled = false;
        springJoint.enabled = false;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetGrapplePoint();

        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            if (GrappleRope.enabled)
            { 
                RotateGun(grapplePoint, false);
            }
            else
            {
                Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RotateGun(mousePos, true); 
            }

            if (Launch2Point && GrappleRope.isGrappling)
            {
                if (launchType == LaunchType.Transform_Launch)
                {
                    Vector2 firePointDistnace = firePoint.position - gunHolder.localPosition;
                    Vector2 targetPos = grapplePoint - firePointDistnace;
                    gunHolder.position = Vector2.Lerp(gunHolder.position, targetPos, Time.deltaTime * LaunchSpeed);
                }  
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GrappleRope.enabled = false;
            springJoint.enabled = false;

            if(launchType == LaunchType.Transform_Launch)
                rb.gravityScale = 1;
        }
        else
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RotateGun(mousePos, true);
        }
    }

    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {

        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (RotateOverTime && allowRotationOverTime)
        {
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * RotationSpeed);
        }
        else
        {
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void SetGrapplePoint()
    {
        Vector2 distanceVector = mainCamera.ScreenToWorldPoint(Input.mousePosition) - gunPivot.position;
        if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
            if (_hit.transform.gameObject.layer == GrappleLayerNum || Grapple2ALL)
            {
                if (Vector2.Distance(_hit.point, firePoint.position) <= MaxDistance || !HasMaxDistance)
                {
                    grapplePoint = _hit.point;
                    grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
                    GrappleRope.enabled = true;
                }
            }
        }
    }

    public void Grapple()
    {
        

        if (!Launch2Point)
        {

            springJoint.connectedAnchor = grapplePoint;
            springJoint.enabled = true;
        }
        else
        {
            switch (launchType)
            {
                case LaunchType.Physics_Launch:
                    springJoint.connectedAnchor = grapplePoint;

                    Vector2 firePointDistanceVector = firePoint.position - gunHolder.position;

                    springJoint.distance = firePointDistanceVector.magnitude;
                    springJoint.frequency = LaunchSpeed;
                    springJoint.enabled = true;
                    break;
                case LaunchType.Transform_Launch:
                    rb.gravityScale = 0;
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (firePoint != null && HasMaxDistance)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(firePoint.position, MaxDistance);
        }
    }

}
