using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartFishing : MonoBehaviour
{
    private FishingArea _fishingArea;
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
            _fishingArea = other.GetComponentInParent<FishingArea>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishingInteract"))
        {
            _canFish = false;
            
            // Ensuring exited area is previous assigned area from OnEnter
            FishingArea exitedArea = other.GetComponentInParent<FishingArea>();

            if (exitedArea == _fishingArea)
            {
                _fishingArea = null;
            }
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
            _fishingArea.CatchFish(transform.position);
        }

        _input.interact = false;
    }
}
