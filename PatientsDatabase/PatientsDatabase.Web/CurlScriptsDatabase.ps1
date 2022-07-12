Invoke-WebRequest "https://localhost:44361/get-appointments"
Invoke-WebRequest  "https://localhost:44361/get-appointments-by-pwz?pwz=1234567"
Invoke-WebRequest  "https://localhost:44361/get-appointments-by-pesel?pesel=12345678910"
Invoke-WebRequest  "https://localhost:44361/get-patients"
Invoke-WebRequest -UseBasicParsing "https://localhost:44361/post-appointment" -ContentType "application/json" -Method POST -Body '{"pesel":"45678901234", "pwz":"1234567", "startDate":"2021-04-18T22:20:37.048Z"}'
Invoke-WebRequest -UseBasicParsing "https://localhost:44361/delete-appointment?id=28" -ContentType "application/json" -Method DELETE