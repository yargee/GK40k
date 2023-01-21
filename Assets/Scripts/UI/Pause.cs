using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pauseOnBtn;
    [SerializeField] private GameObject _fade;
    [SerializeField] private Button _pauseOffBtn;

    private void OnEnable()
    {
        _pauseOnBtn.onClick.AddListener(SetPauseOn);
        _pauseOffBtn.onClick.AddListener(SetPauseOff);
    }

    private void OnDisable()
    {
        _pauseOnBtn.onClick.RemoveListener(SetPauseOn);
        _pauseOffBtn.onClick.RemoveListener(SetPauseOff);
    }
    
    private void Update()
    {
        SpaceToggledPause();
    }

    private void SetPauseOn()
    {
        Time.timeScale = 0;
        _fade.SetActive(true);
        _pauseOnBtn.gameObject.SetActive(false);
    }

    private void SetPauseOff()
    {
        Time.timeScale = 1;
        _fade.SetActive(false);
        _pauseOnBtn.gameObject.SetActive(true);
    }

    private void SpaceToggledPause()
    {


        if (Time.timeScale == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PAUSE ON");

            SetPauseOn();
            return;
        }
        
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            SetPauseOff();
            return;
        }
    }
}
