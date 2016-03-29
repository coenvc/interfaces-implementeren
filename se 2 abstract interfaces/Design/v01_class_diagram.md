# Toelichting klassendiagram

Het centrale punt in het ontwerp is de `World` klasse. Het is de intentie dat
alle communicatie via deze klasse loopt. De klasse is primair verantwoordelijk
voor het bijwerken en tekenen van de spelstatus. De `update` methode zorgt
ervoor dat de speler en tegenstander hun status kunnen bijwerken. Hetzelfde
geldt voor de `draw` methode. Daarnaast bepaalt deze klasse of de speler af is,
of juist het doel bereikt heeft middels de `gameWon` en `gameOver` attributen.

De `Player` en `Enemy` klassen zijn respectievelijk de speler en de
tegenstander. Een aantal zaken hebben deze gemeen zoals de positie en de
hitpoints. Via het formulier zal nu nog doorgegeven moeten worden aan de speler
wat deze moet doen. De `keyCode` in de `interaction` methode geeft aan welke
toets ingedrukt is: deze wordt aan de `KeyDown` methode meegegeven, wat dus
gebruikt kan worden om de speler te laten bewegen.

De `Map` bevat het speelveld. In de opdracht is aangegeven dat het veld altijd
vierkant is, maar naar de toekomst toe is er toch voor gekozen om de breedte en
hoogte apart op te slaan. De `mapSize` bevat dan de grootte van het speelveld
in pixels; de `cellSize` de grootte van een individuele cel; `cellCount` geeft
tot slot aan hoe veel cellen is in beide richtingen bestaan.

Binnen de `Map` klasse is er voor gekozen om de te bereiken locatie beschikbaar
te maken via het `goalPosition` attribuut. De reden dat we hier geen cel
retourneren maar de positie van een cel heeft te maken met het feit dat er dan
geen afhankelijkheden zijn naar de `Cell` klasse: alleen de klasse `Map`
gebruikt deze. Deze ontkoppeling maakt het eenvoudiger om klassen te bewerken
en onderhouden.

In de `Cell` klasse beschrijft het `index` attribuut welke cell het is. Stel
dat deze waarde (3, 2) zou zijn, dat ligt deze cel in de vierde kolom, derde
rij. De `position` is het coördinaat van de cell in pixels.

Tot slot zijn er nog een tweetal enumeraties, `CellType` en `Action`. De eerste
wordt door de `Cell` klasse gebruikt om van iedere cel het type aan te geven.
De tweede wordt gebruikt door de `Player` en `Enemy` om duidelijk aan te geven
welke handling er verricht wordt. De `System.Drawing` package laat zien welke
klassen uit het .NET framework benodigd zijn.

