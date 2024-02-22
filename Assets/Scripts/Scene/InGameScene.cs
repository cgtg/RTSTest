using UnityEngine;

public class InGameScene : MonoBehaviour
{

    private void Awake()
    {
        // 풀 생성
        _ = DataManager.Instance;

        //_ = GameManager.Instance;
        _ = PoolManager.Instance;
    }

    private void Start()
    {
        //PoolManager.Instance.GetPoolAble("Cop");
    }
}
