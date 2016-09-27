GeoMapReader v1.0-alfa, 21 września 2016
---
Czytnik plików danych systemu GEO-MAP.  

# Cechy

* prostota
* odczyt geometrii obiektów
* odczyt numeru operatu
* generowanie zasięgów dla danego operatu

# Pomoc
```c#
var map = new Mapa();
var reader = new MapReader(mapa);
reader.Load("fileName.map");
```

# Kontekst projektu

[Zwinny samuraj](https://docs.google.com/document/d/1KzQ8RNV6Y0hWGIU8NrvJ5ZppsC9On_1ciJ9LptcwHBM/edit?usp=sharing)

## Po co tu jesteśmy (myśl przewodnia)?

Potrzebuję biblioteki do odczytu formatu plików danych systemu GEO-MAP, która będzie wykorzystana w innych projektach.

## Krótkie podsumowanie

Czym jest produkt i dla kogo?

* dla mnie i innych
* którzy potrzebują czytnika plików GEO-MAP
* produkt GeoMapReader
* jest biblioteką
* która pozwala w prosty sposób odczytać dane
* w odróżnieniu od braku takiego rozwiązania
* nasz produkt pozwala na odczyt plików systemu GEO-MAP

## Opakowanie produktu

Jak będzie wyglądał ten produkt:

**GeoMapReader**
	
![Dobre zdjęcie](GeoMapReader/Map.ico)

Prosta, szybka i precyzyjna biblioteka
	
* prostota
* szybkość
* precyzja
	
## Lista "NIE"

Czego nie robimy w tym projekcie.

w zakresie | poza zakresem
--------------- | -----------------------------------
odczyt obiektów | to nie będzie edytor plików GEO-MAP
                | nie będzie zapisu do pliku

nieokreślone | 
--------------
budowa zakresów | 
scalenie z plikiem Tango | 

## Otoczenie projektu

## Szkic rozwiązania

## Oszacowania

Jest to projekt na tydzień.

## Ogólny szkic architektury technicznej

# Historia

Do zrobienia:

- [ ] podręcznik użytkownika
- [x] wczytywanie nagłówka (*)
- [x] wczytywanie atrybutów (:)
- [ ] wczytywanie etykiet (L)
- [x] wczytywanie punktów (P)
- [x] atrybuty wielokrotne (#LIST)
- [ ] lista operatów obiektu (KR)
- [x] wyszukiwanie obiektów według atrybutu ID
- [ ] strona kodowa plików GEO-MAP
- [ ] konstrukcja geometrii obiektu

2016-09-21 v1.0-alfa

* [propozycja projektu](https://docs.google.com/document/d/1O7EHPSBacFY5yFfxNs8UU7O_whekDUPvDwXJXS3iZh0/edit?usp=sharing)
