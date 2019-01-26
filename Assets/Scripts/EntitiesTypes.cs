using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum entityTypes
{
    None,        // Entidade que representa nada

    Honey,       // OBJETO de mel, que abelha pode pegar
    Wax,         // OBJETO de cera, que abelha pode pegar
    Larva,       // OBJETO de larva, que abelha pode pegar
    Polen,       // OBJETO de polen, que abelha pode pegar
    Secretion,   // OBJETO, que abelha pode pegar
    Flower,      // OBJETO de flor, que abelha pode pegar
    Jelly,       // OBJETO de geléia, que abelha pode pegar
    Directional, // OBJETO direcional, que pode ser botado em um tile pelo jogador

    Bee,         // Abelha, que pode pegar objeto
    Player,      // Jogador

    Grid,             // Uma célula no grid sem nada, pode virar tile
    NormalTile,       // Um tile normal (neutro), que não faz nada
    HoneyTile,        // Produz mel
    WaxTile,          // Um tile que produz cera
    LarvaTile,        // Produz larvas
    PolenTile,        // Produz pólen
    SecretionTile,    // Produz secreção
    FlowerTile,       // Produz flores
    JellyTile,        // Produz Geléia
    DirectionalTile   // Produz direcionais
}

public enum actionTypes
{
    None,      // Nada acontece
    Get,       // Pega objeto no tile
    Generate,  // Tile gera objeto
    Paint,     // Pinta tile com algum tipo
    Disappear, // Quando abelha toca no grid sem nada, ela desaparece
    Redirect   // Redireciona entidade
}

// Directional pode ficar em qualquer tile
