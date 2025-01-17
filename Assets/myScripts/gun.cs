using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections.Generic;
using static UnityEngine.Rendering.GPUSort;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public Ammo myProjectile;
    public GameObject shootPosition;
    public float force = 5;
    public List<Ammo> shot = new List<Ammo>();
    public bool destroyAmmo = true;



    public Player Owner;

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
    public void GiveGun(SelectEnterEventArgs args)
    {
        XRGrabInteractable core = GetComponent<XRGrabInteractable>();
        if (core != null)
        {
            CharacterController my_SelectingCharacterController = args.interactorObject.transform.GetComponentInParent<CharacterController>();
            if (my_SelectingCharacterController != null) { 
                Player realCore = my_SelectingCharacterController.GetComponent<Player>();
                if (realCore != null)
                {
                    realCore.guns.Add(this);
                    Owner = realCore;
                }
            }
        }
    }

    //and god taketh away
    public void LoseGun(SelectExitEventArgs args)
    {
        XRGrabInteractable core = GetComponent<XRGrabInteractable>();
        if (core != null)
        {
            CharacterController my_SelectingCharacterController = args.interactorObject.transform.GetComponentInParent<CharacterController>();
            if (my_SelectingCharacterController != null)
            {
                Player realCore = my_SelectingCharacterController.GetComponent<Player>();
                if (realCore != null && realCore == Owner)
                {
                    realCore.guns.Remove(this);
                    Owner = null;
                }
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
