using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartFishing : MonoBehaviour
{
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;

    private bool _canFish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    private void Update()
    {
        InteractFishing(_canFish);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishingInteract"))
        {
            _canFish = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishingInteract"))
        {
            _canFish = false;
        }
    }

    private void InteractFishing(bool canFish)
    {
        if (!_input.interact)
        {
            return;
        }
        
        if (canFish)
        {
            Debug.Log("Caught Fish!");
        }

        _input.interact = false;
    }
}
