#!/bin/bash
docker build . -t dockerized-react
docker images | grep dockerized-react
docker run -p 3000:3000 -d dockerized-react