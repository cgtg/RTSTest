using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class DataManager : SingletoneBase<DataManager>
{
    [ReadOnly, SerializeField] private string _pidStr;

    // 데이터 파일 경로
    private string unitDataFilePath = "Assets/Resources/DataTable/UnitTable.csv";
    public Dictionary<int, UnitData> itemDataDictionary { get; private set; }

    private UnitSO[] unitDatas;

    protected override void Init()
    {
        _pidStr = _pid.ToString();
        base.Init();

        // 데이터 관리
        ReadUnitData();


        // 프리팹 관리
    }


    private void ReadUnitData()
    {
        itemDataDictionary = new Dictionary<int, UnitData>();
        string[] lines = File.ReadAllLines(unitDataFilePath);
        for (int i = 3; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            int uid = int.Parse(fields[0]);
            string character = fields[1];
            string nameAlias = fields[2];
            string descAlias = fields[3];
            int HP = int.Parse(fields[4]);
            int atk = int.Parse(fields[5]);
            string prefabFileName = fields[6];
            string prefabFilePath = fields[7];

            UnitData unitData = new UnitData(uid, character, nameAlias, descAlias, HP, atk, prefabFileName, prefabFilePath);

            itemDataDictionary.Add(uid, unitData);
        }
    }

}


public class UnitData
{
    public int uid;
    public string character;
    public string nameAlias;
    public string descAlias;
    public int HP;
    public int atk;
    public string prefabFileName;
    public string prefabFilePath;

    public UnitData(int _uid, string _character, string _nameAlias, string _descAlias, int _HP, int _atk, string _prefabFileName, string _prefabFilePath)
    {
        uid = _uid;
        character = _character;
        nameAlias = _nameAlias;
        descAlias = _descAlias;
        HP = _HP;
        atk = _atk;
        prefabFileName = _prefabFileName;
        prefabFilePath = _prefabFilePath;
    }
}
