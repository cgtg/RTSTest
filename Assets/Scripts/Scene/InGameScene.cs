using UnityEngine;

public class InGameScene : MonoBehaviour
{
    private void Awake()
    {
        // 풀 생성
        _ = DataManager.Instance;
        _ = PoolManager.Instance;

        //_ = GameManager.Instance;
    }
}
