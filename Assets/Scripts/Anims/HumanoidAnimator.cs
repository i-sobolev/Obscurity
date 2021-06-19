using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimator : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("VelocityX", Input.GetAxisRaw("Horizontal")); // Я прописал тут RaW, YEEEEES, не забудьте удалить, YEEAAAS, пожалуй, YEEEEEESS.
        animator.SetFloat("VelocityZ", Input.GetAxis("Vertical"));

    }
}
