using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    //Quando entro na colisão, vai acontecer...
    public class NewMonoBehaviourScript : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        void Update()
        {
            float value = Input.GetAxis("Horizontal");
            if (value < 0) value *= -1;
            animator.SetFloat("speed", value);
        }
    }

    public AudioSource AudioPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        //Verificar se tem a tag Collectable
        {
            AudioPlayer.Play();
            if (other.gameObject.name.StartsWith("Coffee"))
            //Verifica se o item chama-se Coffee
            {
                if (_gameManager == null) _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                //Se o GameManager existir no objeto, vai remover 20 na barra de sleep e destruí-lo
                _gameManager.RemoveSleep(20);
                Destroy(other.gameObject);
                return;
            }
            if (other.gameObject.name.StartsWith("EnergyDrink"))
            //Verifica se o item chama-se EnergyDrink
            {
                if (_gameManager == null) _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                //Se o GameManager existir no objeto, vai remover 30 na barra de sleep e destruí-lo
                _gameManager.RemoveSleep(30);
                Destroy(other.gameObject);
                return;
            }
        }
    }

}