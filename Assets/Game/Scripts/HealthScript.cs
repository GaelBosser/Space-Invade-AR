using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private bool _isAlive;

    private int _life;
    public int Life
    {
        get => _life;
        private set
        {
            _life = value;
            _isAlive = _life > 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Life = 3; //TODO: Set the number of lives according to the difficulty selected in the settings.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Updates the life of the current gameobject according to the damage taken, and get the new state of the gameobject (still alive or not)
    /// </summary>
    /// <param name="damageTaken">Damage taken to deduct from life</param>
    /// <returns>Returns whether or not the current game-object is still alive.</returns>
    public bool UpdateLifeAndGetNewState(int damageTaken)
    {
        Life += damageTaken;

        Debug.Log($"{nameof(UpdateLifeAndGetNewState)} [{gameObject.name}] : {Life} - {_isAlive}");

        return _isAlive;
    }
}
