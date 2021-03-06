import { Component, OnInit } from '@angular/core';
import { IPokemon } from '../IPokemon';
import { PokemonService } from '../pokemon.service';

@Component({
  selector: 'pokedex',
  templateUrl: './pokedex.component.html',
  styleUrls: ['./pokedex.component.css']
})

export class PokedexComponent implements OnInit {
pokemon:IPokemon[]=[]

  singlePokemon:IPokemon = {
    name:"",
    level: 0,
    attack:0,
    defense: 0,
    health:0
  }

  hide:boolean = true;
  buttonText:string ="show"

  ShowOrHidePokemonForm():void{
    this.hide = !this.hide;
    if(!this.hide)
    {this.buttonText="hide"}
    else {this.buttonText="show"}
  }

  getPokemonFromNewPokemon($event: any):void{
    // console.log(this.pokemon)
    // console.log($event)
    // this.pokemon.push($event);
    // console.log(this.pokemon)
    this.singlePokemon = $event;
    //this.pokemon.push(this.singlePokemon);
    this.addPokemon(this.singlePokemon)
  }
addPokemon(poke:IPokemon):void{
  this.pokemon = this.pokemonService.addPokemon(poke)
}
  constructor(private pokemonService: PokemonService) { }

  ngOnInit(): void {
    this.pokemonService.getPokemon()
    this.pokemon = this.pokemonService.getPokemon()
    }

}
