using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSayStop : MonoBehaviour
{
    public GameObject dialog;
    public PhysicsMaterial2D MaterialForStop;
    private PhysicsMaterial2D OrignMaterial;
    private CapsuleCollider2D cp2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        cp2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        OrignMaterial = cp2d.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialog.activeInHierarchy == true)
        {
            cp2d.sharedMaterial = MaterialForStop;
            if (anim.GetBool("djump"))
            {

                anim.SetBool("djump", false);
                anim.SetBool("dfall", true);
            }
            else
            {
            anim.SetBool("run", false);
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
            anim.SetBool("dfall", false);
            anim.SetBool("idle", true);

            }
            GameController.isGameSaying = true;
        }
        else
        {
            cp2d.sharedMaterial = OrignMaterial;
            GameController.isGameSaying = false;
        }
    }
}
