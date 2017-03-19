using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    
    LineRenderer gunLine;

    float effectsDisplayTime = 0.1f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunLine = GetComponent <LineRenderer> ();

    }


    void Update ()
    {
        timer += Time.deltaTime;

		
            Shoot ();
       


    }




    void Shoot ()
    {
        timer = 0f;
        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        Debug.Log(transform.forward);
        gunLine.startWidth = 0.02f;
        if (Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
