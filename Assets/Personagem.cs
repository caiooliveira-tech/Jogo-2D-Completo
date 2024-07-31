using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movimento;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
   public void SetMovimento(InputAction.CallbackContext value){
    //atribui à variável movimento o valor 1 ou -1 para x ou para y, dependendo da tecla pressionada
    movimento = value.ReadValue<Vector2>();
   }

   public void SetPular(InputAction.CallbackContext value){
    rb.AddForce(Vector2.up * 300);
   }

   private void Update(){
    rb.AddForce(new Vector2(movimento.x,movimento.y) * Time.deltaTime * 1000);
   }
}
