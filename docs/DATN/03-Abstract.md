# ABSTRACT

American Sign Language (ASL) is an essential communication tool for the deaf and hard-of-hearing community. However, learning ASL through traditional methods such as printed materials or 2D videos is often challenging due to the three-dimensional spatial nature and dynamic kinematics of hand gestures. Learners typically lack an immersive, interactive environment and real-time corrective feedback to confirm the accuracy of their gestures.

This graduation thesis proposes the development of **"Sign Language Lectures in Virtual Reality"** running on the standalone Meta Quest 2 platform. By leveraging natural, controller-free interaction via the **Unity XR Hands** package, the application allows learners to use their physical hands to perform sign language gestures directly inside virtual environments.

The software architecture is built upon an **Event-Driven** paradigm centered around a static global event broker named **`GestureHub`**. The educational system is systematically organized as follows:
* **`ProgressManager` and `ClassroomManager`**: Orchestrate the global learning progression across three core topics (Alphabets, Numbers, Greetings), automatically locking and unlocking classrooms based on user performance.
* **Practice Mode with NPC Kyle (`NPCKyleController`)**: Delivers vocabulary lessons dynamically, visualizing learning progress with distinct colors and providing interactive feedback through guide animations.
* **Standardized Testing System (`QuizManager`)**: Integrates a 3D **Quiz Board** supporting multiple question formats (gesture-matching, spelling/ordering, and auditory gap-filling). To alleviate testing anxiety and enhance user engagement, the system integrates unique stress-relief mechanisms: **Hidden Mistakes**, the **Invincibility Window**, and a list of **No-Penalty Gestures**.

A key technical contribution of this work is the successful recognition of complex, trajectory-based dynamic gestures such as the letters **`J`** and **`Z`**. The system implements the **`VRMagicTrajectory`** module to track the 3D coordinate path of the player's index fingertip (`IndexTip`), projects these points onto the camera's local 2D space, and utilizes a custom **$1 Unistroke Recognizer** algorithm to accurately classify the drawing gestures.

From a pedagogical standpoint, the interaction design is grounded in **Edgar Dale's Cone of Experience** and **David Kolb's Experiential Learning Theory**. The introduction of a compact wrist-mounted interface (**`WristDashboardUI`**) and camera-facing billboards (**`UIFaceCamera`**) acts as a powerful catalyst for the reflective observation and self-adjustment phases of the learning loop, optimizing motor memory retention.

Experimental results demonstrate that the application runs stably at high performance (72 - 90 FPS) with extremely low detection latency (< 0.2s) and high gesture recognition accuracy. This product serves not only as an engaging, highly interactive educational VR game but also introduces a new methodology for employing natural VR interfaces in special education and sustainable social development.

**Keywords**: *Virtual Reality (VR), American Sign Language (ASL), Gesture Recognition, Unity XR Hands, $1 Unistroke, Educational Technology (EdTech), Controller-free Interaction.*
