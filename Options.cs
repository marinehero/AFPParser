﻿using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Options
{
    public string LastDirectory { get; set; }

    Options()
    {
        LastDirectory = Environment.CurrentDirectory;
    }

    public static Options LoadSettings(string path)
    {
        Options loadedOpts = new Options();

        try
        {
            // Read if existing
            if (File.Exists(path))
                using (FileStream reader = File.OpenRead(path))
                    loadedOpts = (Options)new XmlSerializer(typeof(Options)).Deserialize(reader);

            // Save
            loadedOpts.SaveSettings(path);
        }
        catch { }

        return loadedOpts;
    }

    public void SaveSettings(string path)
    {
        try
        {
            using (FileStream writer = File.OpenWrite(path))
                new XmlSerializer(typeof(Options)).Serialize(writer, this);
        }
        catch { }
    }
}