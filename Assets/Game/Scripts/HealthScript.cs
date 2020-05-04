using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    private bool _isAlive;

    [SerializeField]
    private GameObject deathAnimation;

    private int _life;
    public int Life
    {
        get => _life;
        private set
        {
            _life = value;
            _isAlive = _life > 0;

            if (this.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.UpdateLifeInterface();
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject.CompareTag("Alien"))
        {
            switch (GameManager.Instance.difficulty)
            {
                case Difficulty.Easy:
                    Life = 1;
                    break;
                case Difficulty.Normal:
                    Life = 2;
                    break;
                case Difficulty.Hard:
                    Life = 3;
                    break;
                default:
                    Life = 2;
                    break;
            }
        }
        else if (gameObject.CompareTag("Player"))
        {
            Life = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Updates the life of the current gameobject according to the damage taken, and get the new state of the gameobject (still alive or not)
    /// </summary>
    /// <param name="damageTaken">Damage taken to deduct from life</param>
    public void UpdateLifeAndGetNewState(int damageTaken)
    {
        Life -= damageTaken;

        if (this.gameObject.CompareTag("Player") && damageTaken > 0)
        {
            Debug.Log("-1 pv");

            if (!GameManager.Instance.mute)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
        }

        //Debug.Log($"{nameof(UpdateLifeAndGetNewState)} [{gameObject.name}] : {Life} - {_isAlive}");
        if (!_isAlive)
        {
            if (this.gameObject.CompareTag("Alien"))
            {
                ScoreManager.Instance.Score += this.gameObject.GetComponent<AlienScript>().score;
                Instantiate(deathAnimation, transform.position, transform.rotation);
                Destroy(this.transform.parent.gameObject);
            }
            else if (this.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.PlayerDeath();
            }
        }
    }
}
