using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public static class SaveLoad
{
   // private static string filename=LinksManager.filenameSaveLoad;

    public static void Save()
    {
        Debug.Log("Save game");
        string level = SceneManager.GetActiveScene().name;

        StreamWriter streamWriter = new StreamWriter(LinksManager.filenameSaveLoad);
        streamWriter.WriteLine(level);
        streamWriter.Close();
    }

    public static void Save(string str)
    {
        Debug.Log("Save game");
        string level = SceneManager.GetActiveScene().name;

        StreamWriter streamWriter = new StreamWriter(LinksManager.filenameSaveLoad);
        streamWriter.WriteLine(str);
        streamWriter.Close();
    }

    public static void Load()
    {
        Debug.Log("Load game");
        StreamReader streamReader = new StreamReader(LinksManager.filenameSaveLoad);
        if (streamReader != null)
        {
            string level = streamReader.ReadLine();
            SceneManager.LoadScene(level);
            Time.timeScale = 1;
        }
    }

    public static void SaveIni()
    {
        float volume = AudioListener.volume;
        StreamWriter streamWriter = new StreamWriter(LinksManager.fileNameIni);
        streamWriter.WriteLine(volume.ToString());
        streamWriter.Close();
    }

    public static void LoadIni()
    {
        StreamReader streamReader = new StreamReader(LinksManager.fileNameIni);
        string volume;
        if (streamReader != null)
        {
            volume = streamReader.ReadLine();
        } else
        {
            volume = AudioListener.volume.ToString();
            SaveIni();
        }
        AudioListener.volume = float.Parse(volume, CultureInfo.InvariantCulture.NumberFormat);
    }
}