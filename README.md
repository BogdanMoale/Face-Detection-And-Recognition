# Face-Detection-And-Recognition

Windows Forms application in C# for detection and face recognition. It includes various modules, such as training, recognition, database management, and Bluetooth functionality.

# Training Module

This module uses Emgu.CV library for computer vision tasks
Here's an overview of the key components and functionalities in the provided code:

1. Capture and Face Detection: The application captures video from a camera (if available) using the Capture class from Emgu.CV. It then applies face detection using the Haar Cascade classifier (HaarCascade) to identify faces in the captured frames.

2. Image Processing: The application processes the captured frames and converts them to grayscale (Image<Gray, byte>) for face detection and recognition.

3. Lists for Storing Faces and Names: The application uses two lists, imageToDataBase and NamesOfPersons, to store the captured faces and corresponding names, respectively.

4. Load Faces From Database: The application loads previously saved face data from the database (directory with BMP images) and their corresponding names from a text file.

5. User Interface (UI): The UI includes buttons, image boxes, a RichTextBox, and menu items. Users can start/stop capturing, capture faces, and train the database.

6. Capture and Training Functions: The StartCapture, StopCaptureForTraining, and LoadFacesFromDataBaseForTraining methods handle camera capture, stopping capture, and loading faces for training.

7. Face Capturing and Training: Users can capture a face and associate it with a name using the "Capturare Fata" and "Antrenare Fata" buttons, respectively. The captured face is stored in the database along with the name provided.

8. Recognition: The application allows recognition of faces using the "recunoastereToolStripMenuItem_Click" menu item. It hides the current form and opens the "Recognizer" form, which handles face recognition.

10. Additional Functionality: There are additional functionalities like saving and loading face data to/from files, stopping capturing, and providing feedback through a RichTextBox.

# Face Recognition

This is the "Recognizer" form that performs face recognition based on the faces previously trained and stored in the database.
Here's an overview of the key components and functionalities in the provided code:

1. Capture and Face Detection: The application captures video from a camera using the Capture class from Emgu.CV. It then applies face detection using the Haar Cascade classifier (HaarCascade) to identify faces in the captured frames.

2. Image Processing: The application processes the captured frames and converts them to grayscale (Image<Gray, Byte>) for face detection and recognition.

3. Lists for Storing Faces and Names: The application uses two lists, trainingFaces and NamesOfPersons, to store the previously trained faces and their corresponding names, respectively.

4. Recognition: The application uses Eigenface-based recognition (EigenFaceRecognizerEngine) to recognize faces from the captured frames.

5. User Interface (UI): The UI includes buttons, image boxes, and a track bar for adjusting the recognition threshold.

6. Database Operations: The application allows loading face data from the database (directory with BMP images) and their corresponding names from a text file. It also provides options to browse for and save the path of an Excel database file. The application reads and writes data to the Excel database for keeping track of employee arrivals and departures.

7. Sending Email: There is a functionality to send an email with an attached image of an unauthorized person detected by the system

8. Treshold Value: The track bar allows adjusting the recognition threshold value for the Eigenface recognition method. The selected threshold value is shown in a label.

9. Additional Functionality: There are additional functionalities like updating the current time and date, generating a report from the Excel database, and deleting old data from the Excel database.

# Detect Face From Photo
Detecting faces in an image using the Emgu.CV library. This is the "DetectareFataDinFotografie" form that allows users to load an image, detect faces in it using Haar Cascade classifier, and optionally add new detected faces to the face database.

Here's an overview of the key components and functionalities in the provided code:

1. Capture and Face Detection: The form allows users to load an image and detect faces in it using the Haar Cascade classifier (HaarCascade).

2. Image Processing: The image is converted to grayscale (Image<Gray, Byte>) for face detection

3. Image Display: The application displays the loaded image with detected faces in an ImageBox.

4. Face Detection: The application uses Haar Cascade-based face detection to find faces in the loaded image.

5. Face Database: The application allows loading faces and their corresponding names from a text file ("PersonsNames.txt"). The detected faces can also be added to the face database, and the database is updated with the new face and name.

6. Adding New Face to Database: Users can enter a name for the detected face and add it to the face database using the "Adauga persoana in baza de date" button.

7. Loading and Saving Face Database: The face database is loaded from the "DataBase" directory, and names of persons are read from the "PersonsNames.txt" file. The face and name of the new person are appended to the database.

8. Face Detection in Image: The "Detect Face" button triggers the face detection process in the loaded image and displays the detected faces with green rectangles around them.

Please note that the code uses the Haar Cascade classifier for face detection, which is a pre-trained model for detecting frontal faces. If you want to detect faces in different orientations or profiles, you might need to use other methods like the DNN (Deep Neural Network) based models for face detection.

Additionally, the code assumes that there is a "DataBase" directory where face images ("faceX.bmp") and "PersonsNames.txt" file with person names are stored.

# Data Base
This is the "BazaDeDate" form that allows users to browse through the face database, view the images, and update the names of the persons in the database.

Here's an overview of the key components and functionalities in the provided code:

1. Loading Face Database: The form loads the face database and names of persons from the "PersonsNames.txt" file in the "DataBase" directory. The number of items in the database is stored in MaxItemsArray.

