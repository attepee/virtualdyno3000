## Ohjelmoinnin harjoitustyö - Virtualdyno3000

### Ohjelma

Virtualdyno3000:lla voidaan kasata autojen kokoonpanoja eri osista ja testata niitä virtuaalidynolla. Ohjelman alkuperäinen suunnitelma löytyy [suunnitelma.md](suunnitelma.md) -tiedostosta.

#### Toteutuneet toiminnot

* Kokoonpanon kasaaminen valittavissa olevista osista
* Kasatun kokoonpanon testaaminen
* Grafiikan piirtäminen testituloksen mukaan
* Osien lisääminen, muokkaaminen ja poistaminen
* Autojen lisääminen ja poistaminen

#### Toteutumattomat toiminnot

* Kokoonpanojen ja testitulosten tallentaminen tietokantaan

#### Käyttöohje/käyttöliittymä

#####  Pääikkuna

Pääikkunassa on nähtävillä kaikki ohjelmaan lisätyt autot ja ikkunasta pääsee käsiksi ohjelman toimintoihin.

![](Images/main.JPG)

#####  Auton lisääminen

Auton lisäämis -ikkunasta voidaan lisätä ohjelmaan uusia autoja. 

![](Images/newcar.JPG)

#####  Dyno

Dynolla tehdään itse auton testaaminen. Testissä valittun auton teon mukaan piirretään käyrä ja annetaan muita tietoja auton tehosta. Tähän ikkunaan pääsee valitsemalla auton pääikkunasta ja painamalla Dyno-nappia

![](Images/dyno.JPG)

#####  Auton modifikointi

Auton modifikointi -ikkunassa voidaan vaihtaa auton osia. Tähän ikkunaan pääsee valitsemalla auton pääikkunasta ja painamalla Modifications-nappia

![](Images/mod.JPG)

#####  Osan lisääminen

Osien lisäämis -ikkunassa voidaan lisätä uusi osia ohjelmaan

![](Images/newpart.JPG)

#####  Osan muokkaaminen

Osan muokkaamis -ikkunassa voidaan muokata osien tietoja. Tähän ikkunaan pääsee valitsemalla osan auton modifikointi -ikkunasta ja painamalla Modify part -nappia

![](Images/modpart.JPG)

### Ongelmat ja bugit

* Toistaiseksi ohjelma on todettu toimivaksi Windows 7 ja -10 -käyttöjärjestelmillä.
* Ohjelman käyttöä varten täytyy olla joko JAMK Labranetin verkossa tai sinne on oltava VPN-yhteys Labranetin verkossa sijaitsevan tietokannan vuoksi
* Suoraan tälllaisenaan ohjelma ei toimi, koska Matin tietokannan salasana on poistettu, jotta repositoria saatiin julkiseksi

### Mitä opittiin



### Vastuiden ja työmäärän jakautuminen

| Tekijä                                                     | Vastuu                                                                   |
| ---------------------------------------------------------- | ------------------------------------------------------------------------ |
| [Matti Aho](https://github.com/matti644), K9251            | Tietokantayhteys, Dynon logiikka                                         |
| [Niklas Hietaranta](https://github.com/niklashieta), K9279 | Testigrafiikka, DynoWindow                                               |
| [Atte Pekkarinen](https://github.com/attepee), L5566       | Dokumentaatio, MainWindow, NewPartWindow, NewCarWindow, ModyfyPartWindow |

### Arvosanaehdotus

