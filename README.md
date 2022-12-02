# Gridmoire The Fall of Sunhelm #
## Introducción ##
### Concepto del juego ###
Gridmoire: The Fall of Sunhelm es un juego en el que una invocadora ancestral te pide a ti, el jugador, que le ayudes a guiar a sus héroes en la guerra que sacude su reino. Con tu grupo de héroes, deberás utilizar las habilidades de cada uno con cabeza y diseñar una estrategia infalible mientras te enfrentas a cantidad de enemigos. ¡Y qué mejor que hacerlo con guerrillas de 3 contra 3!
### Caracteríticas principales ###
El juego se basa en estas características:

* **Diseño del juego sencillo:** queremos que Gridmoire sea un juego fácil de entender y aprender, por lo que no contendrá mecánicas demasiado complicadas.
* **Estrategia:** El punto más importante de Gridmoire es pensar antes de luchar. Hay que observar qué enemigos hay y mover a tus unidades acorde a lo que se ve.
* **Relajado:** Gridmoire no requiere de atención constante, no hay tiempos. El jugador juega a su ritmo y sin preocupaciones.
* **Toques de humor:** En Gridmoire no buscamos una historia trágica ni un romance imposible. El jugador experimentará varios clichés de los juegos RPG implementados de forma cómica, los cuales servirán de tema para el juego.

### Género ###
Gridmoire entra dentro de las categorías de Role-playing Game (RPG) y estrategia por turnos. En él, el usuario deberá tomar las decisiones y guiar las acciones del grupo de héroes al que comanda para abrirse paso a través del reino de Sunhelm, en batallas regidas por un sistema de turnos en los que deberá atacar al enemigo.

### Mecánicas y jugabilidad ###
Gridmoire ofrece dos sistemas por el cual el jugador conectará con el juego:
* Por un lado está la parte narrativa, en la que el usuario avanzará por la historia siguiendo un formato de novela visual.
* Por otro lado, cuenta con diferentes niveles que muestran un campo de batalla donde el jugador deberá derrotar una serie de enemigos. Este campo de batalla se representa con 2 tableros. Existirá un tablero donde el jugador debe colocar a sus personajes haciendo clic sobre ellos y luego sobre la posición, y los enemigos se dispondrán de manera aleatoria por su propio tablero, informando al jugador únicamente del tipo de enemigo que son y no de dónde están situados. <br>
El jugador tendrá como objetivo avanzar en la trama, además de la obtención y coleccionismo de personajes.

### Plataforma ###
Gridmoire está enfocado al juego en navegador web, en concreto a Google Chrome y Mozilla Firefox, a través de la plataforma de itch.io, de manera que el usuario no necesite descargar ningún archivo para su uso.<br>
Está adaptado tanto para su uso en PC, haciendo uso de ratón, como en móviles, mediante funciones táctiles.


### Estilo visual y cámara ###
El estilo visual general de todo el juego se basa en un estilo 2D manga, tanto personajes como escenarios.<br>
Los usuarios tendrán una vista frontal de todos ellos, tanto en la parte de novela visual como en la de batalla. En la fase de batalla, para que no se solapen los personajes unos encima de otros y con el fin de que se vean todos, se colocarán en distintos niveles de profundidad.

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
* **Niveles:** Los niveles son campos de batalla donde el jugador debe derrotar a los enemigos. Este campo de batalla es un tablero de 3x3 casillas, donde el jugador sitúa a los 3 personajes que elija y los enemigos se situarán aleatoriamente en el tablero contrario. La disposición enemiga no se revelará al jugador hasta que termine de colocar sus unidades, solo se le mostrarán los tipos de ataque que posee el enemigo.<br>
El nivel termina cuando las unidades del jugador son derrotadas o éste consigue derrotar todas las tropas del enemigo. Si el jugador consigue la victoria, se le otorgará experiencia y monedas que podrá usar en la tienda. Si no, se le devolverá a la selección de niveles tras informarle de que ha perdido.


* **Dificultad:** el juego va escalando en dificultad según se superan los niveles, haciéndose cada vez más difíciles los enemigos a través de la IA y sus stats. Al principio los enemigos tendrán más aleatoriedad en sus ataques pero, conforme avances en el juego, esta aleatoriedad irá desapareciendo, haciendo que la IA tome más decisiones óptimas.


* **Progresión del jugador:** los personajes del jugador conseguirán experiencia a medida que complete los niveles. Esto permitirá que los personajes realicen más daño. Además, el jugador conseguirá monedas que permitirán comprar mejores personajes.

* **Habilidades:** las unidades, tanto del jugador como del enemigo, tendrán diferentes tipos de ataque, así como una habilidad para curar. Los ataques pueden ser en fila, en columna, a todo el tablero y en una sola casilla, atacando únicamente al área seleccionada por el jugador siguiendo su patrón. La habilidad de curar se realizará para todas las casillas, y solo tendrá efecto en las unidades aliadas de quien lo ejecute.

