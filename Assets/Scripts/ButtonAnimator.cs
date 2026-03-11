using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject BookMenu;
    public GameObject BookOpen;
     public GameObject CameraController;
    [SerializeField] MenuButtons menuButtons;
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
     menuButtons.OnExitAnimatorButtons();

        
    }
 public void OnExitAnimationFinished()
{
    Debug.Log("Animación de salida finalizada.");
    CameraController.GetComponent<CameraAnimations>().CamSwap();
    openBook();

}
public void openBook()
    {
        if (BookMenu != false)
        {
            BookMenu.SetActive(false);
            BookOpen.SetActive(true);


        }
        
    }

 public void PlayButton()
    {
       Debug.Log("Play button pressed");
        Exit();
        //! TODO: GameStart():
    }

    public void CreditsButton()
    {
        Debug.Log("Credits button pressed");
        Exit();
        //!TODO: ShowCredits():
        creditsMenu.SetActive(true);
    
    }
    public void ExitButton()
    {
        Debug.Log("Exit button pressed");
          Application.Quit();
    }


}