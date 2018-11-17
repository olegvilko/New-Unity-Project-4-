using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public static class SaveLoad
{
  //  [SerializeField]
    private static string filename= "stream";

    public static void Save()
    {
        Debug.Log("Save game");
        string level = SceneManager.GetActiveScene().name;

        StreamWriter streamWriter = new StreamWriter(filename);
        streamWriter.WriteLine(level);
        streamWriter.Close();
    }

    public static void Save(string str)
    {
        Debug.Log("Save game");
        string level = SceneManager.GetActiveScene().name;

        StreamWriter streamWriter = new StreamWriter(filename);
        streamWriter.WriteLine(str);
        streamWriter.Close();
    }


    public static void Load()
    {
        Debug.Log("Load game");

        StreamReader streamReader = new StreamReader(filename);
        if (streamReader != null)
        {
            string level = streamReader.ReadLine();
            SceneManager.LoadScene(level);
            Time.timeScale = 1;
        }
    }

}