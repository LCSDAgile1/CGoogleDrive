# CGoogleDrive
Enterprise Account Google Drive Crawler

#CONFIGURATION

To configure the CGoogleDrive application you will need to first configure the application settings.

Once you have downloaded the file:

- **Click** on Folder to be at root level of the cGoogleDrivefolder --> 
- **Hold down shit** key and **right click** anywhere in the root of the folder. A menu will appear with the option "*Open Command window here*" and **select** that option. -->

![image](https://cloud.githubusercontent.com/assets/25845638/23080273/1f621090-f51e-11e6-940a-0daf8fc7f25e.png)


- on the Command prompt **type** the following: 
```
cGoogleDrive -Setup
```

##Google Setup
- this will take you to the application setup window -->
![image](https://cloud.githubusercontent.com/assets/25845638/23080388/88a24b4c-f51e-11e6-9d0d-1efac37f7abc.png)

-  on the right side **CLICK** on "*Google Setup*" -->
- **ENTER** information on the corresponding fields.
```
    -Service account email:   gService account email.
    -Service account key file: enter service account file.(p12 file)
        *p12 file is provided by your gservice account, make sure to copy the file to the Root of the folder.
    -filter:    modifiedTime > '2012-06-04T12:00:00' and (mimeType contains 'audio/' or mimeType contains 'video/')
    -application name:   adminsdk
    -MaxParallel processes: 10
```


after entering you information -->
- **CLICK  on the verify** button to confirm access to Google drive. 
- **CLICK  on the perview** button to preivew data from a user.

##Input Configuration

**Click** on Input Configuration to *SELECT the type of input* your enviorment is using or will like to use.

![image](https://cloud.githubusercontent.com/assets/25845638/23080492/ef516b8e-f51e-11e6-87ef-91ac95616606.png)

Underneath Input Configuration, you have multiple platform that you can choose from but will need to be configured. Configuration depends on your enviorment or the source of your imput.

##Output Configuration

**Click** on Output Configuration to *SELECT the type of Output* your enviorment is using or will like to use.

![image](https://cloud.githubusercontent.com/assets/25845638/23080575/4a1ef590-f51f-11e6-9ea7-c42671cd4cb9.png)

Underneath Output Configuration, you have multiple platform that you can choose from but will need to be configured for the type of output you want. Configuration depends on your enviorment and what are you implementing. if you will like a .csv output, simply select flat file as your output.