* **Enemigos:**  los enemigos serán colocados aleatoriamente en el tablero, mostrando al jugador previamente solo su tipo de ataque, para que así este no pueda colocar sus unidades estratégicamente para que ataquen a todas las unidades enemigas y juegue más bien con esquivar los ataques enemigos, intuyendo cuál podría ser su patrón de ataque.<br>
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
  (Siendo n la suma del número de nivel en el que aparece, más el producto de 10 por el número de capítulo menos 1.
  Por ejemplo, si estamos en el nivel 2-1, n se calcula como: 1(nivel) + (2(capítulo)-1) * 10 = 11)

* **Planificación de la partida:** el jugador cuenta con un inventario de personajes, donde encontrará todos los que haya obtenido, con el nivel que les corresponda y mostrando el tipo de ataque que tiene. En cada partida, el jugador solo podrá usar a tres de esos personajes, colocándolos en su tablero.

### Personajes ###
* **Personaje principal (Jugador):** Será una figura negra, sin género ni atributos físicos, es decir, un maniquí. Representará al jugador, por lo que no tendrá una personalidad demasiado fuerte. Hará bastantes remarques cómicos ya que el jugador es del mundo real y conoce este tipo de juegos, por lo que las situaciones clichés le parecerán algo absurdas. Este personaje no es jugable, por lo que no tendrá características.

* **Personaje Aleatorio Común:** Personaje que saldrá aleatoriamente tras comprar un personaje común en la tienda. Estos podrán tener el patrón de ataque “fila”, “columna” o “mono objetivo”. Tendrán las estadísticas más bajas del juego y su escalado de nivel será peor. Estadísticas: 

    * Puntos de vida: Iniciales 14-25. Escalado de 3-5 puntos por nivel.
    * Ataque: Iniciales 4-5. Escalado de 2-4 puntos por nivel.
    * Defensa: Iniciales 2-4. Escalado de 1-2 puntos por nivel.
    * Valor de invocación: 150 monedas.
    
* **Personaje Aleatorio Raro:** Personaje que saldrá aleatoriamente tras comprar un personaje raro en la tienda. Estos podrán tener el patrón de ataque “fila”, “columna”, “mono objetivo” o “cura”. Tendrán unas estadísticas intermedias, pero superiores a los personajes comunes, con un escalado decente. Estadísticas:

    * Puntos de vida: Iniciales 20-30. Escalado de 5-7 puntos por nivel.
    * Ataque: Iniciales 10-13. Escalado de 3-5 puntos por nivel.
    * Defensa: Iniciales 5-7. Escalado de 2-3 puntos por nivel.
    * Valor de invocación: 500 monedas.
    
* **Personaje Aleatorio Super Raro:** Personaje que saldrá aleatoriamente tras comprar un personaje super raro en la tienda. Estos podrán tener todos los patrones de ataque. Tendrán estadísticas extraordinarias y un escalado alto, convirtiéndose en los personajes más fuertes que pueda obtener el jugador. Estadísticas:

    * Puntos de vida: Iniciales 25-40. Escalado de 6-10 puntos por nivel.
    * Ataque: Iniciales 12-16. Escalado de 5-7 puntos por nivel.
    * Defensa: Iniciales 7-10. Escalado de 3-5 puntos por nivel.
    * Valor: 2500 monedas.


### Controles ###
* Parte novela visual:
   * Pasar los diálogos: tocando la pantalla del dispositivo móvil o haciendo clic

* Parte batalla:
   * Arrastrar los personajes al tablero: Elegir el personaje a usar desde el inventario, tocar/clicar, y luego tocar/clicar la casilla en la que se quiera dejar el personaje. Automáticamente, el personaje se ajustará al centro de la casilla.

   * Seleccionar ataque: Cuando sea el turno del jugador, aparecerán iconos con el busto del personaje y su tipo de ataque. Para usar un ataque en concreto, tocar/clicar el icono correspondiente.

### Guardado de la partida ###
Se realiza un autoguardado del nivel en el que se encuentre el jugador y los personajes que tenga en el momento de la partida para que pueda regresar en otro momento.


## Interfaz ##
### Flujo del juego ###
Al abrir el juego, se presenta el menú principal, de donde el usuario puede ver los créditos, entrar en los ajustes o empezar la partida.

De la pantalla de créditos el usuario puede volver al menú principal. Por otra parte, desde el menú de ajustes se tiene acceso a funciones que permiten modificar diferentes parámetros del juego, así como volver al menú principal.

La última opción es la de entrar en partida, tras lo cual se presentará una introducción y un tutorial para ambientar e instruir al usuario, con opción a saltarse esta parte gracias a un botón de omisión. Tras esta pantalla, se llega a la selección de nivel, donde, no solo se puede seleccionar el nivel que el usuario quiere jugar, sino que también se puede navegar a la tienda y volver al menú principal de nuevo.

