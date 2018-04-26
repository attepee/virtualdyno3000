## Ohjelmoinnin harjoitustyö - Virtualdyno3000

### Ohjelma yleiskuvaus

Virtualdyno3000:lla voidaan kasata autojen kokoonpanoja eri osista ja testata niitä virtuaalidynolla.

#### Kohdeyleisö

Ohjelman kohdeyleisönä on autoista ja niiden tuunaamisesta kiinnostuneet.

#### Käyttöympäristö ja teknologiat

Sovellus on tarkoitettu käytettäväksi Windows-käyttöjärjestelmällä. Sovelluksen toteutukseen käytetään C#-kieltä ja WPF-kirjastoa. Tarvittavan tiedon tallentamiseen käytetään Labranetin palvelimilla sijaitsevaa MySQL-tietokantaa.

#### Toiminnot

* Kokoonpanon kasaaminen valittavissa olevista osista
* Kasatun kokoonpanon testaaminen
* Grafiikan piirtäminen testituloksen mukaan
* Kokoonpanojen ja testitulosten tallentaminen tietokantaan

![usecase](Images/usecase.png)

#### Käsitemalli

![Käsitemalli](Images/kasitemalli.png)

### Tekijät ja työnjako

| Tekijä                                              | Vastuu                                      |
| --------------------------------------------------- | ------------------------------------------- |
| [Matti Aho](https://github.com/matti644)            | Tietokantayhteys, ModWindow, Dynon logiikka |
| [Niklas Hietaranta](https://github.com/niklashieta) | Testigrafiikka, DynoWindow                  |
| [Atte Pekkarinen](https://github.com/attepee)       | Dokumentaatio, MainWindow, NewPartWindow    |

#### Työaikasuunnitelma

| Työn osa     | Valmis      |
| --------     | ----------- |
| Suunnitelma  | 8.4.        |
| Ikkunat      | Viim. 24.4. |
| Harjoitustyö | 25.4.       |
