using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public EstadoJogo estadoatual; 
    public enum EstadoJogo
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }
    
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }
    }
    
    #endregion
    
    #region Estados

    private void Start()
    {
        // Estado inicial
        AlterarEstado(EstadoJogo.Iniciando);

        // Carrega Splash
        CarregarCena("Splash");
    }

    public void AlterarEstado(EstadoJogo novoEstado)
    {
        estadoatual = novoEstado;
        Debug.Log("Estado atual: " + estadoatual);
    }

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void irParaMenuPrincipal()
    {
        AlterarEstado(EstadoJogo.MenuPrincipal);
        CarregarCena("MenuPrincipal");
    }
    
    public void Iniciarjogo()
    {
        AlterarEstado(EstadoJogo.Iniciando);
        CarregarCena("GetStarted_Scene");
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
    #endregion
    
    #region InputPlayer
    // Aloca input ao player
    void AlocarInputPlayer()
    {
        PlayerInput player = FindObjectOfType<PlayerInput>();

        if (player != null)
        {
            player.ActivateInput();
            Debug.Log("Input conectado ao jogador.");
        }
        else
        {
            Debug.Log("PlayerInput não encontrado.");
        }
    }
    #endregion
    
}
