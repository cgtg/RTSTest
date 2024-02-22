using UnityEngine;

public class IntroScene : MonoBehaviour
{

    private void Awake()
    {
        _ = GameManager.Instance;
        _ = DataManager.Instance;
    }

    private void Start()
    {
        UIManager.Instance.ShowUI<UIIntro>();
    }

}
