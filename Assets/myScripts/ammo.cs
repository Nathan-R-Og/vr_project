using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public bool willDestroy = true;
    public Gun Owner;
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.AddForce(gravity*rb.mass);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Ammo ammo = collision.gameObject.GetComponent<Ammo>();
        Gun gun = collision.gameObject.GetComponent<Gun>();
        if ((ammo != null) || (gun != null))
        {
            return; 
        }

        if (willDestroy)
        {
            DoDelete();
        }
    }

    public virtual void HitTarget(Target whatIHit)
    {

        Debug.Log(whatIHit.name);

    }

    public virtual void DoDelete()
    {
        Destroy(gameObject);
    }
}
