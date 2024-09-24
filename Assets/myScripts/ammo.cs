using UnityEngine;

public class Ammo : MonoBehaviour
{

    public bool willDestroy = true;
    public Gun Owner;
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
        if (willDestroy) 
        {
            Gun otherGun = collision.gameObject.GetComponentInParent<Gun>(); 
            if (otherGun == Owner )
            {
                return; 
            }    


            Destroy(gameObject);
        }
    }

    public void HitTarget(Target whatIHit)
    {

        Debug.Log(whatIHit.name);

    }
}
