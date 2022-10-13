using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    
    [Header("General References:")]
    public Gun GrapplingGun;
    public LineRenderer lineRenderer;
    [Header("General Settings:")]
    [SerializeField] private int persisi = 40;
    [Range(0, 20)] [SerializeField] private float StraightenLineSpeed = 5;
    [Header("Rope Animation Settings:")]
    public AnimationCurve RopeAnimationCurve;
    [Range(0.01f, 4)] [SerializeField] private float StartWaveSize = 2;
    private float waveSize = 0;
    
    [Header("Rope Progression:")]
    public AnimationCurve ropeProgressionCurve;
    [SerializeField] [Range(1, 50)] private float ropeProgressionSpeed = 1;
    private float MoveTime = 0;
    [HideInInspector] public bool isGrappling = true;
    private bool strightLine = true;

    void Start()
    {
        
    }

    void Update()
    {
        MoveTime += Time.deltaTime;
        DrawRope();
    }

    void OnDisable()
    {
        lineRenderer.enabled = false;
        isGrappling = false;
    }

    void OnEnable()
    {
        MoveTime = 0;
        lineRenderer.positionCount = persisi;
        waveSize = StartWaveSize;
        strightLine = false;
        LinePointsToFirePoint();
        lineRenderer.enabled = true;
    }

    void LinePointsToFirePoint()
    {
        for (int i = 0; i < persisi; i++)
        {
            lineRenderer.SetPosition(i, GrapplingGun.firePoint.position);
        }
    }

    void DrawRope()
    {
        if (!strightLine)
        {
            if (lineRenderer.GetPosition(persisi - 1).x == GrapplingGun.grapplePoint.x)
            {
                strightLine = true;
            }
            else
            {
                DrawRopeWaves();
            }
        }
        else
        {
            if (!isGrappling)
            {
                GrapplingGun.Grapple();
                isGrappling = true;
            }
            if (waveSize > 0)
            {
                waveSize -= Time.deltaTime * StraightenLineSpeed;
                DrawRopeWaves();
            }
            else
            {
                waveSize = 0;

                if (lineRenderer.positionCount != 2) { lineRenderer.positionCount = 2; }

                DrawRopeNoWaves();
            }
        }
    }

    void DrawRopeWaves()
    {
        for (int i = 0; i < persisi; i++)
        {
            float delta = (float)i / ((float)persisi - 1f);
            Vector2 offset = Vector2.Perpendicular(GrapplingGun.grappleDistanceVector).normalized * RopeAnimationCurve.Evaluate(delta) * waveSize;
            Vector2 targetPosition = Vector2.Lerp(GrapplingGun.firePoint.position, GrapplingGun.grapplePoint, delta) + offset;
            Vector2 currentPosition = Vector2.Lerp(GrapplingGun.firePoint.position, targetPosition, ropeProgressionCurve.Evaluate(MoveTime) * ropeProgressionSpeed);
            lineRenderer.SetPosition(i, currentPosition);
        }
    }

    void DrawRopeNoWaves()
    {
        lineRenderer.SetPosition(0, GrapplingGun.firePoint.position);
        lineRenderer.SetPosition(1, GrapplingGun.grapplePoint);
    }
}
