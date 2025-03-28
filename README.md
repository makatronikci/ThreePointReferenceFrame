# Three-Point Reference Frame Calculator

## Overview
This program calculates a reference frame using the **three-point method**. By inputting the X, Y, and Z coordinates of three specific points:

- **Origin Point**
- **X-Axis Point**
- **XY-Plane Point**

The program determines the **reference frame**, including position and orientation, which can be used for any **robot brand**.

## Features
- Computes **reference frame coordinates** based on three input points.
- Uses **vector operations** (cross product, scalar product, vector normalization) to determine the **orientation**.
- Outputs position (**X, Y, Z**) and orientation (**RX, RY, RZ**) in **degrees**.
- Can be used in various industrial applications where reference frames are required.

## How It Works
The program follows these steps:
1. Takes the coordinates of the three reference points.
2. Calculates unit vectors for the **X-axis** and the **XY-plane direction**.
3. Determines the **Z-axis** using the **cross product**.
4. Normalizes the vectors to form a proper rotation matrix.
5. Computes rotation angles **(RX, RY, RZ)** using trigonometric functions.
6. Displays the final **reference frame position and orientation**.

## Example Output
```plaintext
X: 506.653
Y: -11.331
Z: 718.057
RX: 0.0
RY: -5.2
RZ: 45.3
```

## Compatibility
- This program is written in **C# (.NET)** and can run on any system that supports .NET.
- It is **robot-agnostic**, meaning it can be used with any robot brand that requires a three-point reference frame calculation.

## Usage
1. Clone the repository or copy the source code.
2. Compile and run the program using a **C# compiler**.
3. Modify the three input points as needed for your specific setup.

## Code Structure
- **`PT` Class**: Represents a point with X, Y, and Z coordinates.
- **Vector Operations**: Includes cross product, vector division, and scalar product.
- **Main Calculation**: Computes transformation matrix and rotation angles.
- **Output Section**: Displays the calculated reference frame.

## Future Improvements
- Add a **user input interface** to allow dynamic input instead of hardcoded values.
- Implement **error handling** for cases where the points are collinear.
- Provide support for **different coordinate systems** used in various robot brands.

## License
This project is released under the **MIT License**. Feel free to modify and use it in your projects!

---
For any questions or suggestions, feel free to open an **issue** or submit a **pull request** on GitHub. 🚀

