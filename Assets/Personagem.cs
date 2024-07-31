using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movimento;
    public Animator animator;
    

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
   public void SetMovimento(InputAction.CallbackContext value){
    //atribui à variável movimento o valor 1 ou -1 para x ou para y, dependendo da tecla pressionada
    movimento = value.ReadValue<Vector2>();
    if(movimento.x == -1){
        transform.eulerAngles = new Vector3(0,180,0);
    }
    else if(movimento.x == 1){
        transform.eulerAngles = new Vector3(0,0,0);
    }
   }

   public void SetPular(InputAction.CallbackContext value){
    rb.AddForce(Vector2.up * 300);
    animator.SetBool("isJumping", true);
   }

   public void onLanding(){
    animator.SetBool("isJumping", false);
   }

   public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

   private void Update(){
    rb.AddForce(new Vector2(movimento.x,movimento.y) * Time.deltaTime * 1000);
    animator.SetFloat("Speed", Mathf.Abs(movimento.x));
   }
}
