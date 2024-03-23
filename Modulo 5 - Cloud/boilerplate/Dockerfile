# ** Partimos de esta base
FROM node:18-alpine AS base

# Crear app directory, y lo uso como working directory
RUN mkdir -p /usr/app
WORKDIR /usr/app

# ** Build de back partimos de base pero creamos la fase back-build
FROM base as back-build
# Copia backend al raíz workdir (/usr/app)
COPY ./back ./

# Hacemos el install y el build
RUN npm ci
RUN npm run build


# Le indicamos variables de entorno (OJO sensibles NO)
EXPOSE 3000
ENV PORT=3000
ENV STATIC_FILES_PATH=./public
ENV API_MOCK=true
ENV AUTH_SECRET=MY_AUTH_SECRET

# Actualizamos las rutas del package.json para que apunten a dist
RUN apk update && apk add jq
RUN updatedImports="$(jq '.imports[]|=sub("./src"; "./dist")' ./package.json)" && echo "${updatedImports}" > ./package.json

# Ejecutamos al aplicación (OJO CMD no lo hacemos con RUN)
CMD node dist/index