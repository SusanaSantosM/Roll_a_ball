# Roll_a_ball
Juego desarrollado en Unity, con scripts en C#, cuenta con:

- Un jugador (esfera).
- Un enemigo (rectángulo).
- Tres niveles de juego.
- Obstáculos estáticos.
- Pick ups que suman puntos al tomarlos.
- Tres camaras(1ra persona, 3ra persona, mainCamera)

## Descripción del juego:

> El juego consiste en el manejo de una esfera como jugador, 
> tenemos tres niveles en donde el jugador debe tomar todos los puntos amarillos,
> pasando obstaculos, subiendo o bajando y
> escapando del enemigo que lo persigue.
> El jugador luego de capturar los doce puntos, puede pasar de nivel llegando al medio cirulo amarillo.
> Este medio circulo hace que pase al siguiente nivel.

## Desarrollo:
> El juego constará de tres niveles, cada uno de ellos es una escena. 

![image](https://github.com/user-attachments/assets/489fac70-ae7c-4d23-bd74-0be2de2b0754)

### Camara Principal
> La MainCamera o camara principal consta de un script donde se especifica al objeto a seguir, aunque la vista es general para todo el juego,
> llega a moverse ligeramente con el jugador.

### Camara de Primera Persona
> Tiene un script 'FirstCam' y para poder configurar con código el seguimiento del objeto (player) y la rotación de movimiento junto con la rotación del mouse.
> Esto ayuda a que la camara, dentro del jugador, sea estable incluso con el movimiento de la esfera.

### Camara de Tercera Persona
> Tiene un script 'ThirdCameraPerson' donde especificamos el codigo para la tercera camara.
> Esta se encuentra dentro de un objeto que sigue al jugador, el objeto se encuentra a una distancia cercana del jugador para poder guiarse de sus movimientos.

![image](https://github.com/user-attachments/assets/2b997583-447e-47b3-a9f7-22b96b75771a)

### Controlador de camaras
> Para esto tenemos un script 'ChangeCamera' donde podremos controlar la camara con la que queremos jugar.
> Esto se asignara a las teclas 1, 2 y 3.

![image](https://github.com/user-attachments/assets/f1671b3e-e621-4153-ab6d-30805c05d4e0)

### Rampa movil y enemigos
> Aparte de los obstaculos estéticos en el tercer nivel encontramos dos enemigos que perseguiran
> a nuestro jugador. Uno en el primer plano y otro en el segundo.
> También encontramos una plataforma que su dirección es de subir y bajar (estos son dos puntos), conectando ambos planos, para ello tenemos un scrip
> llamado 'Platform'

![image](https://github.com/user-attachments/assets/b6720be9-7b30-4cd8-9945-485bbd28b9ea)

### Cambio de nivel
> Al capturar todos los pick ups, el jugador debe ir hacia el punto de cambio. Este es un medio circulo amarillo, el cual solo se activa cuando el jugador recoge todos los pick ups.
> Este se controla con un trigger en el script 'Player Controller'.

![image](https://github.com/user-attachments/assets/53362856-e709-4007-be9a-4a8efe19aa1b)
