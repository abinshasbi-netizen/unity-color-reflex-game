# Sluggy Game

Sluggy Game is a fast-paced Unity 2D reflex platformer where players must react quickly to incoming particles by switching between different color states. Depending on the equipped player color, particles can either be collected for points or avoided to survive.

The project focuses on responsive gameplay mechanics, object pooling optimization, UI state management, and mobile-oriented game systems.

---

## Features

- Color-switching gameplay mechanic
- Collectible and hazard interaction system
- Player movement and jump mechanics
- Object pooling for optimized spawning
- Dynamic gameplay object spawning
- Score tracking and game state management
- Pause, restart, and instruction systems
- Audio feedback integration
- Organized UI and gameplay architecture
- Mobile-focused Unity 2D gameplay

---

## Technologies Used

- Unity 6
- C#
- Unity Input System
- Unity Animator
- Unity UI System
- Object Pooling System

---

## Project Structure

```bash
Assets/
│
├── Animations/
├── Audio/
├── Prefabs/
├── Scenes/
├── Scripts/
│   ├── Player/
│   ├── Gameplay/
│   ├── Pooling/
│   ├── UI/
│   └── Audio/
│
├── Sprites/
│   ├── Backgrounds/
│   ├── Player/
│   ├── Collectibles/
│   ├── Hazards/
│   └── UI/
│
└── UI/
```

---

## Gameplay Overview

Players must survive by interacting with incoming particles based on the currently equipped player color.

- Matching particles increase score
- Incorrect interactions trigger failure conditions
- Players can switch between multiple color states dynamically during gameplay

The gameplay emphasizes reaction speed, timing, and state-based decision making.

---

## Core Systems

### Player Mechanics
- Jump handling
- Ground detection
- Color switching
- Animation controller integration

### Gameplay Systems
- Hazard and collectible spawning
- Collision-based interaction logic
- Score tracking
- Game over handling

### Optimization
- Object pooling architecture for reusable gameplay objects
- Organized project hierarchy and asset structure

---

## Future Improvements

- Additional gameplay modes
- Advanced visual effects
- Leaderboard integration
- Mobile gameplay balancing
- Expanded audio feedback systems

---

## Author

**Abin Georege**

GitHub: https://github.com/abinshabi-netizen