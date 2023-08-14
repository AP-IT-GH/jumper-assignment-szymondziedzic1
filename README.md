# jumper-assignment-szymondziedzic1
jumper-assignment-szymondziedzic1 created by GitHub Classroom
S-nummer: 127865

Jumper

Eerst wat er moet gedaan worden is een training area aanmaken, 
in deze area voeg je een plane toe die dient als de "vloer" van de area. 
Dan voeg je een andere plane toe die dient als een muur.
Dan moet de vorm van de agent toegevegd worden (in mijn geval een kubus).
En ten laatste een obstakel (in mijn geval ook een kubus) waarover de agent moet springen.

Er moeten meerdere scripts worden gemaakt om dit functioneel te maken.

Voor de obstakel heb ik een Obstacle.cs aangemaakt.
Deze script zorgt ervoor dat de obstakel in de richting van de agent gaat.

Er moet een methode komen zodat de obstakel zijn positie reset als die tegen de muur botst.
Deze heb ik WallCollision.cs genoemd met een OnTriggerEnter, deze methode is toegevoegd aan de obstakel.

De volgende script heb ik WallCollisionDetection.cs genoemd met een OnCollisionEnter methode.
Deze script is toegewezen aan de muur, eens de obstakel met de muur botst.
Kan de agent zeker zijn dat die over de obstakel heeft gesprongen en krijgt die zijn beloning.

En ten slotte, de belangrijkste script. CubeAgent.cs
Deze script bevat al de logica van de agent, de script bevat methoden om de agent tot leven te brengen.
Een OnEpisodeBegin die de positie reset en checkt of de agent van de vloer is gevallen.
Een Initialize die de rigidbody initializeert en de positie van de agent en obstacle bewaart, 
zodat deze na het einde van de episode op hun juiste plek komen te staan.
Een CollectObservations methode, dankzij deze methode kan de agent zien hoe ver de obstakel is en op tijd springen.
Een OnActionReceived die de agent toestaat om te kunnen springen.
Een OnCollisionEnter die de tag van de obstakel vergelijkt om te zien of de agent er tegen botste en die de episode eindigt.
En ten slotte een override Heuristic om het zelf te kunnen testen.

