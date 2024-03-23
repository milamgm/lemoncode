FROM node:18-alpine

RUN mkdir -p /urs/app
WORKDIR /usr/app

COPY ./back ./

RUN npm ci
RUN npm run build