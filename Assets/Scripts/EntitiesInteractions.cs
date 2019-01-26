using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesInteractions
{
    public struct Interaction
    {
        public entitiesTypes entity1;
        public entitiesTypes entity2;
        public entitiesTypes result;
    }

    // A Key do dicionário (KeyValuePair) representa os dois elementos da interação
    // O Value do dicionário representa o resultado da interação entre esses dois elementos
    public List<Interaction> interactionResults; 
    
    
}
