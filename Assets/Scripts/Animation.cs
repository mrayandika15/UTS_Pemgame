using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private float kecepatan_player;
    private bool lompat;

    //Referensi
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan_player = player.GetComponent<Player_Movement>().z;
        lompat = player.GetComponent<Player_Movement>().isGrounded;
        anim.SetFloat("z", kecepatan_player);
        anim.SetBool("isGrounded", lompat);
    }
}
