using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;

public class CsvReader : MonoBehaviour
{
    public struct StringTable
    {
        public string[] columns;
        public string[,] content;
    }

    public TextAsset csvFile;
    public StringTable table;

    void Awake()
    {
        ReadCsvFile();
        DebugTable(table);
    }

    private void ReadCsvFile()
    {
        string[] lines = Regex.Split(csvFile.text, "\n|\r|\r\n");
        int numColumns = lines.Length - 1;
        table.content = new string[numColumns, numColumns];
        for (int i = 0; i < lines.Length; i++)
        {
            if (i == 0)
                table.columns = lines[i].Split(',');
            else
            {
                string[] cells = lines[i].Split(',');
                for(int j = 0; j < cells.Length; j++)
                {
                    table.content[i-1, j] = cells[j];
                }
            }
        }
    }

    private void DebugTable(StringTable t)
    {
        string cols = string.Empty;
        foreach(string col in t.columns)
        {
            cols = string.Concat(cols, ", " + col);
        }
        Debug.Log(cols);

        for(int i = 0; i < t.content.GetLength(0); i++)
        {
            string l = string.Empty;
            for(int j = 0; j < t.content.GetLength(1); j++)
            {
                l = string.Concat(l, ", " + t.content[i,j]);
            }
            Debug.Log(l);
        }
    }
}
