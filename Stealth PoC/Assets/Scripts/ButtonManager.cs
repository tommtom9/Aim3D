using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private Animator _introAnim;

    private GameObject _camera;
    private GameObject _playButton;
    private GameObject _quitButton;
    private GameObject _itemstext;
    private GameObject _pickupText;
    private GameObject _staminaBar;

    void Start()
    {
        _camera = GameObject.Find("Main Camera");
        _playButton = GameObject.Find("PlayButton");
        _quitButton = GameObject.Find("QuitButton");
        _itemstext = GameObject.Find("ItemsText");
        _pickupText = GameObject.Find("PickupText");
        _staminaBar = GameObject.Find("StaminaBar");

        _camera.SetActive(true);
        EnableButtons();
        DisableHUD();
    }

    public void PlayGame()
    {
        _introAnim.Play("CameraIntro");
        StartCoroutine(SpawnPlayer());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator SpawnPlayer()
    {
        DisableButtons();
        yield return new WaitForSeconds(2);
        _camera.SetActive(false);
        GameObject playerObj = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity) as GameObject;
        EnableHUD();
    }

    void DisableButtons()
    {
        _playButton.SetActive(false);
        _quitButton.SetActive(false);
    }

    void EnableButtons()
    {
        _playButton.SetActive(true);
        _quitButton.SetActive(true);
    }

    void DisableHUD()
    {
        _itemstext.SetActive(false);
        _pickupText.GetComponent<RawImage>().enabled = false;
        _staminaBar.SetActive(false);
    }
    void EnableHUD()
    {
        _itemstext.SetActive(true);
        _staminaBar.SetActive(true);
    }


}
