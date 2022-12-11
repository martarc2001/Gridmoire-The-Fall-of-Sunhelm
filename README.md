# Gridmoire The Fall of Sunhelm #
## Introducción ##
### Concepto del juego ###
Gridmoire: The Fall of Sunhelm es un juego en el que una invocadora ancestral te invoca a ti, el jugador, para que le ayudes a guiar a sus héroes en la guerra que sacude su reino. Con este grupo de héroes, deberás utilizar las habilidades de cada uno con cabeza y diseñar una estrategia infalible mientras te enfrentas a cantidad de enemigos. ¡Y qué mejor que hacerlo con guerrillas de hasta 4 unidades!
### Caracteríticas principales ###
El juego se basa en estas características:

* **Diseño del juego sencillo:** queremos que Gridmoire sea un juego fácil de entender y aprender, por lo que no contendrá mecánicas demasiado complicadas.
* **Estrategia:** El punto más importante de Gridmoire es pensar antes de luchar. Hay que observar qué enemigos hay y mover a tus unidades acorde a lo que se ve.
* **Relajado:** Gridmoire no requiere de atención constante, no hay tiempos. El jugador juega a su ritmo y sin preocupaciones.
* **Toques de humor:** En Gridmoire no buscamos una historia trágica ni un romance imposible. El jugador experimentará una historia sin mucha carga emocional unida a diversas bromas y chascarrillos para aliviar dicha carga aún más.

### Género ###
Gridmoire entra dentro de las categorías de Role-playing Game (RPG) y estrategia por turnos. En él, el usuario deberá tomar las decisiones y guiar las acciones del grupo de héroes al que comanda para abrirse paso a través del reino de Sunhelm, en batallas regidas por un sistema de turnos en los que deberá derrotar al enemigo.

### Mecánicas y jugabilidad ###
Gridmoire ofrece dos sistemas por el cual el jugador conectará con el juego:
* Por un lado está la parte narrativa, en la que el usuario avanzará por la historia siguiendo un formato de novela visual.
* Por otro lado, cuenta con diferentes niveles que muestran un campo de batalla donde el jugador deberá derrotar una serie de enemigos. Este campo de batalla se representa con 2 tableros. Existirá un tablero donde el jugador debe colocar a sus personajes haciendo clic sobre ellos y luego sobre la posición, y los enemigos se dispondrán de manera aleatoria por su propio tablero, informando al jugador únicamente del tipo de enemigo que son y no de dónde están situados. <br>
El jugador tendrá como objetivo avanzar en la trama, además de la obtención y coleccionismo de personajes.

### Plataforma ###
Gridmoire se ha desarrollado para jugar en navegador web, en concreto a Google Chrome y Mozilla Firefox, a través de la plataforma de itch.io, de manera que el usuario no necesite descargar ningún archivo para su uso.
Está adaptado tanto para su uso en PC, haciendo uso de ratón, como en móviles, mediante funciones táctiles.

### Estilo visual y cámara ###
El estilo visual general de todo el juego se basa en un estilo 2D manga, tanto personajes como escenarios.<br>
Los usuarios tendrán una vista 3/4 de todos ellos, tanto en la parte de novela visual como en la de batalla. En la fase de batalla, para que no se solapen los personajes unos encima de otros y con el fin de que se vean todos, se colocarán en distintos niveles de profundidad.

### Propósito y público objetivo ###
Gridmoire está enfocado a un público joven, no necesariamente experimentado en videojuegos, con humor y que disfrute de pasar tiempo en internet. Más específicamente, se dirige a esos usuarios que busquen un juego rápido de jugar y para desconectar, es decir, que no requiera de toda su atención.

### Tecnologías empleadas ###
El juego está desarrollado en Unity-C#, y los assets están desarrollados en distintos softwares:
* Assets visuales (Personajes, iconos, menús) desarrollados en Clip Studio Paint
* Assets de animación (Logo) desarrollados en Clip Studio Paint y Adobe Animate
* Assets de sonidos (música, efectos de sonido) desarrollados en LMMS y Audacity




## Mecánicas del juego ##
En este apartado se hablará de los aspectos asociados a la fase de batalla. Para la parte de novela visual, consultar el apartado de Narrativa.

