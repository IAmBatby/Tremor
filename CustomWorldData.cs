using System;
using System.IO;
using System.Collections.Generic;
using Terraria;

namespace Tremor
{
    public static class CustomWorldData
    {
        public const char SpaceChar = '~';

        public static Dictionary<string, float> Number = new Dictionary<string, float>();
        public static Dictionary<string, bool> Switch = new Dictionary<string, bool>();
        public static Dictionary<string, string> String = new Dictionary<string, string>();

        public static string WorldName { get { return Main.worldPathName.Split(new char[] { '/', '\\' })[Main.worldPathName.Split(new char[] { '/', '\\' }).Length - 1].Remove(Main.worldPathName.Split(new char[] { '/', '\\' })[Main.worldPathName.Split(new char[] { '/', '\\' }).Length - 1].Length - 4); } }
        public static string LastLoadedWorld = "";

        public static void SetNumber(string Key, float Value)
        {
            if (Number.Count < 1 || LastLoadedWorld != WorldName)
                Load(true);
            if (Number.ContainsKey(Key))
                Number[Key] = Value;
            else
                Number.Add(Key, Value);
            Save(true);
        }

        public static void SetSwitch(string Key, bool Value)
        {
            if (Switch.Count < 1 || LastLoadedWorld != WorldName)
                Load(false, true);
            if (Switch.ContainsKey(Key))
                Switch[Key] = Value;
            else
                Switch.Add(Key, Value);
            Save(false, true);
        }

        public static void SetString(string Key, string Value)
        {
            if (String.Count < 1 || LastLoadedWorld != WorldName)
                Load(false, false, true);
            if (String.ContainsKey(Key))
                String[Key] = Value;
            else
                String.Add(Key, Value);
            Save(false, false, true);
        }

        public static float GetNumber(string Key)
        {
            if (Number.Count < 1 || LastLoadedWorld != WorldName)
                Load(true);
            if (Number.ContainsKey(Key))
                return Number[Key];
            return 0.0f;
        }

        public static bool GetSwitch(string Key)
        {
            if (Switch.Count < 1 || LastLoadedWorld != WorldName)
                Load(false, true);
            if (Switch.ContainsKey(Key))
                return Switch[Key];
            return false;
        }

        public static string GetString(string Key)
        {
            if (String.Count < 1 || LastLoadedWorld != WorldName)
                Load(false, false, true);
            if (String.ContainsKey(Key))
                return String[Key];
            return "";
        }

        public static void Save(bool Nu, bool Sw = false, bool St = false)
        {
            if (Number.Count > 0 && Nu)
            {
                string FileName = Main.WorldPath + "\\" + WorldName + ".tnu";
                FileStream FS = new FileStream(FileName, FileMode.Create);
                StreamWriter SW = new StreamWriter(FS, System.Text.Encoding.Default);
                foreach (string Key in Number.Keys)
                    SW.WriteLine(Key + SpaceChar + Number[Key]);
                SW.Close();
                FS.Close();
            }
            if (Switch.Count > 0 && Sw)
            {
                string FileName = Main.WorldPath + "\\" + WorldName + ".tsw";
                FileStream FS = new FileStream(FileName, FileMode.Create);
                StreamWriter SW = new StreamWriter(FS, System.Text.Encoding.Default);
                foreach (string Key in Switch.Keys)
                    SW.WriteLine(Key + SpaceChar + Switch[Key]);
                SW.Close();
                FS.Close();
            }
            if (String.Count > 0 && St)
            {
                string FileName = Main.WorldPath + "\\" + WorldName + ".tst";
                FileStream FS = new FileStream(FileName, FileMode.Create);
                StreamWriter SW = new StreamWriter(FS, System.Text.Encoding.Default);
                foreach (string Key in String.Keys)
                    SW.WriteLine(Key + SpaceChar + String[Key]);
                SW.Close();
                FS.Close();
            }
        }

        public static void Load(bool Nu, bool Sw = false, bool St = false)
        {
            LastLoadedWorld = Main.worldPathName;
            Number = new Dictionary<string, float>();
            Switch = new Dictionary<string, bool>();
            String = new Dictionary<string, string>();
            if (Nu)
            {
                string FileName = Main.WorldPath + "\\" + WorldName + ".tnu";
                FileStream FS = new FileStream(FileName, FileMode.OpenOrCreate);
                StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
                while (!SR.EndOfStream)
                {
                    try
                    {
                        string[] Part = SR.ReadLine().Split(SpaceChar);
                        Number.Add(Part[0], Convert.ToSingle(Part[1]));
                    }
                    catch { }
                }
                SR.Close();
                FS.Close();
            }
            if (Sw)
            {
                string FileName = Main.WorldPath + "\\" + WorldName + ".tsw";
                FileStream FS = new FileStream(FileName, FileMode.OpenOrCreate);
                StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
                while (!SR.EndOfStream)
                {
                    try
                    {
                        string[] Part = SR.ReadLine().Split(SpaceChar);
                        Switch.Add(Part[0], Convert.ToBoolean(Part[1]));
                    }
                    catch { }
                }
                SR.Close();
                FS.Close();
            }
            if (St)
            {
                string FileName = Main.WorldPath + "\\" + WorldName + ".tst";
                FileStream FS = new FileStream(FileName, FileMode.OpenOrCreate);
                StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
                while (!SR.EndOfStream)
                {
                    try
                    {
                        string[] Part = SR.ReadLine().Split(SpaceChar);
                        String.Add(Part[0], Part[1]);
                    }
                    catch { }
                }
                SR.Close();
                FS.Close();
            }
        }
    }
}