using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public Ammo myProjectile;
    public GameObject shootPosition;
    public float force = 5;
    public List<Ammo> shot = new List<Ammo>();
    public bool destroyAmmo = true;



    public Player Owner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < shot.Count; i++)
        {
            Ammo clone = shot[i];
        }
    }

    public virtual void Shoot()
    {
        Ammo clone = Instantiate(myProjectile, shootPosition.transform.position, shootPosition.transform.rotation);
        clone.willDestroy = destroyAmmo;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.linearVelocity = shootPosition.transform.forward * force;
        shot.Add(clone);
        clone.Owner = this;
    }

    //god giveth
    public void GiveGun()
    {
        XRGrabInteractable core = GetComponent<XRGrabInteractable>();
        if (core != null)
        {
            Player realCore = core.m_SelectingCharacterController.GetComponent<Player>();
            if (realCore != null)
            {
                realCore.guns.Add(this);
                Owner = realCore;
            }
        }
    }

    //and god taketh away
    public void LoseGun()
    {
        XRGrabInteractable core = GetComponent<XRGrabInteractable>();
        if (core != null)
        {
            Player realCore = core.m_SelectingCharacterController.GetComponent<Player>();
            if (realCore != null && realCore == Owner)
            {
                realCore.guns.Remove(this);
                Owner = null;
            }
        }
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
