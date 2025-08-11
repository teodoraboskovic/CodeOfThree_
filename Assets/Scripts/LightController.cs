using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public bool isOn = false; 
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateLampVisual();
        animator.Update(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            if (isOn)
            {
                isOn = false;
                UpdateLampVisual();
                //GameManager.instance.RuleBroken("Lamp turned off");
            }
            else
            {
                isOn = true;
                UpdateLampVisual();
            }
        }
    }

    void UpdateLampVisual()
    {
        animator.SetBool("isOn", isOn);
    }

}
