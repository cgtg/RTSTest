using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

[System.Serializable]
public class ObjectInfo
{
    public string objectName;
    public GameObject prefab;
    public int defaultCapacity;
    public int maxSize;


}


public class PoolManager : SingletoneBase<PoolManager>
{
    private Dictionary<string, ObjectInfo> SODic = new Dictionary<string, ObjectInfo>();

    private float repeatInterval = 10.0f;
    private float spawnRadius = 10f;

    private Dictionary<string, IObjectPool<PoolAble>> ojbectPoolDic = new Dictionary<string, IObjectPool<PoolAble>>();


    protected override void Init()
    {
        Dictionary<int, UnitData> itemDataDictionary = DataManager.Instance.itemDataDictionary;

        foreach (int key in itemDataDictionary.Keys)
        {
            Debug.Log(key);



            //SODic.Add(key, )
        }
        
        
        
        
        //for (int idx = 0; idx < unit.Length; idx++)
        //{
        //    ObjectInfo tmpObjInfo = unit[idx];
        //    IObjectPool<PoolAble> pool = new ObjectPool<PoolAble>(() =>
        //    CreatePooledItem(tmpObjInfo), OnGetFromPool
        //        , OnReleaseToPool, OnDestroyPoolObject
        //        , true, unit[idx].defaultCapacity, unit[idx].maxSize);

        //    if (ojbectPoolDic.ContainsKey(unit[idx].objectName))
        //    {
        //        Debug.LogFormat("{0} 이미 등록된 오브젝트입니다.", unit[idx].objectName);
        //        return;
        //    }

        //    ojbectPoolDic.Add(unit[idx].objectName, pool);
        //}
    }

    // 생성
    private PoolAble CreatePooledItem(ObjectInfo objectInfos)
    {
        PoolAble poolAble = Instantiate(objectInfos.prefab).GetComponent<PoolAble>();
        poolAble.SetPool(ojbectPoolDic[objectInfos.objectName]);
        return poolAble;
    }

    // 대여
    private void OnGetFromPool(PoolAble poolObj)
    {
        poolObj.gameObject.SetActive(true);
    }

    // 반환
    private void OnReleaseToPool(PoolAble poolObj)
    {
        poolObj.gameObject.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(PoolAble poolObj)
    {
        Destroy(poolObj.gameObject);
    }

    public PoolAble GetPoolAble(string objectName)
    {
        if (ojbectPoolDic.ContainsKey(objectName) == false)
        {
            Debug.LogFormat("{0} 오브젝트풀에 등록되지 않은 오브젝트입니다.", objectName);
            return null;
        }

        return ojbectPoolDic[objectName].Get();
    }



    public void Respawn(Vector3 centerPos, string prefabNickName, int count)
    {
        //for (int i = 0; i < count; i++)
        //{
        //    GameObject animal = unit[Random.Range(0, unit.Length)].prefab;

        //    // 랜덤 위치에서 가장 가까운 Navmesh위 유효 위치를 탐색
        //    Vector3 randomPosition = Random.onUnitSphere * spawnRadius + centerPos;
        //    randomPosition.y = 100f;
        //    Ray ray = new Ray(randomPosition, Vector3.down);
        //    RaycastHit hit;
        //    NavMeshHit navhit;

        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        if (NavMesh.SamplePosition(hit.point, out navhit, spawnRadius, NavMesh.AllAreas))
        //        {
        //            Instantiate(animal, navhit.position, Quaternion.identity);
        //        }
        //    }
        //}
    }
}

