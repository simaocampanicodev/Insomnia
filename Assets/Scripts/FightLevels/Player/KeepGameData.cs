using UnityEngine;

public class KeepGameData : MonoBehaviour
{
    public int life { get; set; }
    public float stress { get; set; }
    public void KeepFightDataAfterLoad()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        PlayerScript player = playerObj.GetComponent<PlayerScript>();
        life = player.life;
        DontDestroyOnLoad(gameObject);
    }
    public void KeepCoffeeDataAfterLoad()
    {
        StressBarManager stressObj = GameObject.FindFirstObjectByType<StressBarManager>();
        StressBarManager stressScript = stressObj.GetComponent<StressBarManager>();
        stress = stressScript.actualStress;
        DontDestroyOnLoad(gameObject);
    }
}