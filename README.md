# Alien Jetpack

Juego endless runner estilo Jetpack Joyride, hecho en Unity para mejorar mi programación.

![gameplay](docs/Gameplay.gif)
![shop](docs/Shop.gif)

## Features
- Control del personaje con jetpack basado en físicas
- Generación procedural de obstáculos aleatorios
- Dificultad progresiva según la puntuación
- Tienda de aspectos que se compran con dinero del juego, con guardado de progreso mediante PlayerPrefs y uso de ScriptableObjects
- Audio con FMOD

## Mi rol
Programación, arte y diseño (proyecto en solitario).

## Scripts relevantes
- `PlayerMovement.cs`: físicas del jugador
- `SpawnerController.cs`: generación de obstáculos y lógica de cada uno de ellos
- `SkinManager.cs`: compra y equipado de aspectos
- `DataManager.cs`: guardado con PlayerPrefs
- `AudioManager.cs`: integración con FMOD

## Jugar
https://rodei.itch.io/alien-jet

## Créditos
SFX: Pixabay
