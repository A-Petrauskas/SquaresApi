

Steps to launch:
1.	Install docker (https://docs.docker.com/get-docker/)
2.	Run ```docker run -d -p 27017:27017 mongo``` in a command line interface
3.	Clone repository, open solution, build and run Host
4.	A browser window should pop with the API presented with Swagger
(if not) go to http://localhost:5000/swagger/index.html

Because the problem definition did not specify whether the squares can share coordinates with other squares in the POST “squares/ points/{squareUniq}” endpoint there is parameter which sets this property. If 1 is provided, the squares are all unique (a point can only belong to a single square). If 0 or anything else – the squares can share points.

The exercise: https://github.com/m0d7/squares-api-exercise/blob/main/README.md
