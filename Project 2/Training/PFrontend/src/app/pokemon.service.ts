import { Injectable } from '@angular/core';
import { IPokemon } from './IPokemon';
import { POKEMON } from './mock-pokemon';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  allPokemon:IPokemon[] = [];

  getPokemon():IPokemon[]{
    return POKEMON
  }
  addPokemon(pokemon:IPokemon):IPokemon[]{
    let allPokemon: IPokemon[] = POKEMON;
    allPokemon.push(pokemon);
    return allPokemon;
  }
  constructor() { }
}
