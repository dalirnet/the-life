using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TempDB
{

    public static void Set<valueType>(string key, valueType value)
    {
        string stringValue = System.Convert.ToString(value);
        string convertConstName = Helper.ConvertConstName(key);
        if (typeof(TempDbConst).GetField(convertConstName) != null)
        {
            PlayerPrefs.SetString(key + ".Tlt", Helper.Tlt(SystemInfo.deviceUniqueIdentifier, stringValue));
            PlayerPrefs.SetString(key + ".Value", stringValue);
        }
    }

    public static string Get(string key)
    {
        string convertConstName = Helper.ConvertConstName(key);
        if (typeof(TempDbConst).GetField(convertConstName) != null)
        {
            string checkTlt = PlayerPrefs.GetString(key + ".Tlt", "");
            string checkValue = PlayerPrefs.GetString(key + ".Value", "");
            if (checkTlt == Helper.Tlt(SystemInfo.deviceUniqueIdentifier, checkValue))
            {
                return checkValue;
            }
            else
            {
                string defaultString = System.Convert.ToString(typeof(TempDbConst).GetField(convertConstName).GetValue(null));
                TempDB.Set(key, defaultString);
                return defaultString;
            }
        }

        return "";
    }

    public static void SetToDefault(string key)
    {
        string convertConstName = Helper.ConvertConstName(key);
        if (typeof(TempDbConst).GetField(convertConstName) != null)
        {
            TempDB.Set(key, System.Convert.ToString(typeof(TempDbConst).GetField(convertConstName).GetValue(null)));
        }
    }
	
}
