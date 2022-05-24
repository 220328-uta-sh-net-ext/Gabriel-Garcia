function getPoky() {
    console.log("get poky started");
    //logic to pokemon from the api: https://pokeapi.co/
    let pokemon = {};
    let pokeName = document.getElementById("pokemonName").value;
    let request = new XMLHttpRequest();
    request.open("GET", `https://pokeapi.co/api/v2/pokemon/${pokeName}`, true);
    request.send();
    request.onreadystatechange = function() {
        if (this.readyState == 4 && (this.status > 199 && this.status < 300)) {
            pokemon = JSON.parse(request.responseText);
            console.log(pokemon);
            displayRokemon(pokemon);
        }
    }
    console.log("get poky finished");
}

function displayRokemon(poke) {
    document.getElementById("pokeImage").setAttribute("src", poke.sprites.front_default);
}