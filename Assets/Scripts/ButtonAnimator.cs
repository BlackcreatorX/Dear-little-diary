using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    // Referencia al Animator del mismo objeto
    Animator anim;

    // Activa o desactiva el modo debug desde el Inspector
    public bool debugExit = false;

    // Tecla que se usará para probar la animación de salida
    public KeyCode debugKey = KeyCode.Space;

    void Awake()
    {
        // Obtiene el componente Animator que está en este GameObject
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Si el modo debug está activado y se presiona la tecla configurada
        if (debugExit && Input.GetKeyDown(debugKey))
        {
            // Ejecuta la animación de salida
            Exit();
        }
    }

    // Método público que dispara el Trigger "Exit" del Animator
    // Este mismo método también puede llamarse desde botones UI
    public void Exit()
    {
        anim.SetTrigger("TriggerExit");
    }
}