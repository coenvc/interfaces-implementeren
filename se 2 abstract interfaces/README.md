# Abstracte klassen en interfaces

De onderwerpen van deze opdracht maken het mogelijk om onze applicatie wat
duidelijker te structuren. Door klassen abstract te maken voorkomen we dat er
een instantie aangemaakt kan worden; interfaces trekken dit nog een stapje
verder door: een interface mag zelfs helemaal geen functionele code bevatten.
Waarom zouden we dit willen? In de opdracht voor dit leerdoel passen we de
applicatie aan zodat een situatie gegeven wordt waarin deze concepten nuttig
zijn.

## De opdracht

Het aanmaken van een `Character` instantie is, als we er even over nadenken,
vrij onlogisch. Een `Player` of `Enemy` is duidelijk een concreet iets, maar
wat is een `Character` nu precies? Het is dus ongewenst om deze klasse te
instantiëren: nu willen we dit ook afdwingen in de code zodat we dit niet per
ongeluk doen. Maak de `Character` klasse `abstract` door dit woord op te nemen
in de klassedefinitie. Probeer nadat je dit gedaan hebt eens even uit van welke
klassen je nu nog wel een instantie aan kunt maken en wanneer dit onmogelijk
geworden is.

### Interfaces

Vervolgens gaan we verder met het toevoegen van items aan het spel. Op een
willekeurige cel in het speelveld zal een item geplaatst worden die, wanneer de
speler er overheen loopt, iets doet met de speler. Denk hierbij aan een health
pack of armor. Ieder `Item` heeft in ieder geval een positie; daarnaast wil je
deze ook van een `Draw` methode voorzien om het item op het scherm te kunnen
tekenen. Kies er zelf voor of je een simpele tekening maakt of hiervoor een
afbeelding gebruikt.

Bepaalde items, zoals bijvoorbeeld het armor, zijn te dragen door de speler.
Dit wordt vastgelegd in de `ICarryable` interface. In deze interface wordt het
gewicht van het item bepaald middels een property: `int Weight { get; }`. De
speler krijgt vervolgens een maximaal gewicht (*strength*) wat hij kan dragen
in zijn inventory, wat een lijst van `Items` zal worden. Er kan alleen een item
opgepakt worden als het niet zwaarder is dan wat de speler kan tillen.

Bedenk zelf nog een paar leuke items, en maak het inventory systeem werkend.

## Inleveren

Ben je zover gekomen als je kon? Lever dan bij de assignment op Canvas de link
in naar je GitLab-project. Geef als toelichting aan wat er goed ging of waar je
juist niet uit kwam zodat de docent zo gericht mogelijk feedback kan geven.

