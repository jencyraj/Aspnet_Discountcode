# Aspnet_Discountcode
Aspnet_Discountcode


Architucture: N layer, <br/>
SwaggerAPI<br/>
Database: Postgres
- http://localhost:5050/
- username: admin
- pwd:admin1234 
<br/>
**Generating CouponCode:**   <br/>
Give Input (count , Alphanumeric as string) // I have Some Idea but within this time limit I cannot elaborate.<br/>
check Post method<br/>
Endpoint : http://localhost:5004/swagger/Index.html <br/>
**Fetching Code By BrandName** <br/>
give input (BrabdName) <br/>
Endpoint : 
<br/>
http://localhost:5006/swagger/Index.html 
<br/>
Total time: 3 hr <br/>

1st Part: 1 hr  <br/>
2nd Part : 1 hr 30 min + debug and test all 
<br/>

## Setup and Working
- load this project in visual studio 
- setup docker in your local machine
- open command terminal ( right click docker composer and select open terminal)
- run the command 'docker ps' for checking docker is working fine on your local machine
- please check any other program used the same port ,which I used here. 
- if yes, stop the other program or change my port from each API properties:debug section and save.
-  the Up the docker compos file using the below command
-  :+1: docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
- run the  project using the given endpoints :+1:




