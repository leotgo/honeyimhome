using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesInteractions : MonoBehaviour
{
    public static EntitiesInteractions instance;

    // Dicionário de interações
    // Chave: Representa as duas entidades que engatilharam interação
    // Valor: Representa a ação resultante da interação entre essas duas entidades
    public Dictionary<KeyValuePair<entityTypes, entityTypes>, actionTypes> interactions;

    private void Start()
    {
        instance = this;
        interactions = new Dictionary<KeyValuePair<entityTypes, entityTypes>, actionTypes>();
        ParseInteractionTable();
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
                var pair = new KeyValuePair<entityTypes, entityTypes>(types[i], types[j]);
                var result = ParseToActionType(table.content[i, j]);
                if (result != actionTypes.None)
                    interactions.Add(pair, result);
            }
        }
    }

    public entityTypes ParseToEntityType(string str)
    {
        switch(str)
        {
            case "Honey":
                return entityTypes.Honey;
            case "Wax":
                return entityTypes.Wax;
            case "Larva":
                return entityTypes.Larva;
            case "Bee":
                return entityTypes.Bee;
            case "Grid":
                return entityTypes.Grid;
            case "Polen":
                return entityTypes.Polen;
            case "Secretion":
                return entityTypes.Secretion;
            case "Flower":
                return entityTypes.Flower;
            case "Jelly":
                return entityTypes.Jelly;
            default:
                return entityTypes.None;
        }
    }

    public actionTypes ParseToActionType(string str)
    {
        switch(str)
        {
            case "Get":
                return actionTypes.Get;
            case "Paint":
                return actionTypes.Paint;
            case "Generate":
                return actionTypes.Generate;
            case "Disappear":
                return actionTypes.Disappear;
            case "Redirect":
                return actionTypes.Redirect;
            default:
                return actionTypes.None;
        }
    }

    public void ProcessInteraction(Entity a, Entity b)
    {
        var pair = new KeyValuePair<entityTypes, entityTypes>(a.type, b.type);
        actionTypes action;
        if(interactions.TryGetValue(pair, out action))
        {
            switch(action)
            {
                case actionTypes.Get:
                    {
                        pickup p = null;
                        Bee bee = null;

                        if (a is pickup)
                            p = (pickup)a;
                        else if (b is pickup)
                            p = (pickup)b;

                        if (a is Bee)
                            bee = (Bee)a;
                        else if (b is Bee)
                            bee = (Bee)b;

                        if (p != null && bee != null)
                            Get(bee, p);
                    }
                    break;

                case actionTypes.Paint:
                    {
                        pickup p = null;
                        HexagonTile tile = null;

                        if (a is pickup)
                            p = (pickup)a;
                        else if (b is pickup)
                            p = (pickup)b;

                        if (a is HexagonTile)
                            tile = (HexagonTile)a;
                        else if (b is HexagonTile)
                            tile = (HexagonTile)b;

                        if (p != null && tile != null)
                            Paint(tile, p);
                    }
                    break;

                case actionTypes.Disappear:
                    {
                        HexagonTile tile = null;
                        Bee bee = null;

                        if (a is HexagonTile)
                            tile = (HexagonTile)a;
                        else if (b is HexagonTile)
                            tile = (HexagonTile)b;

                        if (a is Bee)
                            bee = (Bee)a;
                        else if (b is Bee)
                            bee = (Bee)b;

                        if (bee != null && tile != null)
                            Disappear(bee, tile);
                    }
                    break;

                case actionTypes.Redirect:
                    {
                        HexagonTile tile = null;
                        Bee bee = null;

                        if (a is HexagonTile)
                            tile = (HexagonTile)a;
                        else if (b is HexagonTile)
                            tile = (HexagonTile)b;

                        if (a is Bee)
                            bee = (Bee)a;
                        else if (b is Bee)
                            bee = (Bee)b;

                        if (bee != null && tile != null)
                            Redirect(bee, tile);
                    }
                    break;
            }
        }
    }

    public void Get(Bee bee, pickup p)
    {
        if (bee.carryingObject == null)
        {
            p.transform.parent = transform;
            p.transform.position = bee.pickupPos.position;
            bee.carryingObject = p.GetComponent<pickup>();
        }
    }

    public void Paint(HexagonTile tile, pickup p)
    {
        // Fazer aqui o código que muda o tile
        p.OnConsume();
        var newTile = p.tilePrefab;
        // fazer alguma coisa com esse newTile
    }

    public void Disappear(Bee bee, HexagonTile tile)
    {
        if(tile.type == entityTypes.Grid && bee.type != entityTypes.Player)
        {
            bee.OnDeath();
        }
    }

    public void Redirect(Bee bee, HexagonTile tile)
    {
        // Código de redireção da abelha
    }
}
