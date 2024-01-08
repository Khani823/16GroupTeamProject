using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



//Json« ø‰

public class ExperienceTable : MonoBehaviour
{
    private Dictionary<int, int> experienceTable;

    public ExperienceTable()
    {
        experienceTable = new Dictionary<int, int>();
        LoadExperienceTable();
    }

    private void LoadExperienceTable()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "experience_table.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            experienceTable = JsonUtility.FromJson<Dictionary<int, int>>(json);
        }
        else
        {
            Debug.LogError("Experience table JSON file not found.");
        }
    }

    public int GetExperienceForLevel(int level)
    {
        if (experienceTable.ContainsKey(level))
        {
            return experienceTable[level];
        }
        return 0;
    }
}