### Jugabilidad ###
* **Niveles:** Los niveles son campos de batalla donde el jugador debe derrotar a los enemigos. Este campo de batalla es un tablero de 3x3 casillas, donde el jugador sitúa a los personajes que elija, de 1 a 4, y los enemigos se situarán aleatoriamente en el tablero contrario. Además, los niveles tendrán casillas desactivadas para el jugador para añadirle un nivel más de dificultad, teniendo que jugar alrededor de estos handicaps. La disposición enemiga no se revelará al jugador hasta que termine de colocar sus unidades, solo se le mostrarán los tipos de ataque que posee el enemigo en la pantalla de selección.<br>
El nivel termina cuando las unidades del jugador son derrotadas o éste consigue derrotar todas las tropas del enemigo. Si el jugador consigue la victoria, se le otorgará experiencia y monedas que podrá usar en la tienda. Si no, se le devolverá a la selección de niveles tras informarle de que ha perdido.


* **Dificultad:** el juego va escalando en dificultad según se superan los niveles, haciéndose cada vez más difíciles los enemigos a través de sus stats. Al principio los enemigos tendrán poco stats, facilitando su derrota, pero estos aumentarán cuando el jugador progrese en el juego.


* **Progresión del jugador:** los personajes del jugador conseguirán experiencia a medida que complete los niveles. Esto permitirá que los personajes realicen más daño. Además, el jugador conseguirá monedas que permitirán comprar más personajes.

* **Habilidades:** las unidades, tanto del jugador como del enemigo, tendrán diferentes tipos de ataque, así como una habilidad para curar. Los ataques pueden ser en fila, en columna, a todo el tablero y en una sola casilla, atacando únicamente al área seleccionada por el jugador siguiendo su patrón. La habilidad de curar se realizará para una sola casilla y para una unidad aliada.

