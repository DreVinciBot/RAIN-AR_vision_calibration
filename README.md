# RAIN-AR_vision_calibration
AR application for calibrating vision algorithms for robotic detection 

This repository contains the Unity files required to build on a Android device. 

[Video Demo of RAIN](https://youtu.be/GEjxFN2Mgq0)

![Alt text](RAIN_cylinder_model.png?raw=true "Title")
Screenshots of the mobile view of SENSAR visualizing depth sensor data of a workspace containing an object. The cylinder segmentation algorithm will display any cylinder models if detected. (Top) displays the cylinder detected and renders particles that belong to the segmented point-cloud group. The radius max limit is set at 0.045 m. (Bottom) displays the same segmentation algorithm; however, the cylinder is not detected because the radius limit was reduced below the size of the physical cylindrical object. The user can also control the distribution and display settings by accessing the settings menu (i.e. particle size, particle color, particle transparency) of the particle system to calibrate the model-specific parameters in the visual algorithm.
