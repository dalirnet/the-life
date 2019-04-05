using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public static class Helper
{
    private static int secretKey = 220271;

    public static string Md5(string input)
    {
        MD5 md5Object = MD5.Create();
        byte[] byteArray = md5Object.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder stringBuilderObject = new StringBuilder();
        for (int i = 0; i < byteArray.Length; ++i)
        {
            stringBuilderObject.Append(byteArray[i].ToString("x2"));
        }
        return stringBuilderObject.ToString();
    }

    public static string Tlt(string uId, string stringValue)
    {
        string uIdNumber = "";
        foreach (char charString in uId)
        {
            if (uIdNumber.Length > 6)
            {
                break;
            }
            int numberInt;
            if (int.TryParse(charString.ToString(), out numberInt))
            {
                uIdNumber += charString.ToString();
            }
        }
        return Helper.Md5((secretKey + int.Parse(uIdNumber)).ToString() + uId + stringValue);
    }

    public static string ConvertConstName(string value)
    {
        string[] splitArray = Regex.Split(value, @"(?<!^)(?=[A-Z])");
        return string.Join("_", splitArray).ToUpper();
    }

}