* **Enemigos:**  los enemigos serán colocados aleatoriamente en el tablero, para que así este no pueda colocar sus unidades estratégicamente para que ataquen a todas las unidades enemigas y juegue más bien con esquivar los ataques enemigos, intuyendo cuál podría ser su patrón de ataque.<br>
Los enemigos que encontrará el jugador durante su partida, dependiendo del nivel en el que se encuentre, así como sus estadísticas, serán:
   * Perro infernal
      * HP: Entre 5+n y 15+n
      * Ataque: Entre 2+n y 7+n
      * Defensa: Entre 1+n y 6+n
      <br>
   *  Murciélago vampiro
      * HP: Entre 5+n y 20+n
      * Ataque: Entre 3+n y 9+n
      * Defensa: Entre 2+n y 6+n
      <br>
   *  Goblin
      * HP: Entre 10+n y 25+n
      * Ataque: Entre 5+n y 10+n
      * Defensa: Entre 4+n y 8+n
      <br>
   *  Demonio hembra
      * HP: Entre 15+n y 30+n
      * Ataque: Entre 12+n y 20+n
      * Defensa: Entre 8+n y 18+n
      <br>
   *  Demonio macho
      * HP: Entre 15+n y 30+n
      * Ataque: Entre 10+n y 18+n
      * Defensa: Entre 10+n y 20+n
      <br>
   *  Artem (Jefe final)
   <br>
   
  (Siendo n=(nivel^2)/(6-(estadística base/15)) si n>1 ó n=1 si n<1;
  siendo nivel la suma del número de nivel en el que aparece, más el producto de 10 por el número de capítulo menos 1.

* **Planificación de la partida:** el jugador cuenta con un inventario de personajes, donde encontrará todos los que haya obtenido, con el nivel que les corresponda y mostrando el tipo de ataque que tiene. En cada partida, el jugador solo podrá usar hasta 4 de esos personajes, colocándolos en su tablero.

### Personajes ###
* **Personaje Aleatorio Común:** Personaje que saldrá aleatoriamente tras comprar un personaje común en la tienda. Tendrán las estadísticas más bajas del juego y su escalado de nivel será peor.  Estadísticas: 

    * Puntos de vida: Iniciales 14-25. Escalado de 3-5 puntos por nivel.
    * Ataque: Iniciales 4-5. Escalado de 2-4 puntos por nivel.
    * Defensa: Iniciales 2-4. Escalado de 1-2 puntos por nivel.
    * Valor de invocación: 150 monedas.
    
* **Personaje Aleatorio Raro:** Personaje que saldrá aleatoriamente tras comprar un personaje raro en la tienda. Tendrán unas estadísticas intermedias pero superiores a los personajes comunes, con un escalado decente.
Estadísticas:

    * Puntos de vida: Iniciales 20-30. Escalado de 5-7 puntos por nivel.
    * Ataque: Iniciales 10-13. Escalado de 3-5 puntos por nivel.
    * Defensa: Iniciales 5-7. Escalado de 2-3 puntos por nivel.
    * Valor de invocación: 500 monedas.
    
* **Personaje Aleatorio Super Raro:** Personaje que saldrá aleatoriamente tras comprar un personaje super raro en la tienda. Tendrán estadísticas extraordinarias y un escalado alto, convirtiéndose en los personajes más fuertes que pueda obtener el jugador.
Estadísticas:

    * Puntos de vida: Iniciales 25-40. Escalado de 6-10 puntos por nivel.
    * Ataque: Iniciales 12-16. Escalado de 5-7 puntos por nivel.
    * Defensa: Iniciales 7-10. Escalado de 3-5 puntos por nivel.
    * Valor: 2500 monedas.

-Siendo n=(nivel^2)/(6-(estadística base/15)) si n>1 ó n=1 si n<1-

### Controles ###
* Parte novela visual:
   * Pasar los diálogos: tocando la pantalla del dispositivo móvil o haciendo clic

* Parte batalla:
   * Colocar los personajes en el tablero: Elegir el personaje a usar desde el inventario, tocar/clicar, y luego tocar/clicar la casilla en la que se quiera dejar el personaje. Automáticamente, el personaje se ajustará al centro de la casilla.

   * Seleccionar ataque: Cuando sea el turno del jugador, aparecerán iconos con el busto del personaje y su tipo de ataque. Para usar un ataque en concreto, tocar/clicar el personaje correspondiente en el tablero y luego la casilla deseada.

### Guardado de la partida ###
Se realiza un autoguardado del nivel en el que se encuentre el jugador y los personajes que tenga en el momento de la partida para que pueda regresar en otro momento. No es necesaria ninguna acción por parte del jugador.


## Interfaz ##
### Flujo del juego ###
Al abrir el juego, se presenta el menú principal, de donde el usuario puede ver los créditos, entrar en los ajustes, empezar la partida o ver el tutorial.

De la pantalla de créditos el usuario puede volver al menú principal. Por otra parte, desde el menú de ajustes se tiene acceso a funciones que permiten modificar diferentes parámetros del juego, así como volver al menú principal.

La última opción es la de entrar en partida, tras lo cual se presentará la introducción de la historia al usuario, apareciendo este fragmento de historia solo la primera vez que se juegue. Tras esta pantalla, se llega a la selección de nivel, donde, no solo se puede seleccionar el nivel que el usuario quiere jugar, sino que también se puede navegar a la tienda, las opciones y volver al menú principal de nuevo.

Dentro de la tienda, el jugador podrá hacer uso de recursos ganados dentro del juego para poder comprar nuevos personajes que añadir a su repertorio de personajes. Además, como en el resto de pantallas, se puede volver a la pantalla previa.

Por último, al presionar el botón de iniciar nivel, se pasará al usuario a la partida o a un fragmento de la historia, que llevará después a la partida. Comenzando en la fase de planificación, el jugador solo verá su tablero y su repertorio de personajes dividido por sus diferentes rarezas. Deberá colocar como máximo 4 de estos personajes a las casillas de su tablero

Tras esto, el jugador pulsará un botón para confirmar su elección y pasará a una nueva escena donde podrá ver tanto su tablero como el enemigo. En esta fase, el usuario escogerá un personaje y realizará una acción que se llevará a cabo. Repetirá esto hasta que hayan jugado una vez todos sus personajes. Al terminar su fase de ataque, se iniciará la fase de espera, en la que el usuario esperará a que el enemigo realice lo mismo con sus propios personajes. 

Finalmente, se repite este ciclo hasta que uno de los dos haya derrotado a todos sus contrincantes.

Para terminar, dentro de la partida se podrá acceder a un menú de pausa, en el que no solo se tendrán de nuevo los ajustes sino que también se podrá salir del nivel para volver al menú de selección de nivel.

### Diagrama de flujo ###
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Flujo.png)


### Mock-ups ###
* Menú principal
   * Invoca: Créditos, , Empezar partida, Selección de nivel, Ajustes [base]
   * Invocable por: Créditos, Selección de nivel
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Inicio.jpg)
* Créditos
   * Invoca: Menú principal
   * Invocable por: Menú principal
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Cr%C3%A9ditos.jpg)
* Ajustes [base]
   * Invoca: Menú principal, Selección de nivel, Tienda
   * Invocable por: Menú principal, Selección de nivel, Tienda
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Ajustes%201.jpg) 
* Ajustes [con botón de abandono de partida]
   * Invoca: Nivel, Selección de nivel
   * Invocable por: Nivel
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Ajustes%202.jpg)
* Selección de nivel
   * Invoca: Nivel, Ajustes [base], Menú principal, Tienda
   * Invocable por: Nivel, Ajustes [base], Menú principal, Tienda
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Selector%20nivel.jpg)
* Nivel
   * Invoca: Ajustes [con botón de abandono de partida], Selección de nivel
   * Invocable por: Selección de nivel, Ajustes [con botón de abandono de partida]
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Planificaci%C3%B3n.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Partida.jpg)
* Tienda
   * Invoca: Ajustes [base], Selección de nivel
   * Invocable por: Selección de nivel
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Mock-ups/Tienda.jpg)

