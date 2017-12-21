# LabyFights
OOP Advanced concepts
ESILV S7 1 2017–2018
d Practical Work #8 & more – Problem: Labyrinth fights c
Le but du problème est de programmer le comportement autonome de combattants parachutés
dans un labyrinthe où il faut en sortir vivant le premier. Pour s’aider, les combattants pourront
ramasser des objets plus ou moins offensifs disséminés dans le labyrinthe.
This work is to be done in pairs (or individually) and it will be graded.
The assessment will mainly take into account the quality of your object-oriented
code, a good use of Design Patterns and Threads.
Specifications
1. Le labyrinthe est une entité unique, jouant le rôle d’élément central. Il est de forme
rectangulaire entièrement entouré de murs. Les murs et la sortie sont des cases particulières.
✎ La forme du labyrinthe peut-être chargée depuis un fichier texte (caractère ’0’ libre,
’1’ mur, et ’2’ sortie).
2. Une case qui n’est pas un mur peut être libre ou occupée. Une case occupée peut contenir
soit un seul objet, soit un seul combattant (avec zéro ou plusieurs objets). (∗)
• un mur ne peut donc pas être occupé.
• lorsque la sortie est occupée par un combattant, le programme s’arrête.
3. Les objets sont fournis par un générateur d’objets, agissant comme une fabrique ultrasimple
qui associe une valeur aléatoire de points de dégât que peut causer chaque objet ;
valeur comprise dans l’intervalle [1, 10].
À chaque utilisation, un objet perd un point de dégât.
✎ Il peut même s’agir d’une « mini-fabrique » où la classe elle-même sert de fabrique.
• En début de programme, les objets occupent environ 10% des cases libres et y sont
placés aléatoirement.
4. Les combattants
• Les combattants ont pour objectif de trouver la sortie. Ils se déplacent de manière
autonome. Ça sent pas le thread là ?
• Un combattant dispose au départ de 100 points de vie et d’une capacité de 10 pour
infliger des dégâts.
• Lorsqu’il se déplace sur une case occupée par un objet il le ramasse. Dans ce cas
sa capacité de dégât se voit augmenter d’autant que la valeur associée à l’objet. Un
combattant muni d’un objet reste un combattant ! (∗)
• Un combattant a un caractère soit offensif soit défensif (qui peut éventuellement
changer au cours du temps). Lorsqu’il se trouve à côté d’un autre combattant – i.e.
case juxtaposée non en diagonale – s’il possède un caractère offensif il attaque cet autre
combattant, sinon il cherche à fuir. Là il y a de la stratégie, non ?
ESILV S7 1 2017–2018 — OOP Advanced concepts T. Raimbault — Page 1/2
– En début de programme, les combattants occupent environ 1% des cases libres et
y sont placés aléatoirement.
 Mais comme ça serait bien que leurs caractères soient générés aléatoirement en
début de programme... une petite fabrique serait pas mal là aussi.
• Lorsqu’un combattant est attaqué, il perd autant de points de vie que de dégâts que
peut infliger son adversaire.
Un combattant sans objet ne peut pas attaquer un adversaire (son caractère devrait
être en mode défensif).
• Un combattant mort – i.e. points de vie à zéro – disparaît du labyrinthe. La case où il
se situait devient donc libre. Les objets dont il disposait sont repositionnés de manière
aléatoire dans le labyrinthe (uniquement sur des cases libres).
5. La voix
• À intervalle plus ou moins régulier, « la voix » informe tous les combattants qu’ils
viennent de perdre tous leurs objets ramassés, et que ceux-ci ont été repositionnés de
manière aléatoire dans le labyrinthe (uniquement sur des cases libres).
(∗) Il y a du patron de conception décorateur ici ... à revisiter cependant !
Aide pour le déplacement des combattants
Pour se déplacer dans le labyrinthe, le combattant peut agir comme suit :
• d’abord connaître les cases autour de lui, c’est à dire au Nord, à l’Est, au Sud ou à l’Ouest
de sa position.
• ensuite se déplacer sur une (première) case libre qu’il n’a pas déjà visité ⇒ donc besoin de
mémoriser les positions déjà vues.
 Bien sûr, s’il préfère se battre et qu’il en a l’occasion, il ne se déplace pas.
• s’il est coincé, il reviendra sur ses pas ⇒ donc besoin de “dépiler” le trajet effectué.
• s’il est complètement coincé... réinitialisation des positions visitées et du trajet.
