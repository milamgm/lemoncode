# Laboratorio MongoDB

Vamos a trabajar con el set de datos de Mongo Atlas _airbnb_. Lo puedes encontrar en este enlace: https://drive.google.com/drive/folders/1gAtZZdrBKiKioJSZwnShXskaKk6H_gCJ?usp=sharing

Para restaurarlo puede seguir las instrucciones de este videopost:
https://www.lemoncode.tv/curso/docker-y-mongodb/leccion/restaurando-backup-mongodb

> Acuerdate de mirar si en el directorio `/opt/app` del contenedor Mongo hay contenido de backups previos que haya que borrar

Para entregar las soluciones, añade un README.md a tu repositorio del bootcamp incluyendo enunciado y consulta (lo que pone '_Pega aquí tu consulta_').

## Introducción

En este base de datos puedes encontrar un montón de alojamientos y sus reviews, esto está sacado de hacer webscrapping.

**Pregunta**. Si montaras un sitio real, ¿Qué posibles problemas pontenciales les ves a como está almacenada la información?


- El documento es excesivamente grande; esto traerá problemas. Debido a que el tamaño máximo de un documento es de 16MB, que los documentos solo se pueden cargar en su totalidad en memoria y que esta tiene un limite, es recomendable aplicar subset pattern, anidando solamente las partes que mas vamos a utilizar y sacar el resto a otras colecciones.

De este modo dejamos el working set libre para los documentos que mas se vayan a utilizar.

Por ejemplo, aplicar extended ref, anidando solamente las primeras 10 reviews y guardando el resto a parte. Lo mismo con la informacion del host, anidando solamente los campos mas relevantes.
Tambien se podrian poner a parte las amenities.

- Tambien podramos anadir schema versioning a este documento si pretendemos modificarlo en el futuro. De este modo podemos intriducit cambios e ir migrando en un proceso batch los antiguos sin tener que parar la aplicación.

- Se podria aplicar un tree pattern en las amenities si queremos organizarlas en varios niveles, por ejemplo kitchen > microwave

- Podriamos aplicar el patron atributo a los campos:

 "accommodates": 2,
    "bedrooms": 1,
    "beds": 1,
    "bathrooms": {
      "$numberDecimal": "1.0"
    },

agrupandolos en un único indice, ya que todos se refieren a las caracteristicas de la vivienda.


- Podriamos aplicar polymorfic pattern a las direcciones, para tener campos que correspondan a la estructura de cada pais.


## Obligatorio

Esta es la parte mínima que tendrás que entregar para superar este laboratorio.

### Consultas

- Saca en una consulta cuantos alojamientos hay en España.

```js
// Pega aquí tu consulta
```

- Lista los 10 primeros:
  - Ordenados por precio de forma ascendente.
  - Sólo muestra: nombre, precio, camas y la localidad (`address.market`).

```js
// Pega aquí tu consulta
```

### Filtrando

- Queremos viajar cómodos, somos 4 personas y queremos:
  - 4 camas.
  - Dos cuartos de baño o más.
  - Sólo muestra: nombre, precio, camas y baños.

```js
// Pega aquí tu consulta
```

- Aunque estamos de viaje no queremos estar desconectados, así que necesitamos que el alojamiento también tenga conexión wifi. A los requisitos anteriores, hay que añadir que el alojamiento tenga wifi.
  - Sólo muestra: nombre, precio, camas, baños y servicios (`amenities`).

```js
// Pega aquí tu consulta
```

- Y bueno, un amigo trae a su perro, así que tenemos que buscar alojamientos que permitan mascota (_Pets allowed_).
  - Sólo muestra: nombre, precio, camas, baños y servicios (`amenities`).

```js
// Pega aquí tu consulta
```

- Estamos entre ir a Barcelona o a Portugal, los dos destinos nos valen. Pero queremos que el precio nos salga baratito (50 $), y que tenga buen rating de reviews (campo `review_scores.review_scores_rating` igual o superior a 88).
  - Sólo muestra: nombre, precio, camas, baños, rating y localidad.

```js
// Pega aquí tu consulta
```

- También queremos que el huésped sea un superhost (`host.host_is_superhost`) y que no tengamos que pagar depósito de seguridad (`security_deposit`).
  - Sólo muestra: nombre, precio, camas, baños, rating, si el huésped es superhost, depósito de seguridad y localidad.

```js
// Pega aquí tu consulta
```

### Agregaciones

- Queremos mostrar los alojamientos que hay en España, con los siguientes campos:
  - Nombre.
  - Localidad (no queremos mostrar un objeto, sólo el string con la localidad).
  - Precio

```js
// Pega aquí tu consulta
```

- Queremos saber cuantos alojamientos hay disponibles por pais.

```js
// Pega aquí tu consulta
```

## Opcional

- Queremos saber el precio medio de alquiler de airbnb en España.

```js
// Pega aquí tu consulta
```

- ¿Y si quisieramos hacer como el anterior, pero sacarlo por paises?

```js
// Pega aquí tu consulta
```

- Repite los mismos pasos pero agrupando también por numero de habitaciones.

```js
// Pega aquí tu consulta
```

## Desafio

Queremos mostrar el top 5 de alojamientos más caros en España, con los siguentes campos:

- Nombre.
- Precio.
- Número de habitaciones
- Número de camas
- Número de baños
- Ciudad.
- Servicios, pero en vez de un array, un string con todos los servicios incluidos.

```js
// Pega aquí tu consulta
```