## NIVELES ##
El juego se dividirá en 5 zonas inicialmente que, a su vez, están divididas en 10 niveles.
* Cantermahl, capital de Sunhelm<br>
Es la zona inicial. El jugador se enfrentará a los “Perros infernales”, los enemigos más débiles del juego, y en los últimos niveles también a los “Murciélagos vampiros”. En estos niveles se sitúa al jugador en la historia, además de servir a modo de práctica para ir aprendiendo las mecánicas del juego.
<br>
Vencer en un nivel ofrecerá entre 50 y 140 monedas, dependiendo de cuán avanzado sea el nivel de zona. Además, también recompensará con experiencia a cada personaje con valores entre 80 y 430, dependiendo del nivel.

![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/mapa_1erCap.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Ciudad.jpg)
* Thelia, el bosque mágico<br>
Segunda zona de nuestro juego. En esta zona, el enemigo principal serán “Murciélagos vampiros”, pero también aparecerán “Perros infernales”. en los niveles finales, también aparecerá algún “Goblin” que otro. Estos son atraídos por las criaturas mágicas del bosque, por lo que el jugador deberá defender el segundo lugar de ataque de las tropas de Artem.
<br>
Vencer en un nivel ofrecerá entre 150 y 240 monedas, dependiendo de cuán avanzado sea el nivel de zona. Además, también recompensará con experiencia a cada personaje con valores entre 470 y 920, dependiendo del nivel.

![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Bosque.jpg)

* Muddybog, la ciénaga perdida<br>
Tercera zona del juego. Aparecerá con más frecuencia el nuevo tipo de enemigo “Goblin”, el cuál empezará a exigir algo más de nivel al jugador, fomentando así la rejugabilidad de niveles anteriores. Además de incluir un “Demonio F” en el último nivel, el enemigo más fuerte que verá el jugador hasta dicho momento.
<br>
Vencer en un nivel ofrecerá entre 250 y 340 monedas, dependiendo de cuán avanzado sea el nivel de zona. Además, también recompensará con experiencia a cada personaje con valores entre 960 y 1540, dependiendo del nivel.


* Semh Hal-a, el pico del norte<br>
Cuarta zona del juego. Dejarán de aparecer los enemigos “Perro Infernal”, por lo que el nivel de dificultad aumentará al quedar solo los enemigos más difíciles hasta el momento. Estos niveles servirán de preparación al jugador para la zona final.

* Ralx, la tierra maldita y Duskrise Castle, el último bastión oscuro<br>
Quinta zona del juego. Esta se dividirá en dos partes: Ralx y Duskrise Castle. La primera zona, Ralx, consta de 5 niveles donde se encontrarás enemigos de tipo “Goblin” y “Demonio hembra”. Estos servirán de puente con la siguiente zona, Duskrise Castle. Esta consta de otros 5 niveles y un nivel extra. Se encontrarán enemigos de tipo “Goblin”, “Demonio hembra” y “Demonio macho”, siendo la zona con los enemigos más fuertes en el juego. El nivel extra será el nivel del jefe final, donde solo se luchará contra Artem.

## NARRATIVA ##
### Sinopsis ###
El reino de Sunhelm está a punto de ser destruído. Artem, genio del mal, ha unido a los clanes maléficos más fuertes para destruir a todo el reino. Raley, viendo esto, decide usar sus poderes para traer a un ser de otro mundo (el jugador) para comandar a un ejército de héroes en su lugar, ya que ella prefiere quedarse al margen de la vanguardia. A cambio, ella le ofrece inmensas riquezas con las nunca podría ni soñar. 

El jugador, como buen protagonista de RPG, acepta esta misión, sabiendo que los protagonistas de este tipo de historias siempre salen victoriosos. Desafortunadamente, los héroes que le ofrecen son un poco...novatos. Por lo tanto, se ve en la necesidad de guiarlos activamente hacia la victoria, diciéndoles todo lo que deben hacer en batalla.

