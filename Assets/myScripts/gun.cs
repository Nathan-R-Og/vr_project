using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.SocialPlatforms.Impl;

public class Gun : MonoBehaviour
{
    public Ammo myProjectile;
    public GameObject shootPosition;
    public float force = 5;
    public Ammo[] shot;
    public bool destroyAmmo = true;



    public Player Owner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < shot.Length; i++)
        {
            Ammo clone = shot[i];




        }
    }

    public void Shoot()
    {
        Ammo clone = Instantiate(myProjectile, shootPosition.transform.position, shootPosition.transform.rotation);

        clone.willDestroy = destroyAmmo;

        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.linearVelocity = shootPosition.transform.forward * force;

        shot.Append(clone);

        clone.Owner = this;
        

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
