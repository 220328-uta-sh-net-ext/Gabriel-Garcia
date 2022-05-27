import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject, throwError, catchError, map } from 'rxjs';
import { IPokemon } from './IPokemon';
import { LoginService } from './login.service';
import { POKEMON } from './mock-pokemon';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  //allPokemon:IPokemon[] = [];

  getPokemon():IPokemon[]{
    return POKEMON
  }
  addPokemon(pokemon:IPokemon) : IPokemon[]{
    let allPokemon:IPokemon[] = POKEMON;
    allPokemon.push(pokemon);
    return allPokemon;
  }
   //Let's make a new addPokemon
  //  addPokemon(pokemon:IPokemon) : void{
  //   this.http.post<IPokemon>('https://pokeapi-2203.azurewebsites.net/api/Pokemon', JSON.stringify(pokemon),
  //   { headers : {
  //     'Content-Type': 'application/json',
  //     'Authorization' :'Bearer ' + this.loginService.token
  //   }})
  //   .pipe(
  //     catchError((e) => {
  //       return throwError(e)
  //     }))
  //   .subscribe((data) => {
  //     this.allPokemon.push(data)
  //     this.subject.next(this.allPokemon)
  //   })
  //}
  constructor() { }
}
