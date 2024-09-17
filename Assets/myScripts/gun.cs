using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Linq;

public class gun : MonoBehaviour
{
    public ammo myProjectile;
    public GameObject shootPosition;
    public float force = 5;
    public ammo[] shot;
    public bool destroyAmmo = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < shot.Length; i++)
        {
            ammo clone = shot[i];




        }
    }

    public void Shut()
    {
        
        ammo clone = Instantiate(myProjectile, shootPosition.transform.position, transform.rotation);
        clone.willDestroy = destroyAmmo;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.linearVelocity = shootPosition.transform.forward * force;
        shot.Append(clone);
        //Debug.Log(rb.linearVelocity);

    }

    public void SetForce(float newForce)
    { force = newForce; }
    public void SetDestroy(bool newDess)
    { destroyAmmo = newDess; }

    public void Respawn()
    {
        transform.position = new Vector3(-1.469f, 0.9508f, -0.161f);
        Rigidbody myRb = GetComponent<Rigidbody>();
        myRb.linearVelocity = new Vector3(0,0,0);
    }
}
