# ApiClinicGAP

Here you can find the Web Api for the project **ClinicGAP**. This is consumed by the Angular project **_WebClinicGAP_**, equally available on my GitHub profile: https://github.com/Jefffer/WebClinicGAP

## Launch the App

To launch all the application correctly, you must clone both repositories and run them simultaneously on the appropriate port, please validate them iin the corresponding files:

### For Angular project

Check the line `readonly rootURL = "http://localhost:60009/api"; // API connection` defined in the _components.service.ts_ of `patient`, `user` and `appointment`

### For Web Api project

Check the line `config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));` located in the file **_WebApiConfig.cs_**.

## Database creation

For Database creation, please run the script **_ClinicGAP.sql_** located in this repository. This script was generated by SQL Server, it includes not only the scheme but also the information necessary to properly execute the application.
