
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveload 
{
    // Start is called before the first frame update
     public static void savegame(gamemanager gm)
    {
        BinaryFormatter formatter=new BinaryFormatter();
        string path=Application.persistentDataPath+"/gamedata.pdf";
        FileStream stream;
        if(File.Exists(path))
        {
            stream=new FileStream(path,FileMode.Open);
        }
        else
        {
            stream=new FileStream(path,FileMode.Create);
        }
        generalgamemanagerclass data=new generalgamemanagerclass(gm);
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static generalgamemanagerclass Loadgame ()
    {
        string path=Application.persistentDataPath+"/gamedata.pdf";
        if(File.Exists(path))
        {
            BinaryFormatter formatter=new BinaryFormatter();
            FileStream stream=new FileStream (path,FileMode.Open);
            generalgamemanagerclass data=formatter.Deserialize(stream) as generalgamemanagerclass;
            stream.Close();
            return data;
        }
       else
       {
           Debug.Log("file is not available");
           return null;
       }
    }

}
