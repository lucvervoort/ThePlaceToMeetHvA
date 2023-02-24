docker build . -t dockerized-react
REM docker images | grep dockerized-react
REM docker run -p 3000:3000 -d dockerized-react