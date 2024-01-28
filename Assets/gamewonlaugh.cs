using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamewonlaugh : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsLaughing", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
