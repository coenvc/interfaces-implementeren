# Toelichting klassendiagram

Ten opzicht van de vorige versie is het diagram bijgewerkt op basis van
inzichten verkregen tijdens de implementatie. Het meest opvallend is de
introductie van de `Random` klasse. Deze statische klasse is toegevoegd om te
voorkomen dat, wanneer in korte tijd op meerdere plekken willekeurige getallen
gegenereerd werden, deze identiek werden. De achterliggende reden heeft de
maken met de manier waarop deze random number generators werken. Door nu een
centrale plek voor willekeurige getallen aan te maken wordt het probleem van
identieke getallen voorkomen.

Een klasse is van naam veranderd: de `Map` klasse heet nu `Grid`. Bij het
inrichten van de code bleek het logischer om de `Grid` en `Cell` klassen samen
in een namespace in te delen, waarvoor `Map` de meest logische naam was.
Aangezien het niet wordt aangeraden om klassen dezelfde naam te geven als de
namespace waartoe ze behoren, is de klasse hernoemd.

De methode `interaction` uit de `Player` klasse is aangepast zodat deze een
variabele van het type `Keys` verwacht. Dit was het type wat beschikbaar is in
de `KeyDown` methodes van het form: gemakshalve wordt deze dus hergebruikt.

Tot slot zijn er een tweetal methodes toegevoegd aan de `Map` klasse. De
tegenstander begint op een willekeurige plek: deze moet natuurlijk niet al op
de speler beginnen of in een muur geplaatst worden. De `freePosition` methode
zorgt er voor dat een vrije positie wordt gekozen. Ook moeten de karakters in
het spel niet door muren heenlopen: hiervoor is het type van een cell benodigd.
Door `cellTypeAtPosition` aan te roepen kan dit achterhaald worden.