Artem se da cuenta del plan de Railey así que, siguiendo su rol de villano, decide atacar directamente la capital del reino para crear la máxima destrucción posible. De aquí en adelante, el jugador defenderá el reino batalla a batalla, reclutando nuevos héroes por el camino y avanzando lentamente hacia Duskrise Castle, donde se esconde Artem, genio del mal, villano entre villano, mago negro azabache, el terror de la noche, el jefe final…..el michi más adorab- 
*No puede leerse más allá de este punto, parece que alguien arrancó este trozo de la página*


### Personajes ###
Este apartado abarca los personajes asociados a la parte de novela visual. Para ver los personajes generados en la fase de batalla, consultar el apartado en Mecánicas de juego

* **Invocadora "Raley":** La invocadora es el personaje con el que más interactúa el usuario, y aparece nada más empezar la partida.

Raley es una criatura cuya parte superior es de mujer humana, pero tiene piernas de cierva, y rasgos faciales acordes, visibles sobre todo en la nariz y en las orejas. Lleva un traje morado inspirado en un hanbok, y un corte de pelo Hime recogido en 2 coletas con trenzas y flores, siguiendo una paleta de color acorde a su vestimenta.

A pesar de que pueda parecer delicada, es muy fuerte y puede superar a prácticamente cualquier enemigo. Es una mujer solitaria, inteligente y algo misteriosa, y a menudo habla en acertijos difíciles de entender, que aclara en cuanto ve los rostros de los que la escuchan. Le encanta hacer juegos de palabras y gastarle bromas a la gente para su propia diversión.
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Raley.png)

* **Personaje "Jugador":** Será una figura negra, sin género ni atributos físicos, es decir, una silueta rellena. Representará al jugador, por lo que no tendrá una personalidad demasiado marcada. Hará bastantes remarques cómicos, ya que el jugador es del mundo real y conoce este tipo de juegos, por lo que las situaciones clichés le parecerán algo absurdas. Este personaje no es jugable, por lo que no tendrá características.

* **Personaje "Artem":** Artem es un antiguo residente de la capital del reino de Sunhelm. Huérfano a temprana edad, tuvo que sobrevivir de cualquier manera al hambre y la pobreza. Siendo testigo de la idolatría que se proporcionaba a esos héroes que solo salvan a quienes ellos querían, Artem decidió hacer todo lo posible por destronarlos y demostrarles lo egocéntricos que estaban siendo. Por ello, Artem se inició en las artes oscuras, aliándose con toda clase de canallas y alimañas para obtener poder. A una muy temprana edad, consiguió tener a la mayoría de clanes malvados a su disposición y, sin demora alguna, atacar sin piedad a toda Sunhelm. 

Perteneciente a la raza Grittys, provenientes del este de Sunhelm con ciertas características felinas, como las orejas y la cola, y también con habilidades parecidas, como mucha agilidad y flexibilidad. Adepto por naturaleza a la magia, es capaz de invocar seres sin parar. 

No tiene mucha inteligencia emocional, ya que nunca ha llegado a tener algún amigo. Por ello es incapaz de entender las bromas o la ironía, de ahí que Raley le ponga especialmente de los nervios. 
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Artem.png)

## ARTE ##
### Visual ###
#### Estilo ####
El estilo visual se va a dividir en 2 partes:
* Durante las partes de historia, se presenta a los personajes y escenarios en estilo manga 2D, con proporciones cercanas a las reales, pero estilizado. Estos momentos serán mostrados al jugador como una novela visual, donde se muestran renders de los personajes sobre un plano del escenario, con un cuadro de texto para los diálogos.

* En las partes de gameplay se usarán personajes chibi (personajes con 2.5 cabezas), conservando un estilo de dibujo similar al de las partes narrativas. 

#### Assets: del diseño conceptual al diseño final ####
* Logo del juego
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Boceto%20logo.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Logo%20final.png)
* Raley (invocadora)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Fase%201%20-%20Primer%20esbozo.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Fase%202%20-%20Elecci%C3%B3n%20ropa.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Fase%203%20-%20Elecci%C3%B3n%20paleta%20de%20color.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Raley.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Raley0.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Raley1.png)
* Casillas<br>
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/casilla.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/casilla2.png)
* Chibis<br>
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/1.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/2.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/3.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/4.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/12.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/12%20(2).jpg)
* Bosque
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/boceto%20bosque.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Bosque.jpg)
* Artem (villano)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Concept%20Artem.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Artem.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Artem0.png)
* Armas<br>
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/CONCEPTarmas.jpg)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/armas.jpg)
*Enemigos
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Murciélago.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Perro.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Goblin.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/DemonioF.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/DemonioM.png)

