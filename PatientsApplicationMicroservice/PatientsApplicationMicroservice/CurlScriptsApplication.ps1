Invoke-WebRequest 'https://localhost:44386/appointments?pesel=45678901234'
Invoke-WebRequest  'https://localhost:44386/availabilities'
Invoke-WebRequest  'https://localhost:44386/doctors'
Invoke-WebRequest  'https://localhost:44386/doctors-by-specialization?id=4'
Invoke-WebRequest   'https://localhost:44386/doctor-schedule?pwz=123457'
Invoke-WebRequest  'https://localhost:44386/doctor-by-pwz?pwz=123457'
Invoke-WebRequest -UseBasicParsing 'https://localhost:44386/appointment' -ContentType "application/json" -Method POST -Body '{"pesel":"45678901234", "pwz":"123457", "startDate":"2021-04-18T22:42:34.148Z"}'
Invoke-WebRequest -UseBasicParsing 'https://localhost:44386/appointment?id=32&pwz=123457&startDate=2021-04-18T22%3A42%3A34' -ContentType "application/json" -Method DELETE