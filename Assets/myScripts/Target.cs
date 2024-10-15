using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Audio;

public class Target : MonoBehaviour
{


    public enum Effect
    {
        NONE = 0,
        SCORE,
        CUSTOM,



    }

    public Effect myEffect = Effect.SCORE;
    public GameObject movementParent = null;
    public RuntimeAnimatorController animSet = null;
    public float speedScale = 1.0f;

    public float myScore = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayAnimation("Move");
    }

    public void PlayAnimation(string AnimName)
    {
        movementParent = new GameObject("TARGET_PARENT_" + gameObject.name);
        transform.SetParent(movementParent.transform, true);
        Animator mator = movementParent.AddComponent<Animator>();
        mator.runtimeAnimatorController = animSet;
        mator.applyRootMotion = true;
        //this was used but doesnt allow for reversal
        //mator.speed = speedScale;
        mator.SetFloat("internalWay", speedScale);
        if (speedScale < 0.0f)
        {
            //if backwards, start at end
            mator.Play(AnimName, 0, 1.0f);
        }
        else { 
            mator.Play(AnimName, 0);
        }
        animFinish allFinish = mator.GetBehaviour<animFinish>();
        if (allFinish != null)
        {
            allFinish.target = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        Ammo ss = collision.gameObject.GetComponent<Ammo>();
        if(ss != null)
        {
            ss.HitTarget(this);
            OnTargetDoHit(ss);
        }
    }

    public virtual void OnTargetDoHit(Ammo hitby)
    {
        switch (myEffect)
        {
            case Effect.NONE:
                DoTakeDown();
                break;
            case Effect.SCORE:
                hitby.Owner.Owner.score += myScore;
                DoTakeDown();
                break;
            case Effect.CUSTOM:
                CustomDoHit(hitby);
                break;

        }
    }

    //basic fall
    public virtual void DoTakeDown()
    {
        Destroy(gameObject);
    }

    //ran when leaving without getting hit
    public virtual void LeaveScene()
    {
        //Debug.Log("OOGA"+gameObject.name);
        Destroy(gameObject);
    }

    //overrideable func for custom integration
    public virtual void CustomDoHit(Ammo hitby)
    {



    }
}