### Audio ###
Se buscarán 2 temas completos: uno para la tienda y los menús y otro para la batalla. Se querrá que estos reflejen temas similares a juegos de aventura y fantasía, típicos de un juego del género RPG.

Además, se creará un tema de victoria y otro de derrota, aunque serán de corta duración.

Efectos sonoros: se crearán efectos para: botones, ataque, curación,  colocar personaje, inicio de batalla y sonido muerte personaje.


## Producción ##
### Miembros del equipo de desarrollo ###
* **Javier Picado Hijón:** Scrum Master, Líder de Narrativa, Líder de Música y Efectos sonoros
* **Pablo Álvarez de Lara:** Líder de UI
* **Daniel Mayoral Fernández-Baíllo:** Líder de Programación e IA
* **Marta Rodríguez Castillo:** Líder de Arte Visual y Líder de RRSS

### Fechas e hitos ###
**Fecha de inicio del proyecto:** 20 de septiembre de 2022

**Hitos:**
* 30 de octubre de 2022: Entrega Alpha
* 20 de noviembre de 2022: Entrega Beta
* 27 de noviembre de 2022: Pitch (Beta)
* 11 de diciembre de 2022: Entrega Goldmaster
* 18 de diciembre de 2022: RRSS, Portfolio y Pitch (Goldmaster)

**Modelo de Negocio**
La forma de monetización del videojuego será por medio de un sistema ‘Pay What You Want’ a través de Itch.io, pero dentro del juego también se ofrecerá la opción de la compra de monedas para comprar personajes.

Nuestro usuario objetivo principal será un jugador casual de 16-25 años, pero que pase bastante tiempo en internet y disfrute del humor y los memes.

También queremos crear una comunidad en RRSS, con la que podamos recibir feedback, tanto de bugs como de futuras actualizaciones, una vez lanzado el juego. Crear una comunidad fuerte con la que interactuemos constantemente, realicemos giveaways y concursos… también nos beneficiará a la hora de publicitarnos más fácilmente y que más gente acceda a nuestro producto.


### Mapa de empatía ###
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Produccion/empatia.png)
### Toolkit ###
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Produccion/toolkit.png)
### Business Model Canvas ###
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Produccion/LBMC.png)

### Plan de Marketing ###
Nuestra visión para la promoción del juego está dividida en dos fases:
La primera se basa en las semanas próximas a la versión Goldmaster del juego. El equipo comunicará diariamente el progreso o los diversos cambios que se van produciendo en el juego para provocar un aumento de la expectación en los usuarios que ya nos sigan. Además, se harán uso de hashtags relevantes al diseño de videojuegos, día de la semana, o género del juego para que usuarios nuevos puedan encontrar a Mooncake Studio y ver el producto. Además, se crearán varios vídeos de gameplays sobre el juego, que serán subidos a la plataforma de youtube, junto a algún directo dentro de la plataforma de twitch una vez el juego ya haya sido subido.
<br>
La segunda fase está pensada para la promoción en 2 años. Se quieren crear eventos estacionales que añadan nuevos objetos y armas, nuevos niveles, ampliar la historia y añadir elementos de QoL. Esto hará que el juego mantenga relevancia y que se pueda crear una mayor comunidad en redes. Esperamos alcanzar un número aproximado de 200 seguidores tanto en Twitter como en Instagram, y tener al menos un mínimo de 30 jugadores mensuales en el juego. 
<br>
En conclusión, este proyecto no está pensado para ganar dinero, sino para darnos a conocer, promocionarnos, y poder crear un proyecto mayor con el que sí se pueda ganar dinero. De este modo, aprendemos de los errores cometidos ahora y el siguiente proyecto será bastante más rentable.

