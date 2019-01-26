using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;

public class CsvReader : MonoBehaviour
{
    public static CsvReader instance;

    public struct StringTable
    {
        public string[] columns;
        public string[,] content;
    }

    public TextAsset csvFile;
    public StringTable table;

    void Awake()
    {
        instance = this;
        ReadCsvFile();
    }

    private void ReadCsvFile()
    {
        string[] separators = new string[] { "\n\r", "\r\n" };
        string[] lines = csvFile.text.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        int numColumns = lines.Length - 1;
        table.content = new string[numColumns, numColumns];
        table.columns = lines[0].Split(',');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cells = lines[i].Split(',');
            for(int j = 1; j < cells.Length; j++)
            {
                Debug.Log("Celula " + (i - 1) + "," + (j - 1) + ":" + cells[j]);
                table.content[i-1, j-1] = cells[j];
            }
        }
    }

    private void DebugTable(StringTable t)
    {
        string cols = string.Empty;
        foreach(string col in t.columns)
        {
            cols = string.Concat(cols, "~ " + col);
        }

        for(int i = 0; i < t.content.GetLength(0); i++)
        {
            string l = string.Empty;
            for(int j = 0; j < t.content.GetLength(1); j++)
            {
                l = string.Concat(l, " " + t.content[i,j]);
            }
            Debug.Log(l);
        }
    }
}
