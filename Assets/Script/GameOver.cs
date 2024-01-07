using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text timer;

    private void Start()
    {
        timer.text = Timer.Instance.GetTime().text;
    }
}