2. Image Display: The application displays the images from the face database in an ImageBox. Users can navigate through the database using "Imagine inainte" (Next Image) and "Imagine inapoi" (Previous Image) buttons.

3. Updating Person Name: Users can update the name of the current person in the database using the "Actualizare Nume" (Update Name) button. The updated name is saved back to the "PersonsNames.txt" file.

4. Navigation Buttons: The "Imagine inainte" (Next Image) and "Imagine inapoi" (Previous Image) buttons enable navigation through the face database. When at the first or last image, the corresponding button is disabled to prevent going out of bounds.

Please note that the code assumes that there is a "DataBase" directory where face images ("faceX.bmp") and "PersonsNames.txt" file with person names are stored.

# Mail Configuration
Configuring email settings related to face recognition, so that we can get an email every time the application does not recognize a person

Here's an overview of the key components and functionalities in the provided code:

1. MailConfiguration Form: This form allows the user to configure email-related settings, such as the email address to send emails from, the email password, the recipient's email address, SMTP server address, and SMTP port.

2. Loading and Saving Settings: The form loads the email settings from the application's settings (presumably, application settings are stored in the "Properties.Settings.Default" object). When the user clicks the "OK" button, the updated email settings are saved to the application settings.

3. Updating Email Settings: The method updateMail() is used to update the email settings in the SetEmail class. This class seems to be responsible for holding the email settings, and it is not provided in the code snippet.

4. Password Masking: The password textbox (textBoxPassw) has its PasswordChar property set to '*' to mask the password characters.

5. To handle the functionality of the email, i used "SetEmail" class which is a simple class that acts as a container for storing email-related settings. It uses static properties to store and retrieve values for email address, password, recipient address, SMTP server address, and SMTP port:
mailFrom: Represents the email address from which the application will send emails.<br/>
maillPassword: Represents the password for the email account used to send emails.<br/>
maillTo: Represents the recipient's email address to which the emails will be sent.<br/>
maillSmtpAdress: Represents the SMTP server address used for sending emails.<br/>
maillPort: Represents the SMTP port used for sending emails.<br/>

6. Since the SetEmail class uses static properties, any changes made to these properties will affect all instances of the class. This makes it a simple and convenient way to manage email settings in the application.
With the SetEmail class and the MailConfiguration form, the application can now read and update email settings as needed. The application will use these settings to send notifications or reports related to face recognition tasks.


# Bluetooth Module
The BluetoothForm class is a Windows Forms form that allows the user to scan for nearby Bluetooth devices, connect to a selected device, and disconnect from a connected device. It uses the CustomBluetoothService class to handle Bluetooth communication.

Let's go through the key components of the BluetoothForm class:


The BluetoothForm class is a Windows Forms form that allows the user to scan for nearby Bluetooth devices, connect to a selected device, and disconnect from a connected device. It uses the CustomBluetoothService class to handle Bluetooth communication.

Let's go through the key components of the BluetoothForm class:

1. Variables and Properties:<br/>

bluetoothService: An instance of the CustomBluetoothService class used for Bluetooth communication. <br/>
serviceResult: An instance of the BluetoothConnectionResult class that stores the result of a Bluetooth connection attempt. <br/> 
bluetoothDevices: A property that returns an array of BluetoothDeviceInfo representing the nearby Bluetooth devices found during scanning.<br/>
bluetoothConnected: A property that returns a boolean value indicating whether the Bluetooth connection is successful.<br/>

2. Background Workers:<br/>

scanWorker: A BackgroundWorker object that performs the scanning for nearby Bluetooth devices asynchronously.<br/>
connectionWorker: A BackgroundWorker object that handles the Bluetooth connection asynchronously.<br/>

3. Constructor:<br/>

The constructor initializes the form and sets up the event handlers for the background workers. It also initializes the bluetoothService and serviceResult based on the provided parameters.

4. Event Handlers:<br/>

btnScan_Click: This event handler is triggered when the user clicks the "Scan" button. It starts the scanning process by running the scanWorker asynchronously.<br/>

ScanWorker_DoWork: This method is executed in the background thread and performs the actual scanning for nearby Bluetooth devices using the bluetoothService.<br/>

ScanWorker_RunWorkerCompleted: This event handler is called when the scanning is completed. It updates the UI with the found Bluetooth devices and re-enables the "Scan" button.<br/>

btnConnect_Click: This event handler is triggered when the user clicks the "Connect" button. It starts the connection process by running the connectionWorker asynchronously.<br/>

ConnectionWorker_DoWork: This method is executed in the background thread and performs the actual Bluetooth connection using the selected device from the list.<br/>

ConnectionWorker_RunWorkerCompleted: This event handler is called when the connection attempt is completed. It displays a success message if the connection is successful or a warning message otherwise.<br/>

btnDisconnect_Click: This event handler is triggered when the user clicks the "Disconnect" button. It disconnects from the current Bluetooth device and updates the UI accordingly.<br/>

devicesBluetoothListBox_SelectedIndexChanged: This event handler is called when the selected item in the Bluetooth devices list is changed. It enables the "Connect" button when a valid device is selected.<br/>

The BluetoothForm class provides a user-friendly interface for scanning, connecting, and disconnecting Bluetooth devices, making it easier for users to interact with the application's Bluetooth functionality.
