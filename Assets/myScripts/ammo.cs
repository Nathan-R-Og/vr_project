using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public bool willDestroy = true;
    public bool hit = false;
    public Gun Owner;
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
    private void FixedUpdate()
    {
        //custom gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.AddForce(gravity*rb.mass);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //ignore guns and ammo
        Ammo ammo = collision.gameObject.GetComponent<Ammo>();
        Gun gun = collision.gameObject.GetComponent<Gun>();
        if ((ammo != null) || (gun != null))
        {
            return; 
        }

        //combo fail condition
        //this gets called before HitTarget, btw
        Target target = collision.gameObject.GetComponent<Target>();
        if (!hit && target == null) { 
            Owner.Owner.LoseCombo();
        }

        //die
        if (willDestroy)
        {
            DoDelete();
        }
    }

    public virtual void HitTarget(Target whatIHit)
    {
        //custom handling for whatever target you hit
        //could be called through OnCollisionEnter????? i dont think it matters though
        hit = true;
        Owner.Owner.AddCombo();
        Debug.Log(whatIHit.name);

    }

    public virtual void DoDelete()
    {
        //custom removal handling
        Destroy(gameObject);
    }
}