### Post-Mortem ###
Análisis individual<br>
Arte 1:<br>
La persona encargada de arte ha destacado como parte positiva que los personajes chibi y enemigos han sido hechos bastante más rápido de lo esperado. 
<br>
Sin embargo, como parte a mejorar, se ha mencionado:<br>
El uso de Trello: Ya que todo el proyecto está estructurado por Historias de Usuario, si principalmente hay una sola persona con los dibujos (pese a haber ayudantes), lo óptimo sería hacer un tablero a parte con todo lo de arte y no tener las tareas como una checklist dentro de cada historia de usuario. Es mejor tenerlo todo como fichas separadas, a fin de ver el volumen de trabajo con mejor claridad, aunque se pueda seguir consultando las Historias artísticas en el tablero principal.<br>
Detallismo: Hay que recordar que aunque se metan detalles en cada dibujo, si son muy pequeños es mejor no meterlos. No se van a ver en las pantallas, ni de PC ni de dispositivos móviles: es mejor emplear ese tiempo en otra actividad.<br>
Uso de referencias: Sobre todo de cara a hacer los escenarios, ver cómo se distribuyen los elementos de escenarios similares en videojuegos de la misma clase, en vez de embarcarse en el programa de dibujo con el concepto en mente y hacer bocetos. Hacer esto debería dar más velocidad al proceso de dibujo de todos los escenarios.<br>
Consultar más frecuentemente el GDD: Aunque se esté presente en la daily, se es más consciente del proyecto globalmente si se lee el GDD de vez en cuando y no solo cuando hay dudas puntuales.
<br>
Arte 2:
La segunda persona encargada de arte quiere destacar que su rendimiento en la fase final de la beta ha estado a la altura con lo exigido, habiendo sido capaz de sacar todo lo que había planteado a tiempo para su implementación.<br>
Como apartados negativos, se quiere mencionar el ritmo de trabajo inicial, el cual no permitió llegar a las fechas de entrega establecidas con todos los assets que se querían crear. Además, el tiempo invertido en el trabajo ha sido bastante variable, por lo que había días sin ningún avance mientras que en otros había demasiado. Por parte de este integrante, se ha mencionado que debería tener un ritmo de trabajo más estable e intentar separar lo emocional y personal a un lado y no dejar que afecte al ritmo de trabajo.<br>

RRSS 1:<br>
La persona encargada de redes sociales ha destacado que hay que mejorar la comunicación con el equipo de programación para poder subir cosas a redes: Se necesita, ya no solo la daily, sino capturas de pantalla o vídeos del proceso de desarrollo, no solo el producto final, por lo que hay que pedirlas activamente al grupo encargado de ello. Hay que subir contenido regular para poder atraer a más seguidores potenciales del proyecto.<br>


Portfolio, RRSS 2 e itch.io:<br>
La persona encargada del portfolio y también de redes sociales está muy contenta con el trabajo. Comenta que trabajar en el portfolio fue rápido y dio buenos resultados, mientras que los post realizados en redes sociales a su cargo tuvieron buena repercusión, además de traer bastantes visitas en Itch.io. Aún así, destacó que debería haber creado algún changelog dentro de la página de itch.io para informar a posibles jugadores o viewers de que el juego estaba evolucionando.<br>

Programación 1:<br>
La persona encargada de programación ha destacado como parte positiva de su actuación la adaptabilidad que ha demostrado, pudiéndose ajustar rápidamente a partes del juego y del código no desarrolladas por él mismo, lo que ha permitido llevar un flujo de trabajo más adaptable a las necesidades del trabajo. También destaca como positivo La persistencia y el proceso de investigación que ha llevado sobre los aspectos de los que se encargaba en el desarrollo del juego, aunque no siempre condujeran a una solución y se tuviese que cambiar la forma de implementar algunos aspectos.<br>
Por otro lado, ha mencionado como parte negativa de su trabajo el haber dudado y tardado demasiado en pedir ayuda en los casos en los que lo necesitaba, resultando en un gasto de tiempo más grande del necesario. En cuanto a los recursos de software como Trello y Github, recuerda negativamente la mala gestión que ha hecho del Trello, lo que entorpece la creación de documentos y la visibilidad de su trabajo para los demás, además de la inclusión de código en Github en bloques muy grandes, debiendo dividirlos más (commits más pequeños). Finalmente, también destaca como negativa su actuación a la hora de encontrar fallos, dedicando demasiado tiempo a intentar seguir investigando esos fallos en lugar de intentar pensar en otras posibles soluciones para las implementaciones.<br>

Programación 2:<br>
La persona encargada de programación destaca la velocidad en la resolución de problemas, acortando el tiempo en ciertos aspectos del desarrollo. La mejora en el uso de GitHub es un aspecto positivo, pues ha pasado de hacer grandes inclusiones y de forma poco explicativa a pequeños commits con descripción más concisas.<br>
El lado negativo ha sido la falta de trabajo en equipo, el querer abarcar mucho a pesar de no poder con ello, afectándole personalmente y a su rendimiento, provocando errores que han tenido que corregir el equipo más tarde. Otro aspecto que destacar es el uso prácticamente nulo del Trello, haciendo más difícil el seguimiento por parte de los compañeros del trabajo ya realizado, así como del control de lo que queda por realizar. <br>

