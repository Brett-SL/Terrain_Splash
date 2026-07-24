using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fishing : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController fishingController;
    [SerializeField] Avatar fishingAvatar;

    private Animator _animator;
    private PlayerInput _playerInput;
    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _starterAssetsInputs;
    
    [SerializeField] private bool isFishing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        OnFishing();
    }

    private void OnFishing()
    {
        if (isFishing)
        { 
            _thirdPersonController.enabled = false;
            _starterAssetsInputs.enabled = false;

            //_playerInput.SwitchCurrentActionMap("None");
            _animator.runtimeAnimatorController = fishingController;
            _animator.avatar = fishingAvatar;
        }
    }
}
