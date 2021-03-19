using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using dbClasses;
using System.IO;
using UnityEngine.UI;

public class dbController : MonoBehaviour
{

     string DBPath = GetDatabasePath();
  [SerializeField]  private GameObject HP, DMG, ability,name;

    private static string GetDatabasePath()
    {
#if UNITY_EDITOR
        return Path.Combine(Application.streamingAssetsPath, "MainBd.db");
#elif UNITY_STANDALONE
        string filePath = Path.Combine(Application.dataPath, "MainBd.db");
        if (!File.Exists("MainBd.db")) UnpackDatabase("MainBd.db");
        return filePath;
#elif UNITY_ANDROID
    string filePath = Path.Combine(Application.persistentDataPath, "MainBd.db");
    if(!File.Exists("MainBd.db")) UnpackDatabase("MainBd.db");
    return filePath;

#endif
    }

    [System.Obsolete]
    private static void UnpackDatabase(string toPath)
    {
#if UNITY_ANDROID

        var reader = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "MainBd.db");
        File.WriteAllBytes(toPath, reader.bytes);
#elif UNITY_EDITOR
        string fromPath = Path.Combine(Application.streamingAssetsPath, "MainBd.db");

        WWW reader = new WWW(fromPath);
        while (!reader.isDone) { }

        File.WriteAllBytes(toPath, reader.bytes);
#endif
    }


    public void Skaner(int ID)
    {
        
        // Создаем новое подключение к базе данных
        using (var db = new SQLiteConnection(DBPath))
        {
           
            // Делаем запрос на выборку данных
            IEnumerable<dbClasses.Monstr> list = db.Query<dbClasses.Monstr>("SELECT * FROM Monstr");
           
            foreach (dbClasses.Monstr monstr in list) {
                if (monstr.ID == ID) {
                  
                    HP.GetComponent<Text>().text = monstr.HP.ToString();
                    DMG.GetComponent<Text>().text = monstr.DMG.ToString();
                    ability.GetComponent<Text>().text = monstr.Ability;
                    name.GetComponent<Text>().text = monstr.Name;
                 
                }
            }
               
                db.Close();

        }



        /*// Вывод таблицы events
        using (var db = new SQLiteConnection(Application.dataPath + "/StreamingAssets/dbMain.db"))
        {
            IEnumerable<Events> lst = db.Query<Events>("SELECT Events.EventName, Players.Name FROM Events, Players WHERE Events.PlayerID = Players.ID");
            List<Events> list = lst.ToList();
            IEnumerable<Players> lst2 = db.Query<Players>("SELECT Events.EventName, Players.Name FROM Events, Players WHERE Events.PlayerID = Players.ID");
            List<Players> list2 = lst2.ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = i; j < list2.Count(); j++)
                {
                    Events events = list[j];
                    Players player = list2[j];
                    const string frmt = "Event Name: {0}, Name: {1}";
                    Debug.Log(string.Format(frmt,
                        events.EventName,
                        player.Name
                        ));
                }
            }
            db.Close();
        }*/
    }
}
