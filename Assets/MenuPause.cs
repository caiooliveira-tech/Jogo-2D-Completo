using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class MenuPause : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;

    private void Awake() {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q<Button>("btnPause");
        _button.RegisterCallback<ClickEvent>(OnContinueClick);
    }

    public void OnPause(InputAction.CallbackContext value){
        _button.style.display = DisplayStyle.Flex;
        Time.timeScale = 0;
    }

    private void OnDisable(){
        _button.UnregisterCallback<ClickEvent>(OnContinueClick);
    }

    private void OnContinueClick(ClickEvent evt){
        Time.timeScale = 1;
         _button.style.display = DisplayStyle.None;
    }


    
}
