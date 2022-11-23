using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideHazard : MonoBehaviour
{
    public Animation anim;
    public IsReachedBottom on;
    public UnityEngine.UI.Image sprite;

    private void OnEnable()
    {
        sprite.color = new Vector4(1, 1, 1, 0);
    }

    private void Update()
    {
        
            if (on.on)
            {
                if (!anim.isPlaying)
                {
                    anim.Play("HazardOn");
                }
            }
        else
            {
                if (!anim.isPlaying)
                {
                    anim.Play("HazardOff");
                }
            }
        }
    
}
