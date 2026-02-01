# 🎳 VR Bowling Game

A virtual reality bowling game built with **Unity** for **Meta Quest 3**, focused on realistic physics, intuitive VR interactions, and optimized performance for standalone VR.

---

## 🚀 Project Overview

This project is a VR bowling experience where players can:

- Pick up and throw a bowling ball using VR controllers  
- Hit pins with realistic physics  
- Score points based on pins knocked down  
- Play across multiple difficulty levels  

**Goal of the project:**
- Practice VR development  
- Improve Unity optimization skills  
- Design clean and reliable game logic  

---

## 🕶️ Platform & Tools

- **Engine:** Unity 6.x  
- **VR Device:** Meta Quest 3  
- **SDK / Frameworks:**
  - XR Interaction Toolkit / VR Interaction Framework (BNG)
  - TextMeshPro  
- **Language:** C#  

---

## 🎮 Gameplay Features

### 🎯 Realistic Bowling Mechanics
- Physics-based ball throwing  
- Accurate pin collision and fall detection  

### 🧮 Scoring System
- Score increases only when pins fall  
- Win conditions based on difficulty level  

### 🎚️ Difficulty Levels
- Beginner  
- Intermediate  
- Advanced  

### 🎳 Ball Usage Logic
- Limited number of balls per round  
- Ball is counted when it:
  - Hits pins  
  - Scores  
  - Exits the lane  

### ⚠️ Smart Warnings
- Wrong throw (outside lane)  
- Ball dead  
- Ball hit but no pin fallen  

---

## 🧠 Core Systems Explained

### 1. Ball & Lane Logic
- Detects when the ball:
  - Enters the lane  
  - Hits pins  
  - Exits the trigger zone  
- Ensures ball count is updated correctly  

### 2. Pin Detection
- Pins are counted only when they fall  
- Prevents false scoring when pins are touched but not knocked down  

---

## ⚡ Performance & Optimization (VR Focused)

- Optimized physics settings for Meta Quest 3  
- Reduced draw calls  
- Lightweight UI designed for VR  
- Trigger zones used instead of heavy collision checks  
- Script-level optimizations:
  - Singleton managers  
  - Minimal use of `Update()`  

---

## 🛠️ Skills Demonstrated

- Unity Game Development  
- VR Development (Meta Quest)  
- C# Programming  
- Physics-based Gameplay  
- Game State Management  
- UI/UX for VR  
- Performance Optimization  
- Debugging & Logic Fixes  

---

## 👤 Author

**Developed by Pavith**

VR Developer | Unity | Meta Quest  

---

## ⭐ How to Use

1. Clone the repository  
2. Open the project in **Unity 6.x**  
3. Switch build platform to **Android**  
4. Connect **Meta Quest 3**  
5. Build & Run  

---

⭐ If you like this project, don’t forget to star the repo!
