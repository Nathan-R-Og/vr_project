using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField]
    private InputActionReference move, look, jump, fire;
    public Gun[] guns;
    public float score = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < guns.Length; i++) guns[i].Owner = this;
    }


}
