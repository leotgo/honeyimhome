using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesInteractions : MonoBehaviour
{
    public static EntitiesInteractions instance;

    public struct Interaction
    {
        public entityTypes entity1;
        public entityTypes entity2;
        public entityTypes result;
    }

    public List<Interaction> interactionResults;

    private void Start()
    {
        instance = this;
        interactionResults = new List<Interaction>();

        ParseInteractionTable();
        DebugInteractions();
    }

    private void ParseInteractionTable()
    {
        CsvReader.StringTable table = CsvReader.instance.table;

        List<entityTypes> types = new List<entityTypes>();
        foreach (string type in table.columns)
        {
            var parsedtype = ParseToEntityType(type);
            if(parsedtype != entityTypes.None)
                types.Add(parsedtype);
        }

        for (int i = 0; i < types.Count; i++)
        {
            for (int j = 0; j < types.Count; j++)
            {
                Interaction interaction;
                interaction.entity1 = types[i];
                interaction.entity2 = types[j];
                interaction.result = ParseToEntityType(table.content[i, j]);
                if(interaction.result != entityTypes.None)
                    interactionResults.Add(interaction);
            }
        }
    }

    private void DebugInteractions()
    {
        foreach (var i in interactionResults)
        {
            Debug.Log("Interaction ( " + i.entity1 + " , " + i.entity2 + " ) = " + i.result);
        }
    }

    public entityTypes ParseToEntityType(string str)
    {
        switch(str)
        {
            case "Mel":
                return entityTypes.Honey;
            case "Cera":
                return entityTypes.Wax;
            case "Larva":
                return entityTypes.Larva;
            case "Abelha":
                return entityTypes.Bee;
            case "Tile":
                return entityTypes.Grid;
            case "Pólen":
                return entityTypes.Polen;
            case "Secreção":
                return entityTypes.Secretion;
            case "Flor":
                return entityTypes.Flower;
            case "Geleia":
                return entityTypes.Jelly;
            default:
                return entityTypes.None;
        }
    }
}
