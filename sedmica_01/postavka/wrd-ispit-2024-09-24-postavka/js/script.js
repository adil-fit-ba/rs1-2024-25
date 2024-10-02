const baseUrl = "https://wrd-fit.info";

let globalPodaci = [];
let preuzmi = () => {
    //https://wrd-fit.info/ -> Ispit20240921 -> GetPonuda

    let url = `${baseUrl}/Ispit20240921/GetNovePonude`
    destinacije.innerHTML = '';//brisemo destinacije koje su hardkodirane (tj. nalaze se u HTML-u)
    fetch(url)
        .then(r => {
            if (r.status !== 200) {
                //greska
                return;
            }
            r.json().then(t => {

                let b = 0;
                globalPodaci = t.podaci //setujemo globalnu varijablu

                for (const x of t.podaci) {
                    destinacije.innerHTML += `
                    <article class="offer">
                        <div class="akcija">Polazak za <br>${x.naredniPolazak.zaDana} dana</div>
                        <div class="offer-image" style="background-image: url('${x.slikaUrl}');" ></div>
                        <div class="offer-details">
                            <div class="offer-destination">${x.drzava}</div> 
                            <div class="offer-description">${x.opisPonude} ${x.opisPonude})}</div>    
                        </div>

                        <div class="offer-footer">
                            <div class="offer-info">
                                <div class="offer-price">
                                    ${x.naredniPolazak.cijenaPoOsobiEur} €
                                </div>
                                <div class="offer-free">
                                    <span>
                                        Slobodno mjesta: ${x.naredniPolazak.countSlobodnoMjesta}
                                    </span>
                                </div> 
                            </div>        
                            <div class="ponuda-dugme" onclick="K2_odaberiDestinaciju(${b})">K2 Pogledaj</div>
                        </div>
                    </article>
                    `
                    b++;
                }
            })
        })
}

preuzmi();

let K2_odaberiDestinaciju = (rbDrzave) => {
    let destinacijObj = globalPodaci[rbDrzave];
    let s = "";
    let rbPolaska = 0;
    for (const o of destinacijObj.planiranaPutovanja) {
        s += `
        <tr>
            <td>ID ${o.idPutovanje}</td>
            <td>${o.datumPol}</td>
            <td>${o.datumPov}</td>
            <td>${o.countSlobodnoMjesta}</td>
            <td>${o.brojDana}</td>
            <td>${o.cijenaPoOsobiEur} €</td>
            <td><button>K3 Odaberi putovanje</button></td>
        </tr>`
        rbPolaska++;
    }
    putovanjaTabela.innerHTML = s;
}


/*
//dodatna pomoc za RS1
let generisiGradove = ()=>{
    vrijemeGradova.innerHTML += `<div class="city-card">
    <h2 class="city-name"><p> Naziv grada</p> strelica</h2>
    <div class="city-card-right">
      <div class="wind-vel">
        <span>Brzina vjetra:</span>
        <div class="propeller">
          propeler
        </div>
      </div>
      <div class="temp">
        <span>Temperatura:</span>
       <div class="termometar>
      </div>
    </div>
  </div>`
  setRotaciju(vel,id);
  setTemperaturu(color, id);
  setSmjerVjetra(deg,id)
}
  */

function setSmjerVjetra(direction, id) {
    const arrow = document.getElementById("wind-indicator-" + id);
    arrow.style.transform = `rotate(${direction}deg)`;
}


let setRotaciju = (vel, id) => {
    document.getElementById('propeller-' + id).style.animationDuration = `${10 / vel}s`;
}
let setTemperaturu = (color, id) => {
    document.getElementById('path1933-9-9-' + id).style.fill = color;
}


let getTempColor = (temp) => {
    if (temp >= 40)
        return 'red';
    if (temp < 40 && temp >= 30) {
        return 'rgb(235, 100, 52)'
    }
    if (temp < 30 && temp >= 20)
        return 'rgb(235, 134, 52)'
    if (temp < 20 && temp >= 10)
        return 'rgb(235, 211, 52)'
    if (temp < 10 && temp >= 0)
        return 'rgb(52, 235, 116)'
    if (temp < 0)
        return 'rgb(52, 58, 235)'
}


let ErrorBackgroundColor = "#FE7D7D";
let OkBackgroundColor = "#DFF6D8";

let posalji = () => {
    //https://wrd-fit.info/ -> Ispit20240921 -> Dodaj


    let jsObjekat = new Object();


    let jsonString = JSON.stringify(jsObjekat);

    console.log(jsObjekat);

    let url = `${baseUrl}/Ispit20240921/Dodaj`;

    //fetch tipa "POST" i saljemo "jsonString"
    fetch(url, {
        method: "POST",
        body: jsonString,
        headers: {
            "Content-Type": "application/json",
        }
    })
        .then(r => {
            if (r.status != 200) {
                alert("Greška")
                return;
            }

            r.json().then(t => {

                if (t.brojGresaka == 0) {
                    dialogSuccess(`Idi na placanje rezervacije broj ${t.idRezervacije} - iznos ${ukupnaCijena.value} EUR`, () => {
                        window.location = `https://www.paypal.com/cgi-bin/webscr?business=adil.joldic@yahoo.com&cmd=_xclick&currency_code=EUR&amount=${ukupnaCijena.value}&item_name=Dummy invoice`
                    });
                }
                else {
                    alert("greske: \n" + t.spisakGresaka.join('\n'));
                }
            })

        })
}

let promjenaBrojaGostiju = () => {

}

let provjeriBrojGostiju = () => {

}

let provjeriImePrezimeGostiju = () => {

}

let provjeriBrojPasosa = () => {

}

let provjeriDatumPasos = () => {

}

let provjeriEmail = () => {

}

let provjeriTelefon = () => {

}

