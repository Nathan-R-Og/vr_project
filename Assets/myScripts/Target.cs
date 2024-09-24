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


    public float myScore = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    void OnTargetDoHit(Ammo hitby)
    {
        switch (myEffect)
        {
            case Effect.NONE:
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
    void DoTakeDown()
    {
        Destroy(gameObject);
    }

    //overrideable func for custom integration
    public virtual void CustomDoHit(Ammo hitby)
    {



    }
}
