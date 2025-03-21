using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    private float _maxSleep = 150;
    private float _sleep = 0;

    void Start()
    {
        UpdateSleepBar();

        StartCoroutine(Regen());
    }

    private void UpdateSleepBar()
    {
        RectTransform rect = canvas.transform.Find("SleepBar").Find("Filled").GetComponent<RectTransform>();
        float size = 631 * (_sleep / _maxSleep);
        rect.sizeDelta = new Vector2(size, rect.sizeDelta.y);
    }

    private IEnumerator Regen()
    {
        float time = 0.1f;
        while (true)
        {
            ChangeSleep(1);
            yield return new WaitForSeconds(time);
        }
    }

    private void ChangeSleep(float value)
    {
        _sleep += value;
        if (_sleep > _maxSleep) _sleep = _maxSleep;
        if (_sleep < 0) _sleep = 0;
        if (_sleep >= _maxSleep) Overslepted();
        UpdateSleepBar();
    }

    public void RemoveSleep(float value)
    {
        ChangeSleep(-value);
    }

    private void Overslepted()
    {
        SceneManager.LoadScene("FightClub");
    }
}