Dentro de la tienda, el jugador podrá hacer uso de recursos ganados dentro del juego para poder comprar nuevos personajes que añadir a su repertorio de personajes. Además, como en el resto de pantallas, se puede volver a la pantalla previa.

Por último, al presionar el botón de iniciar nivel, se pasará al usuario a la partida. Comenzando en la fase de planificación, el jugador solo verá su tablero y su repertorio de personajes acompañado de un indicador de cuántos enemigos habrá más adelante y qué patrón de ataque tienen. Deberá colocar 3 de estos personajes a las casillas de su tablero

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
Es la zona inicial. El jugador se enfrentará a los “Perros infernales”, los enemigos más débiles del juego. En estos niveles se sitúa al jugador en la historia, además de servir a modo de práctica para ir aprendiendo las mecánicas del juego.<br>
Vencer en un nivel ofrecerá entre 20 y 70 monedas, dependiendo de cuán avanzado sea el nivel de zona. Es decir, el nivel 1-1 otorgará 20 monedas, mientras que el 1-10 otorgará 70 y el 1-5, 45.
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/mapa_1erCap.png)
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Ciudad.jpg)
* Thelia, el bosque mágico<br>
Segunda zona de nuestro juego. Aquí se incluirá un nuevo tipo de enemigo: “Murciélagos vampiro”. Estos son atraídos por las criaturas mágicas del bosque, por lo que el jugador deberá defender el segundo lugar de ataque de las tropas de Artem. Estos serán un poco más fuertes que los perros infernales.<br>
Vencer en un nivel ofrecerá entre 50 y 100 monedas, dependiendo de cuán avanzado sea el nivel de zona. Es decir, el nivel 2-1 otorgará 50 monedas, mientras que el 2-10 otorgará 100 y el 2-5, 75.
![image](https://github.com/MooncakeStudio/mooncakestudio.github.io/blob/main/GDD/Assets/Bosque.jpg)

* Muddybog, la ciénaga perdida<br>
Tercera zona del juego. La primera parte de la zona, hasta el nivel 3-5, no incluirá ningún tipo de enemigo nuevo. Tras el nivel 3-5, aparecerá el nuevo tipo de enemigo “Goblin”, el cuál empezará a exigir algo más de nivel al jugador, fomentando así la rejugabilidad de niveles anteriores.<br>
Vencer en un nivel ofrecerá entre 75 y 125 monedas, dependiendo de cuán avanzado sea el nivel de zona. Es decir, el nivel 3-1 otorgará 75, mientras que el 3-10 otorgará 125 y el 3-5, 100.

* Semh Hal-a, el pico del norte<br>
Cuarta zona del juego. Dejarán de aparecer los enemigos “Perro Infernal”, por lo que el nivel de dificultad aumentará al quedar solo los enemigos más difíciles hasta el momento. Estos niveles servirán de preparación al jugador para la zona final.<br>
Vencer en un nivel ofrecerá entre 150 y 200 monedas, dependiendo de cuán avanzado sea el nivel de zona. Es decir, el nivel 4-1 otorgará 150, mientras que el 4-10 otorgará 200 y el 4-5, 175.

* Ralx, la tierra maldita y Duskrise Castle, el último bastión oscuro<br>
Quinta zona del juego. Esta se dividirá en dos partes: Ralx y Duskrise Castle. La primera zona, Ralx, consta de 5 niveles donde se encontrarás enemigos de tipo “Goblin” y “Demonio hembra”. Estos servirán de puente con la siguiente zona, Duskrise Castle. Esta consta de otros 5 niveles y un nivel extra. Se encontrarán enemigos de tipo “Goblin”, “Demonio hembra” y “Demonio macho”, siendo la zona con los enemigos más fuertes en el juego. El nivel extra será el nivel del jefe final, donde solo se luchará contra Artem.<br>
Vencer en un nivel ofrecerá entre 200 y 250 monedas, dependiendo de cuán avanzado sea el nivel de zona. Es decir, el nivel 5-1 otorgará 200, mientras que el 5-10 otorgará 250 y el 5-5, 225. El nivel del jefe final no otorga monedas.

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

Efectos sonoros: se crearán efectos para: botones, personajes, ataque arma física, ataque arma a distancia, ataque arma mágica, curación, ataque enemigo, colocar personaje, inicio de batalla, sonido palabras y sonido muerte personaje.



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


### Créditos ###
Please calm my mind, compuesta por Lesfm: https://pixabay.com/music/id-125566/

Arches, compuesta por DSTechnician: https://pixabay.com/music/id-113013/ 

Chapter Two, compuesta por Leonell Cassio: https://pixabay.com/music/id-114909/ 

Motivational Sport Champions Event - Orchestral Epic Award Ceremony, compuesta por SoundGalleryBy: https://pixabay.com/music/id-123489/ 