Sonido:<br>
La persona encargada de sonido ha querido destacar que apenas pudo trabajar en su parte por estar al tanto de otras ramas del proyecto. Esto ha hecho que elementos de creación propia planeados en las primeras fases de desarrollo hayan sido tomadas de repositorios libres para su uso comercial, en lugar de haber podido tener elementos más personalizados. Por ello, destaca que debería centrarse en su parte en vez de salirse de su camino para echar un cable cuando se necesita, o, al menos, no dedicarle tanto tiempo a ello.<br>

Análisis grupal<br>
Tras haber realizado un análisis individual sobre las fortalezas, debilidades y soluciones propuestas de mejora de cada uno de los miembros del equipo, se han puesto en común todas las ideas y se han transformado para ser explicados de manera grupal:<br>

Para comenzar, algo bastante comentado es que, hasta ahora, el tablero Trello grupal al final no lo gestiona ni el Scrum Master ni el grupo en general durante las dailies, y se actualiza, no cuando se termina cada cosa, sino un día aleatorio que nos acordamos. Esto hace que haya muchísima menos organización, salga el videojuego como se esperaba o no. Se debería dejar plasmado todo lo mencionado en cada daily.<br>

El volumen de trabajo de algunos miembros del equipo ha sido mayor del que podían abarcar y soportar, por lo que debería haber un mejor reparto de las tareas. También, si se ha hecho una mala gestión en el reparto de tareas y el grupo observa que un miembro no puede con el trabajo, sería conveniente hacer una reunión para reasignarlas.<br>

Además, a menudo los miembros del equipo que se quedaban atascados con sus tareas se cuestionaban si pedir ayuda o no, en lugar de pedirla directamente. Esto resultaba en un gasto de tiempo innecesario que acababa por retrasar el estado del juego. Debido a esto, hemos decidido que, ya que contamos con un equipo con muy buena relación entre sus integrantes, el máximo de tiempo para pedir ayuda será de un día. Si pasado ese tiempo, el integrante del equipo sigue atascado deberá pedir ayuda a todo el grupo, en especial a sus compañeros de área. Esto hace que los bloqueos puedan resolverse antes y más eficientemente, así como quitarle presión al integrante que se quede atascado.<br>

También, los distintos miembros del equipo deberán estar atentos y tener una comunicación más constante con el resto para poder averiguar si alguien se encuentra atascado y así poder ofrecerle ayuda.<br>

Muchas veces los miembros del equipo tenían dudas de aspectos ya tratados en común y dejados por escrito en el documento de diseño del juego. Por ello, nos hemos dado cuenta de que antes de ponernos a trabajar en código o assets de una parte del juego, sería conveniente revisar lo que se ha acordado en el GDD para evitar confusiones o errores. Además, deberíamos actualizarlo más a menudo, tal y como se ha explicado en el apartado del tablero Trello.<br>

Entre los miembros encargados de programación y los encargados de arte, debería haber una comunicación más fluida y contínua. Deberíamos tener un flujo de trabajo acotado de principio a fin de la fase aproximado, en base al volumen de trabajo que decidamos abarcar. Así, solucionaremos problemas en los que ambos grupos están trabajando en cosas totalmente diferentes siguiendo su propio orden, en vez de ir de la mano por tareas, consiguiendo así que vayamos más rápido en general.<br>

También, se deberían coordinar mejor todas las partes con el fin de subir contenido a redes sociales. Tanto la parte de programación grabando el proceso de desarrollo del videojuego para subir highlights, como la parte de arte creando edits con los sprites y assets para subir como imagen o vídeo, y los encargados de redes pidiendo todo ese contenido regularmente.<br>


### Créditos ###
Please calm my mind, compuesta por Lesfm: https://pixabay.com/music/id-125566/

Arches, compuesta por DSTechnician: https://pixabay.com/music/id-113013/ 

Chapter Two, compuesta por Leonell Cassio: https://pixabay.com/music/id-114909/ 

Motivational Sport Champions Event - Orchestral Epic Award Ceremony, compuesta por SoundGalleryBy: https://pixabay.com/music/id-123489/

Cash Register Fake, creado por CapsLok: https://pixabay.com/es/sound-effects/cash-register-fake-88639/ 

Banco de sonidos de Mixkit: https://mixkit.co/free-sound-effects/ 

