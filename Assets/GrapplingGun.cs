using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

    public DistanceJoint2D distanceJoint2D;
    Vector3 direction;
    LineRenderer lineRenderer;
    public float hookDistance = 5;
    public LayerMask layerMask;

    public Transform player_Transform;
    
    bool hook;
    bool attached;
    private Vector3 targetpos;
    private RaycastHit2D hit;
    
    private void Awake(){
        //distanceJoint2D = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint2D.enabled = false;
        hook = false;
        attached = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player_Transform.position;

        if (hook)
        {
            //Calculating the targetposition of the hook is dependend on the position of the player.
            targetpos = transform.position + direction * hookDistance;
            
            //Check if the hook is hitting something
            hit = Physics2D.Raycast(transform.position,direction,hookDistance,layerMask);
            //If the collider hits something //and the gameObject has a Rigidbody2D (since we use Tilemaps we dont need this anymore)
            if (hit.collider != null) //&& hit.collider.gameObject.GetComponent<TilemapCollider2D>() != null)
            {
                if (!attached)
                    {
                    distanceJoint2D.connectedAnchor = hit.point;
                    hookDistance = Vector2.Distance(transform.position,hit.point);
                    if (hookDistance < 1.5f)
                    {
                        hookDistance = 1.5f;
                    }
                    distanceJoint2D.distance = hookDistance;
                    attached = true;
                    }
            distanceJoint2D.enabled = true;
            lineRenderer.enabled = true; 
            }
        }
        else if(!hook)
        {
            distanceJoint2D.enabled = false;
            lineRenderer.enabled = false;
            attached = false;
        }
        if (distanceJoint2D.enabled)
        {
            lineRenderer.SetPosition(0,distanceJoint2D.connectedAnchor);
            lineRenderer.SetPosition(1,transform.position);
        }
    }

    public void Hook(Vector2 inputDirection, bool isHooking)
    {
        hook = isHooking;
        direction = inputDirection;        
        direction.z = 0;
    }
}
